using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;

namespace Coffee_Shop
{
    public partial class Members : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["FileName"] != null)
            {
                try
                {
                    string filePath = @"C:\Users\adobr\Desktop\Assignment\Resources\";
                    string filename = Request.QueryString["FileName"];
                    string contenttype = "image/" +
                    Path.GetExtension(Request.QueryString["FileName"].Replace(".", ""));
                    FileStream fis = new FileStream(filename,
                    FileMode.Open, FileAccess.Read);
                    BinaryReader binread = new BinaryReader(fis);
                    Byte[] bytes = binread.ReadBytes((Int32)fis.Length);
                    binread.Close();
                    fis.Close();
                    Response.Buffer = true;
                    Response.Charset = "";
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.ContentType = contenttype;
                    Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                    Response.BinaryWrite(bytes);
                    Response.Flush();
                    Response.End();
                }
                catch
                {
                }
            }
            if (!this.IsPostBack)
            {
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect("~/Login.aspx");
                }
            }

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = GridView1.SelectedRow.Cells[1].Text;
            Label1.Text = selectedValue;
        }

    }
}