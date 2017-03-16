using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Coffee_Shop.Users
{
    public partial class PasswordChange : System.Web.UI.Page
    {
        encryptPassword encrypt = new encryptPassword();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {           
            var currentUser = HttpContext.Current.User.Identity.Name;
            string passwordInDB = null;
            string newPassword = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    SqlCommand cmd = new SqlCommand("SELECT password FROM Users WHERE username = @username");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;

                    cmd.Parameters.AddWithValue("@username", currentUser);
                    connection.Open();
                    try
                    {

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                passwordInDB = Convert.ToString(reader["password"]);
                            
                            }
                        }
                        connection.Close();

                        string oldPassword = encrypt.sha256_hash(Old.Text);
                        newPassword = encrypt.sha256_hash(ConfirmPassword.Text);

                        if (oldPassword == passwordInDB)
                        {
                            SqlCommand cmd2 = new SqlCommand("UPDATE Users SET password = @newPassword WHERE username = @username");
                            cmd2.CommandType = CommandType.Text;
                            cmd2.Connection = connection;
                            cmd2.Parameters.AddWithValue("@newPassword", newPassword);
                            cmd2.Parameters.AddWithValue("@username", currentUser);
                            connection.Open();
                            cmd2.ExecuteNonQuery();
                            connection.Close();

                            MessageText.Text = "Successfuly changed password!";
                            statusMessage.Visible = true;
                        }
                        else
                        {
                            MessageText.Text = "Old password is invalid!";
                            statusMessage.Visible = true;
                        }
                    }
                    catch
                    {
                        MessageText.Text = "Something went wrong :(";
                        statusMessage.Visible = true;
                    }
                }               

            }
            catch
            {
                MessageText.Text = "Something went wrong!";
                statusMessage.Visible = true;
            }
        }
    }
}