using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.Security;

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
            string password = encrypt.sha256_hash(Password.Text); //encrypt password

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

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openResetModal();", true);             
            }
            catch
            {
                MessageText.Text = "Something went wrong!";
                statusMessage.Visible = true;
            }
        }
        private void setSession(string userRole)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Email.Text, DateTime.Now, DateTime.Now.AddMinutes(2880), true, userRole, FormsAuthentication.FormsCookiePath);
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            Response.Cookies.Add(cookie);
        }
        protected void btnOK_Click(object sender, EventArgs e)
        {
            setSession("user");
            Response.Redirect("~/Users/Shop.aspx");
        }
    }
}