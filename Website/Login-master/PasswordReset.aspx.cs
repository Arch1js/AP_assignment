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
    public partial class PasswordReset : System.Web.UI.Page
    {
        encryptPassword encrypt = new encryptPassword();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            string sequrityAnswer = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    SqlCommand cmd = new SqlCommand("SELECT secAnswer FROM Users WHERE username = @username");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@username", Email.Text);
                    connection.Open();
                    try
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                sequrityAnswer = Convert.ToString(reader["secAnswer"]);
                            }
                        }
                        connection.Close();

                        string newPassword = encrypt.sha256_hash(ConfirmPassword.Text);

                        if (secAnswer.Text == sequrityAnswer)
                        {
                            SqlCommand cmd2 = new SqlCommand("UPDATE Users SET password = @newPassword WHERE username = @username");
                            cmd2.CommandType = CommandType.Text;
                            cmd2.Connection = connection;
                            cmd2.Parameters.AddWithValue("@newPassword", newPassword);
                            cmd2.Parameters.AddWithValue("@username", Email.Text);
                            connection.Open();
                            cmd2.ExecuteNonQuery();
                            connection.Close();

                            MessageText.Text = "Password is successfully reset!";
                            statusMessage.Visible = true;
                            notifyText.InnerText = "Your password is successfully reset!";

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openResetModal();", true);
                        }
                        else
                        {
                            MessageText.Text = "Security answer is incorrect!";
                            statusMessage.Visible = true;
                            notifyText.InnerText = "Security answer is incorrect!";

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openResetModal();", true);
                        }
                    }
                    catch
                    {
                        MessageText.Text = "Unable to reset your password :(";
                        statusMessage.Visible = true;
                        notifyText.InnerText = "Ooops, something went wrong. Please try again!";

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openResetModal();", true);
                    }
                }
            }
            catch
            {
                MessageText.Text = "Something went wrong! Please try again!";
                statusMessage.Visible = true;
            }

        }
    }
}