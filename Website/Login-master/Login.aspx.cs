using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using System.Configuration;

namespace Coffee_Shop
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (this.Page.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Login.aspx");
                    Session.Abandon();
                }
            }
        }
        encryptPassword encrypt = new encryptPassword();

        private string role = null;
       

        protected void ValidateUser(object sender, EventArgs e)
        {
            string lookupPassword = null;
            try
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {

                    SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE username = @username");
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
                                lookupPassword = Convert.ToString(reader["password"]);
                                role = Convert.ToString(reader["role"]);
                            }
                        }
                        connection.Close();
                    }
                    catch
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("[ValidateUser] Exception " + ex.Message);
            }

            string hashedPassword = encrypt.sha256_hash(Password.Text);

            if(string.Compare(lookupPassword, hashedPassword, false) == 0)
            {
                if (role == "user")
                {
                    setSession(role);
                    Response.Redirect("~/Users/Members.aspx");
                }
                else if (role == "manager")
                {
                    setSession(role);
                    Response.Redirect("~/Manager/ManagerMain.aspx");
                }
            }
            else
            {
                FailureText.Text = "Wrong Email or Password! Please try again!";
                ErrorMessage.Visible = true;
            }         
        }

        private void setSession(string userRole)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Email.Text, DateTime.Now, DateTime.Now.AddMinutes(2880), RememberMe.Checked, userRole, FormsAuthentication.FormsCookiePath);
            string hash = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

            if (ticket.IsPersistent)
            {
                cookie.Expires = ticket.Expiration;
            }
            Response.Cookies.Add(cookie);
        }
       
    }
}