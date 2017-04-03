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

            getTotal();

            GridViewRow row = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Normal);
            row.BackColor = ColorTranslator.FromHtml("#F9F9F9");
            row.Cells.AddRange(new TableCell[5] { new TableCell (), //Empty Cell
                new TableCell (),
                new TableCell (),
                new TableCell { Text = "Subtotal:", HorizontalAlign = HorizontalAlign.Center},
                new TableCell { Text = totalPrice.ToString(), HorizontalAlign = HorizontalAlign.Center}});

            gCart.Controls[0].Controls.Add(row);
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

        private void getTotal()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT SUM(total) as total FROM Cart WHERE userID = @user");
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
            //need to get price and item id to update cart values

            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                int changedQuantity = Convert.ToInt32(textBox.Text);


            }

        }
    }
}