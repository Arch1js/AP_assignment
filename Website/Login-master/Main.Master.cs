﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Coffee_Shop
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected int pCount { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            getItemCount();
        }

        public void getItemCount() //get the shopping cart item count
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                string user = HttpContext.Current.User.Identity.Name;
                int userID = getCurrentUser(user);
                SqlCommand cmd = new SqlCommand("SELECT COUNT(userID) as 'itemCount' FROM Cart WHERE userID = @user");
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
                            int items = Convert.ToInt32(reader["itemCount"]);
                            badgeValue = items;
                        }
                    }
                    connection.Close();
                }
                catch
                {

                }

            }
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

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx", true);
            Session.Abandon();
        }

        public int badgeValue
        {
            get { return this.pCount; }
            set { this.pCount = value; }
        }
    }
}