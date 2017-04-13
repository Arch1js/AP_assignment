using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace Coffee_Shop.Users
{
    public partial class Shop : System.Web.UI.Page
    {
        string user = "";
        public int userID = 0;

        #region Private Properties
        private int CurrentPage
        {
            get
            {
                object objPage = ViewState["_CurrentPage"];
                int _CurrentPage = 0;
                if (objPage == null)
                {
                    _CurrentPage = 0;
                }
                else
                {
                    _CurrentPage = (int)objPage;
                }
                return _CurrentPage;
            }
            set { ViewState["_CurrentPage"] = value; }
        }
        private int fistIndex
        {
            get
            {

                int _FirstIndex = 0;
                if (ViewState["_FirstIndex"] == null)
                {
                    _FirstIndex = 0;
                }
                else
                {
                    _FirstIndex = Convert.ToInt32(ViewState["_FirstIndex"]);
                }
                return _FirstIndex;
            }
            set { ViewState["_FirstIndex"] = value; }
        }
        private int lastIndex
        {
            get
            {

                int _LastIndex = 0;
                if (ViewState["_LastIndex"] == null)
                {
                    _LastIndex = 0;
                }
                else
                {
                    _LastIndex = Convert.ToInt32(ViewState["_LastIndex"]);
                }
                return _LastIndex;
            }
            set { ViewState["_LastIndex"] = value; }
        }
        #endregion

        #region PagedDataSource
        PagedDataSource _PageDataSource = new PagedDataSource();
        #endregion

        #region Private Methods

        private void BindItemsList()
        {

            //DataTable dataTable = this.GetDataTable();
            DataSourceSelectArguments args = new DataSourceSelectArguments();
            DataView view = (DataView)SqlDataSource1.Select(args);
            DataTable dataTable = view.ToTable();
            _PageDataSource.DataSource = dataTable.DefaultView;
       
            _PageDataSource.AllowPaging = true;
            _PageDataSource.PageSize = 10;
            _PageDataSource.CurrentPageIndex = CurrentPage;
            ViewState["TotalPages"] = _PageDataSource.PageCount;

            
            this.lblPageInfo.Text = "Page " + (CurrentPage + 1) + " of " + _PageDataSource.PageCount;
            this.lbtnPrevious.Enabled = !_PageDataSource.IsFirstPage;
            this.lbtnNext.Enabled = !_PageDataSource.IsLastPage;
            this.lbtnFirst.Enabled = !_PageDataSource.IsFirstPage;
            this.lbtnLast.Enabled = !_PageDataSource.IsLastPage;

            this.dlProducts.DataSource = _PageDataSource;
            this.dlProducts.DataBind();
            this.doPaging();
        }

        /// <summary>
        /// Binding Paging List
        /// </summary>
        private void doPaging()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PageIndex");
            dt.Columns.Add("PageText");

            fistIndex = CurrentPage - 5;


            if (CurrentPage > 5)
            {
                lastIndex = CurrentPage + 5;
            }
            else
            {
                lastIndex = 10;
            }
            if (lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
            {
                lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
                fistIndex = lastIndex - 10;
            }

            if (fistIndex < 0)
            {
                fistIndex = 0;
            }

            for (int i = fistIndex; i < lastIndex; i++)
            {
                DataRow dr = dt.NewRow();
                dr[0] = i;
                dr[1] = i + 1;
                dt.Rows.Add(dr);
            }
            
            this.dlPaging.DataSource = dt;
            this.dlPaging.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            user = HttpContext.Current.User.Identity.Name;
            userID = getCurrentUser(user);

            if (!IsPostBack)
            {
                this.BindItemsList();
            }

            if (Request.QueryString["FileName"] != null)
        {
            try
            {
                string filePath = @"C:\Users\adobr\Desktop\AP_assignment\Resources\";
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

            protected void lbtnNext_Click(object sender, EventArgs e)
            {

                CurrentPage += 1;
                BindItemsList();

            }
            protected void lbtnPrevious_Click(object sender, EventArgs e)
            {
                CurrentPage -= 1;
                this.BindItemsList();

            }
            protected void dlPaging_ItemCommand(object source, DataListCommandEventArgs e)
            {
                if (e.CommandName.Equals("Paging"))
                {
                    CurrentPage = Convert.ToInt16(e.CommandArgument.ToString());
                    this.BindItemsList();
                }
            }
            protected void dlPaging_ItemDataBound(object sender, DataListItemEventArgs e)
            {
                LinkButton lnkbtnPage = (LinkButton)e.Item.FindControl("lnkbtnPaging");
                if (lnkbtnPage.CommandArgument.ToString() == CurrentPage.ToString())
                {
                    lnkbtnPage.Enabled = false;
                    lnkbtnPage.Style.Add("fone-size", "14px");
                    lnkbtnPage.Font.Bold = true;

                }
            }
            protected void lbtnLast_Click(object sender, EventArgs e)
            {

                CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
                this.BindItemsList();

            }
            protected void lbtnFirst_Click(object sender, EventArgs e)
            {
                CurrentPage = 0;
                this.BindItemsList();
            }

            protected void Timer1_Tick(object sender, EventArgs e)
            {
                //dlProducts.DataBind();
            }

        protected void searchValue(object sender, EventArgs e)
        {
            SqlDataSource1.SelectCommand = "SELECT [Id],[Name], [Strength], [Grind], [Origin], [Stock], [Picture], [Price], [Description] FROM Coffee WHERE Name LIKE @search";
            SqlDataSource1.SelectParameters.Clear();
            SqlDataSource1.SelectParameters.Add("search", "%"+searchText.Value+"%");
            BindItemsList();
        }

        protected void dlProducts_ItemCommand(object source, DataListCommandEventArgs e)
        {
            var btnValue = e.CommandArgument.ToString();
            dlProducts.SelectedIndex = e.Item.ItemIndex;
           
            var selectedValue = ((Label)dlProducts.SelectedItem.FindControl("NameLabel")).Text;
            var productID = ((Label)dlProducts.SelectedItem.FindControl("ProductID")).Text;
            var price = ((Label)dlProducts.SelectedItem.FindControl("PriceLabel")).Text;
            double total = 1 * Convert.ToDouble(price);

            int productIDCart = 0;

            if (btnValue == "cart")
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {
                    SqlCommand cmd = new SqlCommand("SELECT productID FROM Cart WHERE userID = @user");
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
                                productIDCart = Convert.ToInt32(reader["productID"]);

                            }
                        }
                        connection.Close();
                    }
                    catch
                    {

                    }
                }

                if(productIDCart == Convert.ToInt32(productID))
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                    {

                        SqlCommand cmd = new SqlCommand("UPDATE Cart SET quantity = quantity+1 WHERE userID = @user AND productID = @product");
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("@user", userID);
                        cmd.Parameters.AddWithValue("@product", productID);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                    {

                        SqlCommand cmd = new SqlCommand("INSERT INTO Cart (userID, productID, product, price, quantity) VALUES (@user,@productID, @product, @price, @quantity)");
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("@user", userID);
                        cmd.Parameters.AddWithValue("@productID", productID);
                        cmd.Parameters.AddWithValue("@product", selectedValue);
                        cmd.Parameters.AddWithValue("@price", price);
                        cmd.Parameters.AddWithValue("@quantity", 1);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }

                
            }
            else if(btnValue == "email")
            {

                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
                {

                    SqlCommand cmd = new SqlCommand("INSERT INTO Notifications (productID, userID) VALUES (@productID, @user)");
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = connection;
                    cmd.Parameters.AddWithValue("@productID", productID);
                    cmd.Parameters.AddWithValue("@user", userID);                   
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
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


        protected void dlProducts_OnItemDataBound(object sender, DataListItemEventArgs e)
        {
            Label quantity = e.Item.FindControl("lblStock") as Label;
            LinkButton cart = e.Item.FindControl("btnCart") as LinkButton;
            LinkButton notify = e.Item.FindControl("btnNotify") as LinkButton;

            if (Convert.ToInt32(quantity.Text) == 0)
            {
                cart.Visible = false;
                notify.Visible = true;
                quantity.Text = "Out Of Stock";
                quantity.ForeColor = Color.Red;
            }           
        }

        protected void btnNotify_OnClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEmailModal();", true);
        }
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openCartModal();", true);
        }

        protected void sortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = (DropDownList)sender;
            string selected = (string)list.SelectedValue;

            if(selected == "Origin")
            {
                SqlDataSource1.SelectParameters.Clear();
                SqlDataSource1.SelectCommand = "SELECT Id, Name, Strength, Grind, Origin, Stock, Picture, Price, Description FROM Coffee ORDER BY Origin ASC";
                
                SqlDataSource1.DataBind();
            }
            else if (selected == "Strength")
            {
                SqlDataSource1.SelectParameters.Clear();
                SqlDataSource1.SelectCommand = "SELECT Id, Name, Strength, Grind, Origin, Stock, Picture, Price, Description FROM Coffee ORDER BY Strength ASC";
                
                SqlDataSource1.DataBind();
            }
            dlProducts.DataBind();
            BindItemsList();
        }
    }
    
}