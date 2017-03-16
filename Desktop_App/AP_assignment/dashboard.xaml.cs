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
            string username = Application.Current.Properties["sessionUsername"].ToString();

            string user = "Welcome, " + username;
            cmbUser.SetValue(TextBoxHelper.WatermarkProperty, user);
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

        private void loadJobsByStatus()
        {
            string sqlStatus = "SELECT status FROM jobs WHERE status = 'Waiting'";
            string sqlStatus2 = "SELECT status FROM jobs WHERE status = 'Doing'";

            var cmd = database.dataConnection(sqlStatus);
            var statCount = database.parameters();

            var cmd2 = database.dataConnection(sqlStatus2);
            var statCount2 = database.parameters();

            string jobData = "";

            string headerData = "<!-- saved from url=(0014)about:internet -->\x0D\x0A<!doctype html><html><head><meta http-equiv='X-UA-Compatible' content='IE=9' charset='UTF-8'><style> #Firstchart_div {display: inline-block; margin: 20px} #Secondchart_div {display: inline-block; margin: 20px} #Thirdchart_div {display: inline-block; margin: 20px} #Forthchart_div {display: inline-block; margin: 20px}</style><script type='text/javascript' src='https://www.google.com/jsapi'></script>";
            headerData += "<script type='text/javascript'>google.load('visualization', '1', {'packages':['corechart']});google.setOnLoadCallback(drawChart);google.setOnLoadCallback(drawChart1);google.setOnLoadCallback(drawChart2);google.setOnLoadCallback(drawChart3);";
            headerData += "function drawChart() {var data = new google.visualization.DataTable(); data.addColumn('string', 'Jobs');data.addColumn('number', 'Jobs Completed'); data.addRows([";
            File.AppendAllText(@"dashboard.html", headerData);

            string title = "Waiting";
            string title2 = "Doing";

            jobData = jobData + "['" + title + "', " + statCount.Tables[0].Rows.Count + "],";
            jobData = jobData + "['" + title2 + "', " + statCount2.Tables[0].Rows.Count + "],";

            jobData = jobData.TrimEnd(',');
            File.AppendAllText(@"dashboard.html", jobData);

            string footerData = "]);var options = {'title':'Assigned Jobs','width':400,'height':300, 'titleTextStyle': {'fontSize': 20,fontName: 'Calibri'}};var chart = new google.visualization.PieChart(document.getElementById('Firstchart_div'));chart.draw(data, options);}";
            File.AppendAllText(@"dashboard.html", footerData);

        }


        public void loadTechAvailability()
        {
            string sqlStatus = "SELECT count(status) as availableCount FROM technicians WHERE status = 'available'";
            string sqlStatus2 = "SELECT count(status) as unavailableCount FROM technicians WHERE status = 'unavailable'";
            string sqlStatus3 = "SELECT count(status) as onbreakCount FROM technicians WHERE status = 'On break'";

            var cmd = database.dataConnection(sqlStatus);
            var statusAvailable = database.parameters();

            var cmd2 = database.dataConnection(sqlStatus2);
            var statusUnavailable = database.parameters();

            var cmd3 = database.dataConnection(sqlStatus3);
            var statusOnbreak= database.parameters();

            string availabilityData = "";

            string headerData = "";
            headerData += "function drawChart1() {var data = new google.visualization.DataTable(); data.addColumn('string', 'Technicians');data.addColumn('number', 'Available');data.addColumn('number', 'Unavailable');data.addColumn('number', 'On break'); data.addRows([";
            File.AppendAllText(@"dashboard.html", headerData);

            availabilityData = availabilityData + "[" + "'Technician Status'" + "," + statusAvailable.Tables[0].Rows[0]["availableCount"] + "," + statusUnavailable.Tables[0].Rows[0]["unavailableCount"] + "," + statusOnbreak.Tables[0].Rows[0]["onbreakCount"] + "],";

            availabilityData = availabilityData.TrimEnd(',');
            File.AppendAllText(@"dashboard.html", availabilityData);

            string footerData = "]);var options = {'title':'Technician Availability','width':550,'height':300, vAxis: {title: 'Number of technicians'}, 'titleTextStyle': {'fontSize': 20, fontName: 'Calibri'}};var chart = new google.visualization.ColumnChart(document.getElementById('Secondchart_div'));chart.draw(data, options);}";
            File.AppendAllText(@"dashboard.html", footerData);

        }

        public void loadJobsDone()
        {
            string sqlStatus = "SELECT  count(*) as jobCount, DateValue(finishedDateTime) as jobDate FROM finishedJobs WHERE finishedDateTime BETWEEN @from AND @to GROUP BY DateValue(finishedDateTime)";

            var dateTo = DateTime.Today;
            //string dateToFormated = dateTo.ToString("dd/MM/yyyy"); //for some reason it doesnt take date like 02/12/2016
            string dateToFormated = "12/12/2016";
            var dateFrom = dateTo.AddDays(-17).ToString("dd/MM/yyyy");

            var cmd = database.dataConnection(sqlStatus);
            cmd.Parameters.Add("@from", OleDbType.Date).Value = "#" + dateFrom + "#";
            cmd.Parameters.Add("@to", OleDbType.Date).Value = "#" + dateToFormated + "#";
            
            var jobsByDay = database.parameters();

            string availabilityData = "";

            string headerData = "";
            headerData += "function drawChart2() {var data = new google.visualization.DataTable(); data.addColumn('string', 'Jobs Done');data.addColumn('number', 'Jobs Done'); data.addRows([";
            File.AppendAllText(@"dashboard.html", headerData);

            int count = jobsByDay.Tables[0].Rows.Count;

            for (var i = 0; i < count; i++)
            {
                DateTime jobDate = Convert.ToDateTime(jobsByDay.Tables[0].Rows[i]["jobDate"]);
                string jobDateNormalized = jobDate.ToString("dd/MM/yyyy");
                int jobCount = Convert.ToInt32(jobsByDay.Tables[0].Rows[i]["jobCount"]);

                availabilityData = availabilityData + "[" + "'" + jobDateNormalized + "'" + "," + jobCount + "],";
            }

            availabilityData = availabilityData.TrimEnd(',');
            File.AppendAllText(@"dashboard.html", availabilityData);

            string footerData = "]);var options = {'title':'Jobs done in past week','width':550,'height':300, vAxis: {title: 'Number of Jobs Done'}, 'titleTextStyle': {'fontSize': 20, fontName: 'Calibri'}};var chart = new google.visualization.ColumnChart(document.getElementById('Thirdchart_div'));chart.draw(data, options);}";
            File.AppendAllText(@"dashboard.html", footerData);

        }

        public void loadTimeTaken()
        {
            string headerData2 = "function drawChart3() {var data = new google.visualization.DataTable(); data.addColumn('string', 'Time');data.addColumn('number', 'Time');data.addColumn({type: 'string', role: 'style'}); data.addRows([";
            File.AppendAllText(@"dashboard.html", headerData2);

            string sqlTime = "SELECT submitedDateTime, finishedDateTime, DateDiff('n', submitedDateTime, finishedDateTime) AS Diff  FROM finishedJobs";

            var cmd3 = database.dataConnection(sqlTime);
            var statTime = database.parameters();

            string jobTime = "";
            string title3 = "> 10 minutes";
            string title4 = "> 30 minutes";
            string title5 = "> 60 minutes";
            string title6 = "< 60 minutes";

            int lessThenTen = 0;
            int lessThenThirty = 0;
            int lessThenHour = 0;
            int moreThenHour = 0;

            for (var i = 0; i < statTime.Tables[0].Rows.Count; i++)
            {
                int difference = Convert.ToInt32(statTime.Tables[0].Rows[i]["Diff"]);

                if (difference <= 10)
                {
                    lessThenTen++;
                }
                else if (difference > 10 && difference <= 30)
                {
                    lessThenThirty++;
                }
                else if (difference > 30 && difference <= 60)
                {
                    lessThenHour++;
                }
                else
                {
                    moreThenHour++;
                }
            }

            jobTime = jobTime + "['" + title3 + "', " + lessThenTen + "," + "'color: #ac6598'" + "],";
            jobTime = jobTime + "['" + title4 + "', " + lessThenThirty + "," + "'color: #3fb0e9'" + "],";
            jobTime = jobTime + "['" + title5 + "', " + lessThenHour + "," + "'color: #42c698'" + "],";
            jobTime = jobTime + "['" + title6 + "', " + moreThenHour + "," + "'color: #b87333'" + "],";

            jobTime = jobTime.TrimEnd(',');
            File.AppendAllText(@"dashboard.html", jobTime);

            string footerData2 = "]);var options = {'title':'Time taken to complete job','width':500,'height':300, hAxis: {title: 'Number of jobs'}, legend: {position: 'none'}, 'is3D': true, 'titleTextStyle': {'fontSize': 20,fontName: 'Calibri'}, 'colors': ['green', 'blue', 'red', 'yellow']};var chart = new google.visualization.BarChart(document.getElementById('Forthchart_div'));chart.draw(data, options);}";

            footerData2 += "</script></head><body><div id='Firstchart_div'></div><div id='Secondchart_div'></div><div id='Thirdchart_div'></div><div id='Forthchart_div'></div></div></body></html>";
            File.AppendAllText(@"dashboard.html", footerData2);
        }

        public void Grid_Loaded(object sender, EventArgs e)
        {
           File.Delete(@"dashboard.html");

           loadJobsByStatus();
           loadTechAvailability();
           loadJobsDone();
           loadTimeTaken();
           

           string curDir = Directory.GetCurrentDirectory();

           Uri uri = new Uri(String.Format("file:///{0}/dashboard.html", curDir));
           reportBrowser.Navigate(uri);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //reports reports = new reports();
            //reports.Show();
            //this.Close();
        }
    }
}
