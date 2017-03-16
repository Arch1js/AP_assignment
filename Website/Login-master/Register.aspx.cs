using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Coffee_Shop
{
    public partial class Register : System.Web.UI.Page
    {
        encryptPassword encrypt = new encryptPassword();

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string password = encrypt.sha256_hash(Password.Text);

            try
            {
                string role = "user";
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Users (username, password, role, secQuestion, secAnswer) VALUES (@username, @password, @role, @question, @answer)");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@username", Email.Text);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@role", role);
                    cmd.Parameters.AddWithValue("@question", secQuestion.SelectedValue);
                    cmd.Parameters.AddWithValue("@answer", secAnswer.Text);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                MessageText.Text = "Successfuly registered!";
                statusMessage.Visible = true;

            }
            catch
            {
                MessageText.Text = "Something went wrong!";
                statusMessage.Visible = true;
            }
        }

    }
}