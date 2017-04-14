using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coffee_Shop.Users
{
    public partial class Checkout : System.Web.UI.Page
    {
        string user = "";
        public int userID;
        private int orderID;

        private int productID;
        private int productQuantity;
        private double price;
        protected void Page_Load(object sender, EventArgs e)
        {
            user = HttpContext.Current.User.Identity.Name;
            userID = getCurrentUser(user);
        }

        private int getCurrentUser(string username)
        {
            int userID = 0;

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT userID FROM Users WHERE username = @username");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@username", username);
                connection.Open();
                try
                {

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            userID = Convert.ToInt32(reader["userID"]);

                        }
                    }
                    connection.Close();
                }
                catch
                {

                }
            }
            return userID;
        }

        private void orderDetails() //insert into order details
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {

                SqlCommand cmd = new SqlCommand("INSERT INTO OrderDetails (orderID, productID, quantity, totalPrice) VALUES (@orderID, @productID, @quantity, @totalPrice)");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@orderID", orderID);
                cmd.Parameters.AddWithValue("@productID", productID);
                cmd.Parameters.AddWithValue("@quantity", productQuantity);
                cmd.Parameters.AddWithValue("@totalPrice", price);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void deleteFromCart()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {

                SqlCommand cmd = new SqlCommand("DELETE FROM Cart WHERE userID = @user AND productID = @productID");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@user", userID);
                cmd.Parameters.AddWithValue("@productID", productID);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        private void updateAvailableQuantity()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {

                SqlCommand cmd = new SqlCommand("UPDATE Coffee SET Stock = Stock - @quantity, reserved = @quantity WHERE Id = @productID");
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                cmd.Parameters.AddWithValue("@quantity", productQuantity);
                cmd.Parameters.AddWithValue("@productID", productID);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
        }

        protected void Buy_Click(object sender, EventArgs e)
        {
            
            DateTime orderDate = DateTime.Now;
            string status = "order placed";
            string first = Name.Text;
            string last = lastName.Text;
            string address = Address.Text;
            string postcode = postCode.Text;
           
            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {

                    SqlCommand cmd = new SqlCommand("INSERT INTO Orders (userID, orderDate, status, firstName, lastName, address, postCode) VALUES (@user,@orderDate, @status, @firstName, @lastName, @address, @postCode)");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@user", userID);
                    cmd.Parameters.AddWithValue("@orderDate", orderDate);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.Parameters.AddWithValue("@firstName", first);
                    cmd.Parameters.AddWithValue("@lastName", last);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@postCode", postcode);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    SqlCommand cmd = new SqlCommand("SELECT TOP 1 MAX(orderDate) as lastOrder, orderId FROM Orders WHERE userID = @user GROUP BY orderId ORDER BY lastOrder DESC");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@user", userID);
                    connection.Open();
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                orderID = Convert.ToInt32(reader["orderId"]);

                            }
                        }
                        connection.Close();
                    }
                    catch
                    {

                    }

                    SqlCommand cmd2 = new SqlCommand("SELECT productID, quantity, price FROM Cart WHERE userID = @user");
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Connection = connection;
                    cmd2.Parameters.AddWithValue("@user", userID);
                    connection.Open();
                    try
                    {
                        SqlDataReader reader = cmd2.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                productID = Convert.ToInt32(reader["productID"]);
                                productQuantity = Convert.ToInt32(reader["quantity"]);
                                price = Convert.ToDouble(reader["price"]);

                                orderDetails();
                                deleteFromCart();
                                updateAvailableQuantity();                                
                            }
                        }
                        connection.Close();
                    }
                    catch
                    {

                    }
                }
                sendMail mail = new sendMail();
               
                mail.sendEmailToUser("Order from >_Coffee", "Your order is placed!");

                Response.Redirect("~/Users/checkoutSuccess.aspx");
            }

            catch
            {
                //display error  message
            }

        }
       
    }
}