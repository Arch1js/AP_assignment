using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Timers;

namespace AP_assignment
{
    public partial class dashboard : MetroWindow
    {
        dataBaseConnection database = new dataBaseConnection();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public dashboard()
        {
            InitializeComponent();
            loadUser();

            dispatcherTimer.Tick += new EventHandler(Grid_Loaded);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
        }

        public void loadUser()
        {
            //string username = Application.Current.Properties["sessionUsername"].ToString();

            //string user = "Welcome, " + username;
            //cmbUser.SetValue(TextBoxHelper.WatermarkProperty, user);
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            Login loginWindow = new Login();
            this.Close();
            loginWindow.Show();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            //Technician_Dispatch dispatch = new Technician_Dispatch();
            //dispatch.Show();
            //this.Close();
        }

        private void loadOrdersByStatus()
        {
            string sqlStatus = "SELECT status FROM Orders WHERE status = 'order placed'";
            string sqlStatus2 = "SELECT status FROM Orders WHERE status = 'shipped'";

            var cmd = database.dataConnection(sqlStatus);
            var statCount = database.parameters();

            var cmd2 = database.dataConnection(sqlStatus2);
            var statCount2 = database.parameters();

            string jobData = "";

            string headerData = "<!-- saved from url=(0014)about:internet -->\x0D\x0A<!doctype html><html><head><meta http-equiv='X-UA-Compatible' content='IE=9' charset='UTF-8'><style> #Firstchart_div {display: inline-block; margin: 20px} #Secondchart_div {display: inline-block; margin: 20px}</style><script type='text/javascript' src='https://www.google.com/jsapi'></script>";
            headerData += "<script type='text/javascript'>google.load('visualization', '1', {'packages':['corechart']});google.setOnLoadCallback(drawChart);google.setOnLoadCallback(drawChart2);";
            headerData += "function drawChart() {var data = new google.visualization.DataTable(); data.addColumn('string', 'Orders placed');data.addColumn('number', 'Orders shipped'); data.addRows([";
            File.AppendAllText(@"dashboard.html", headerData);

            string title = "Orders placed";
            string title2 = "Orders shipped";

            jobData = jobData + "['" + title + "', " + statCount.Tables[0].Rows.Count + "],";
            jobData = jobData + "['" + title2 + "', " + statCount2.Tables[0].Rows.Count + "],";

            jobData = jobData.TrimEnd(',');
            File.AppendAllText(@"dashboard.html", jobData);

            string footerData = "]);var options = {'title':'Incomming order status','width':550,'height':350, 'titleTextStyle': {'fontSize': 20,fontName: 'Calibri'}};var chart = new google.visualization.PieChart(document.getElementById('Firstchart_div'));chart.draw(data, options);}";
            File.AppendAllText(@"dashboard.html", footerData);


        }

        public void loadOrdersByDay()
        {
            string sqlStatus = "SELECT count(*) as orderCount, CAST(orderDate AS DATE) AS orderDate FROM Orders WHERE orderDate BETWEEN @from AND @to GROUP BY CAST(orderDate AS DATE)";

            var dateTo = DateTime.Today;

            DateTime dateFrom = Convert.ToDateTime(dateTo.AddDays(-7).ToString("dd/MM/yyyy"));

            var cmd = database.dataConnection(sqlStatus);
            cmd.Parameters.AddWithValue("@from", OleDbType.Date).Value = dateFrom;
            cmd.Parameters.AddWithValue("@to", OleDbType.Date).Value = dateTo;

            var ordersByDay = database.parameters();

            string availabilityData = "";

            string headerData = "";
            headerData += "function drawChart2() {var data = new google.visualization.DataTable(); data.addColumn('string', 'Orders');data.addColumn('number', 'Orders'); data.addRows([";
            File.AppendAllText(@"dashboard.html", headerData);

            int count = ordersByDay.Tables[0].Rows.Count;

            for (var i = 0; i < count; i++)
            {
                DateTime jobDate = Convert.ToDateTime(ordersByDay.Tables[0].Rows[i]["orderDate"]);
                string jobDateNormalized = jobDate.ToString("dd/MM/yyyy");
                int jobCount = Convert.ToInt32(ordersByDay.Tables[0].Rows[i]["orderCount"]);

                availabilityData = availabilityData + "[" + "'" + jobDateNormalized + "'" + "," + jobCount + "],";
            }

            availabilityData = availabilityData.TrimEnd(',');
            File.AppendAllText(@"dashboard.html", availabilityData);

            string footerData = "]);var options = {'title':'Orders in past week','width':550,'height':350, vAxis: {title: 'Number of Orders'}, 'titleTextStyle': {'fontSize': 20, fontName: 'Calibri'}};var chart = new google.visualization.ColumnChart(document.getElementById('Secondchart_div'));chart.draw(data, options);}";
            //File.AppendAllText(@"dashboard.html", footerData);

            footerData += "</script></head><body><div id='Firstchart_div'></div><div id='Secondchart_div'></div></body></html>";
            File.AppendAllText(@"dashboard.html", footerData);

        }

        public void Grid_Loaded(object sender, EventArgs e)
        {
           File.Delete(@"dashboard.html");

           loadOrdersByStatus();
            loadOrdersByDay();
           

           string curDir = Directory.GetCurrentDirectory();

           Uri uri = new Uri(String.Format("file:///{0}/dashboard.html", curDir));
           reportBrowser.Navigate(uri);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Shop main = new Shop();
            main.Show();
            this.Close();
        }
    }
}
