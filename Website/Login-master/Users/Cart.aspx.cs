using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coffee_Shop.Users
{
    public partial class Cart : System.Web.UI.Page
    {
        string user = "";
        public int userID = 0;
        private double totalPrice;

        protected void Page_Load(object sender, EventArgs e)
        {
            user = HttpContext.Current.User.Identity.Name;
            userID = getCurrentUser(user);

            SqlDataSource1.SelectParameters.Add("userId", userID.ToString());

            getTable();
        }

        private void getTable()
        {
            getTotal();

            string total = string.Format("{0:C}", totalPrice);
            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            row.BackColor = ColorTranslator.FromHtml("#F9F9F9");
            row.Cells.AddRange(new TableCell[5]
            {
                new TableCell(), //Empty Cell
                new TableCell(),
                new TableCell(),
                new TableCell {Text = "Subtotal:", HorizontalAlign = HorizontalAlign.Center},
                new TableCell {Text = total, HorizontalAlign = HorizontalAlign.Center}
            });

            gCart.Controls[0].Controls.Add(row);
        }

        private int getCurrentUser(string username)
        {
            int userID = 0;

            using (
                SqlConnection connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
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

        private void getTotal()
        {
            using (
                SqlConnection connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT SUM(price * quantity) as total FROM Cart WHERE userID = @user");
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
                            totalPrice = Convert.ToDouble(reader["total"]);

                        }
                    }
                    connection.Close();
                }
                catch
                {

                }
            }
        }

        protected void txtQuantity_TextChanged(object sender, EventArgs e)
        {

            TextBox textBox = sender as TextBox;

            GridViewRow row = textBox.NamingContainer as GridViewRow;
            int rowIndex = row.RowIndex;

            var productID = gCart.Rows[rowIndex].Cells[0].Text;

            if (textBox != null)
            {
                int quantityInStock = 0;

                using (
                    SqlConnection connection =
                        new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Stock FROM Coffee WHERE Id = @productID");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@productID", productID);
                    connection.Open();
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                quantityInStock = Convert.ToInt32(reader["Stock"]);

                            }
                        }
                        connection.Close();
                    }
                    catch
                    {

                    }
                }

                int changedQuantity = Convert.ToInt32(textBox.Text);

                if (quantityInStock < changedQuantity)
                {

                    notifyText.InnerText = "Selected quantity is too high. We only have " + quantityInStock +
                                           " in stock!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openCartModal();", true);
                }

                else
                {
                    using (
                        SqlConnection connection =
                            new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                    {
                        SqlCommand cmd =
                            new SqlCommand(
                                "UPDATE Cart SET quantity = @quantity WHERE userID = @user AND productID = @productID");
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("@quantity", changedQuantity);
                        cmd.Parameters.AddWithValue("@user", userID);
                        cmd.Parameters.AddWithValue("@productID", productID);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                    Server.TransferRequest(Request.Url.AbsolutePath, false);
                }
            }

        }


        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {
            int productID = Convert.ToInt32(gCart.SelectedRow.Cells[0].Text);

            using (
                SqlConnection connection =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
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
            //SqlDataSource1.DataBind();
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectCommand =
                "SELECT [productID], [product], COUNT(quantity) as quantity,[price], SUM(quantity*price) as total FROM Cart WHERE userID = @userID GROUP BY productID, quantity, product, price";
            SqlDataSource1.SelectParameters.Add("userID", userID.ToString());
            //gCart.DataBind();
        }

        protected void btnOK_OnClick(object sender, EventArgs e)
        {
            Server.TransferRequest(Request.Url.AbsolutePath, false);
        }
    }
}