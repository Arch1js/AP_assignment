using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;

namespace Coffee_Shop
{
    public partial class Default : System.Web.UI.Page
    {
        public string picID1 = "";
        public string picID2 = "";
        public string picID3 = "";

        public string picAlt1 = "";
        public string picAlt2 = "";
        public string picAlt3 = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("SELECT picture, text FROM CMS WHERE element = 'slider'"); //get the carousel picture URL address
                cmd.CommandType = CommandType.Text;
                cmd.Connection = connection;
                connection.Open();
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Dictionary<string, string> pictures = new Dictionary<string, string>();
                        Dictionary<string, string> alt = new Dictionary<string, string>();

                        int i = 1;
                        while (reader.Read())
                        {
                            string picURL = reader["picture"].ToString();
                            pictures.Add(String.Format("picID{0}", i.ToString()), picURL);
                            
                            string picAlt = reader["text"].ToString();
                            alt.Add(String.Format("picAlt{0}", i.ToString()), picAlt);

                            i++;
                        }

                        picID1 = pictures["picID1"]; //bind the url to element
                        picID2 = pictures["picID2"];
                        picID3 = pictures["picID3"];

                        picAlt1 = alt["picAlt1"]; //bind the picture alt information
                        picAlt2 = alt["picAlt2"];
                        picAlt3 = alt["picAlt3"];
                    }
                    connection.Close();
                }
                catch
                {

                }
            }
        }    
    }
}