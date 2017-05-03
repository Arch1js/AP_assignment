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
using System.Globalization;

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

        private void BindItemsList() //bind data to datalist and do paging
        {
            DataSourceSelectArguments args = new DataSourceSelectArguments();
            DataView view = (DataView)SqlDataSource1.Select(args);
            DataTable dataTable = view.ToTable();
            _PageDataSource.DataSource = dataTable.DefaultView;
       
            _PageDataSource.AllowPaging = true;
            _PageDataSource.PageSize = 12;
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

        private void doPaging() //split data in to pages
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

                SqlDataSource1.SelectCommand = "SELECT [Id],[Name], [Strength], [Grind], [Origin], [Stock], [Picture], [Price], [Description] FROM [Coffee] ORDER BY Origin ASC";

                if (!IsPostBack)
                {
                    this.BindItemsList();
                }

                if (Request.QueryString["FileName"] != null) //bind pictures relative path to its resource location
                {
                    try //needed in order to access resources outside the project folder
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

            protected void Timer1_Tick(object sender, EventArgs e) //refresh data timer
            {

            if(searchText.Value != "")
            {
                string selected = sortBy.SelectedValue;
                string search = searchText.Value;
                sortCoffee(selected);
            }
            else
            {
                string selected = sortBy.SelectedValue;
                sortCoffee(selected);
            }
        }

        protected void searchValue(object sender, EventArgs e) //search coffee
        {
            string selected = sortBy.SelectedValue;
            sortCoffee(selected);
        }

        protected void dlProducts_ItemCommand(object source, DataListCommandEventArgs e)//on item click
        {
            var btnValue = e.CommandArgument.ToString();
            dlProducts.SelectedIndex = e.Item.ItemIndex;
           
            var selectedValue = ((Label)dlProducts.SelectedItem.FindControl("NameLabel")).Text;
            var productID = ((Label)dlProducts.SelectedItem.FindControl("ProductID")).Text;
            var priceWithCurrency = ((Label)dlProducts.SelectedItem.FindControl("PriceLabel")).Text;
            var price = double.Parse(priceWithCurrency, NumberStyles.Currency);

            double total = 1 * Convert.ToDouble(price);
            int productIDCart = 0;

            if (btnValue == "cart") //if clicked button is cart, add item to basket
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

                if(productIDCart == Convert.ToInt32(productID))//if the same product is already in basket, update the quantity
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
                else //if not, add new product to basket
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
            else if(btnValue == "email") //if clicked button is email, save this user to notification list
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


        protected void dlProducts_OnItemDataBound(object sender, DataListItemEventArgs e) //on data bound event, check if available quntity is more than 0
        {
            Label quantity = e.Item.FindControl("lblStock") as Label;
            LinkButton cart = e.Item.FindControl("btnCart") as LinkButton;
            LinkButton notify = e.Item.FindControl("btnNotify") as LinkButton;

            try
            {
                if (Convert.ToInt32(quantity.Text) == 0)
                {
                    cart.Visible = false;
                    notify.Visible = true;
                    quantity.Text = "Out Of Stock";
                    quantity.ForeColor = Color.Red;
                }
            }
            catch
            {

            }               
        }

        protected void btnNotify_OnClick(object sender, EventArgs e) //open notification modal dialog
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

            sortCoffee(selected);
        }

        private void sortCoffee(string selection) //apply all the search and sort parameters
        {
            string search = searchText.Value;

            if(search == "")
            {
                if (selection == "Origin")
                {
                    SqlDataSource1.SelectParameters.Clear();                    
                    SqlDataSource1.SelectCommand = "SELECT Id, Name, Strength, Grind, Origin, Stock, Picture, Price, Description FROM Coffee ORDER BY Origin ASC";

                    SqlDataSource1.DataBind();
                }
                else if (selection == "Strength")
                {
                    SqlDataSource1.SelectParameters.Clear();
                    SqlDataSource1.SelectCommand = "SELECT Id, Name, Strength, Grind, Origin, Stock, Picture, Price, Description FROM Coffee ORDER BY Strength ASC";
                   
                    SqlDataSource1.DataBind();
                }
            }
            else
            {
                if (selection == "Origin")
                {
                    SqlDataSource1.SelectParameters.Clear();
                    SqlDataSource1.SelectCommand = "SELECT Id, Name, Strength, Grind, Origin, Stock, Picture, Price, Description FROM Coffee WHERE Name LIKE @search OR Origin LIKE @search OR Grind LIKE @search OR Strength LIKE @search OR Stock LIKE @search ORDER BY Origin ASC";
                    SqlDataSource1.SelectParameters.Add("search", "%" + search + "%");

                    SqlDataSource1.DataBind();
                }
                else if (selection == "Strength")
                {
                    SqlDataSource1.SelectParameters.Clear();
                    SqlDataSource1.SelectCommand = "SELECT Id, Name, Strength, Grind, Origin, Stock, Picture, Price, Description FROM Coffee WHERE Name LIKE @search OR Origin LIKE @search OR Grind LIKE @search OR Strength LIKE @search OR Stock LIKE @search ORDER BY Strength ASC";
                    SqlDataSource1.SelectParameters.Add("search", "%" + search + "%");
                    SqlDataSource1.DataBind();
                }
            }
            
            dlProducts.DataBind();
            BindItemsList();
        }

        protected void btn_Advanced_Click(object sender, EventArgs e) //show advanced search panel
        {
            advanced_panel.Visible = true;
        }

        protected void advancedSearch_Click(object sender, EventArgs e) //sort data by advanced search parameters
        {
            Timer1.Enabled = false;
            string sortSelected = advancedDropdown.SelectedValue;
            string from = txtFrom.Text;
            string to = txtTo.Text;

            SqlDataSource1.SelectParameters.Clear();
            if (sortSelected == "Price")
            {
                if (from == "")
                {                   
                    SqlDataSource1.SelectCommand = "SELECT Id, Name, Strength, Grind, Origin, Stock, Picture, Price, Description FROM Coffee WHERE Price BETWEEN (SELECT MIN(Price) FROM Coffee) AND @to ORDER BY Price ASC";
                    SqlDataSource1.SelectParameters.Add("to", to);
                }

                else if (to == "")
                {
                    SqlDataSource1.SelectCommand = "SELECT Id, Name, Strength, Grind, Origin, Stock, Picture, Price, Description FROM Coffee WHERE Price BETWEEN @from AND (SELECT MAX(Price) FROM Coffee) ORDER BY Price ASC";
                    SqlDataSource1.SelectParameters.Add("from", from);
                }

                else
                {
                    SqlDataSource1.SelectCommand = "SELECT Id, Name, Strength, Grind, Origin, Stock, Picture, Price, Description FROM Coffee WHERE Price BETWEEN @from AND @to ORDER BY Price ASC";
                    SqlDataSource1.SelectParameters.Add("from", from);
                    SqlDataSource1.SelectParameters.Add("to", to);
                }                           
            }
            else if(sortSelected == "Strength")
            {
                if (from == "")
                {
                    SqlDataSource1.SelectCommand = "SELECT Id, Name, Strength, Grind, Origin, Stock, Picture, Price, Description FROM Coffee WHERE Strength BETWEEN (SELECT MIN(Strength) FROM Coffee) AND @to ORDER BY Strength ASC";
                    SqlDataSource1.SelectParameters.Add("to", to);
                }

                else if (to == "")
                {
                    SqlDataSource1.SelectCommand = "SELECT Id, Name, Strength, Grind, Origin, Stock, Picture, Price, Description FROM Coffee WHERE Strength BETWEEN @from AND (SELECT MAX(Strength) FROM Coffee) ORDER BY Strength ASC";
                    SqlDataSource1.SelectParameters.Add("from", from);
                }

                else
                {
                    SqlDataSource1.SelectCommand = "SELECT Id, Name, Strength, Grind, Origin, Stock, Picture, Price, Description FROM Coffee WHERE Strength BETWEEN @from AND @to ORDER BY Strength ASC";
                    SqlDataSource1.SelectParameters.Add("from", from);
                    SqlDataSource1.SelectParameters.Add("to", to);
                }               

            }

            SqlDataSource1.DataBind();
            dlProducts.DataBind();
            BindItemsList();
        }
    }
    
}