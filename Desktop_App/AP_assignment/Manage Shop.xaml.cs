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
using Microsoft.Win32;
using System.Diagnostics;
using System.ComponentModel;

namespace AP_assignment
{
    public partial class Manage_Shop : MetroWindow
    {
        dataBaseConnection database = new dataBaseConnection();//for filter queries
        dataBaseConnection2 database2 = new dataBaseConnection2();//for updating and deleting
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public int currentIndex = -1;

        public Manage_Shop()
        {
            InitializeComponent();
            loadUser();
            loadAllProducts();

            dispatcherTimer.Tick += new EventHandler(OnTimedEvent);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        public void OnTimedEvent(object sender, EventArgs e)
        {
            var data = database.parameters();
            dgCoffee.ItemsSource = data.Tables[0].DefaultView;

            moveSelection();
        }
        public void moveSelection()
        {
            try
            {
                if (currentIndex != -1)
                {
                    dgCoffee.ScrollIntoView(dgCoffee.Items[currentIndex]);
                    DataGridRow row = (DataGridRow)dgCoffee.ItemContainerGenerator.ContainerFromIndex(currentIndex);
                    TextBlock cellContent = dgCoffee.Columns[1].GetCellContent(row) as TextBlock;

                    object item = dgCoffee.Items[currentIndex];
                    dgCoffee.SelectedItem = item;
                    dgCoffee.ScrollIntoView(item);
                }
            }
            catch
            {

            }
            
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

        private void loadAllProducts()
        {
            string sqlAllJobs = "SELECT Id, Name, Strength, Grind, Origin, Available_Quantity, Picture, Description FROM Coffee";

            var cmd = database.dataConnection(sqlAllJobs);           
            var data = database.parameters();

            dgCoffee.ItemsSource = data.Tables[0].DefaultView;
        }

        void addPicture(object sender, RoutedEventArgs e)
        {
            string filepath;
            dispatcherTimer.Stop();

            OpenFileDialog open = new OpenFileDialog();
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            bool? result = open.ShowDialog();

            if (result == true)
            {
                try
                {
                    filepath = open.FileName;
                    ImageSource imgsource = new BitmapImage(new Uri(filepath));
                    String appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

                    string filename = System.IO.Path.GetFileName(open.FileName);
                    string foldername = "Resources";

                    DataRowView dataRow = (DataRowView)dgCoffee.SelectedItem;
                    int coffeeID = Convert.ToInt32(dataRow["Id"]);

                    string resourcePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(appStartPath, @"..\..\..\"));
                    appStartPath = String.Format(resourcePath + "\\{0}\\" + filename, foldername);

                    File.Copy(filepath, appStartPath, true);

                    string sqlUpdateField = "UPDATE Coffee SET Picture = @newValue WHERE Id = @coffeeID";

                    var cmd = database2.dataConnection(sqlUpdateField);
                    cmd.Parameters.AddWithValue("@newValue", OleDbType.VarChar).Value = appStartPath;
                    cmd.Parameters.AddWithValue("@coffeeID", OleDbType.VarChar).Value = coffeeID;

                    var data = database2.parameters();
                }

                catch
                {
                    MessageBox.Show("Error while uploading the file! Please try again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
               

            }
            dispatcherTimer.Start();
        }

        private void dgJobs_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                TextBox t = e.EditingElement as TextBox;

                DataRowView dataRow = (DataRowView)dgCoffee.SelectedItem;
                string columnName = e.Column.Header.ToString();

                if (columnName == "Available Quantity")
                {
                    columnName = "Available_Quantity";
                }
                else if (columnName == "Trigger Quantity")
                {
                    columnName = "Trigger_Quantity";
                }

                var newValue = t.Text;
                var prevValue = dataRow[columnName];

                MessageBoxResult result = MessageBox.Show("Are you sure you wish to update this information?" + "\n" + "\nYou are about to make change to " + columnName + "\n" + "\nCurrent value: "+ prevValue + "\nNew value: " + newValue, "Edit information", MessageBoxButton.YesNo, MessageBoxImage.Warning);                
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        
                       
                        int coffeeID = Convert.ToInt32(dataRow["Id"]);

                        string sqlUpdateField = "UPDATE Coffee SET " + columnName + " = @newValue WHERE Id = @coffeeID";

                        var cmd = database2.dataConnection(sqlUpdateField);
                        cmd.Parameters.AddWithValue("@newValue", OleDbType.VarChar).Value = newValue;
                        cmd.Parameters.AddWithValue("@coffeeID", OleDbType.VarChar).Value = coffeeID;

                        string newRecord = "Stock updated: " + coffeeID + ", Changed: " + prevValue + ", To: " + newValue +"<br>";

                        using (StreamWriter writer = new StreamWriter(@"..\..\..\log.txt", true))
                         {
                            writer.WriteLine(newRecord);
                         }

                        var data = database2.parameters();
                        dispatcherTimer.Start();
                        break;
                    case MessageBoxResult.No:                       
                        TextBox tj = e.EditingElement as TextBox;
                        tj.Text = prevValue.ToString();
                        break;
                }                
            }

            catch
            {
                MessageBox.Show("Error occured while editing value!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgJobs_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //if (e.Column.Header.ToString() == "Available_Quantity")
            //{
            //    e.Column.IsReadOnly = true; // Makes the column as read only
            //}

            PropertyDescriptor propertyDescriptor = (PropertyDescriptor)e.PropertyDescriptor;
            e.Column.Header = propertyDescriptor.DisplayName;
            if (propertyDescriptor.DisplayName == "Picture")
            {
                e.Cancel = true;
            }

            if (e.PropertyName.StartsWith("Available_Quantity"))
            {
                e.Column.Header = "Available Quantity";
            }
            else if (e.PropertyName.StartsWith("Trigger_Quantity"))
            {
                e.Column.Header = "Trigger Quantity";
            }          
        }
        

        private void dgJobs_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                DataRowView dataRow = (DataRowView)dgCoffee.SelectedItem; 

                int coffeeID = 0;
                string coffeeName = "";
                string coffeeStrength = "";
                string coffeeGrind = "";
                string coffeeOrigin = "";

              
                coffeeID = Convert.ToInt32(dataRow["Id"]);
                coffeeName = Convert.ToString(dataRow["Name"]);
                coffeeStrength = Convert.ToString(dataRow["Strength"]);
                coffeeGrind = Convert.ToString(dataRow["Grind"]);
                coffeeOrigin = Convert.ToString(dataRow["Origin"]);

                var result = MessageBox.Show("Are you sure you wish to delete this product?" + "\n" + "\nProduct ID: " + coffeeID + "\nName: " + coffeeName + "\nOrigin: " + coffeeOrigin, "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                switch (result)
                {
                    case MessageBoxResult.Yes:                                          

                        string sqlDelete = "DELETE FROM Coffee WHERE Id = @coffeeID";

                        var cmd = database2.dataConnection(sqlDelete);
                        cmd.Parameters.AddWithValue("@coffeeID", OleDbType.VarChar).Value = coffeeID;

                        string deleteProduct = "Deleted Product: " + coffeeID + "," + coffeeName + "," +coffeeStrength+ "," + coffeeGrind + "," + coffeeOrigin + "<br>";

                        using (StreamWriter writer = new StreamWriter(@"..\..\..\log.txt", true))
                        {
                           writer.WriteLine(deleteProduct);
                        }

                        var data = database2.parameters();
                        e.Handled = false;
                        break;
                    case MessageBoxResult.No:
                        e.Handled = true;
                        break;
                }            
            }
        }

        private void txtSearchQuery_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = txtSearchQuery.Text;
            string sqlSearchStaff = "SELECT  Id, Name, Strength, Grind, Origin, Available_Quantity, Picture, Description FROM Coffee WHERE Name LIKE @search OR Strength LIKE @search OR Grind LIKE @search OR Origin LIKE @search OR Description LIKE @search";

            var cmd = database.dataConnection(sqlSearchStaff);
            cmd.Parameters.AddWithValue("@search", OleDbType.VarChar).Value = "%" + search + "%";
            var data = database.parameters();

            dgCoffee.ItemsSource = data.Tables[0].DefaultView;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            loadAllProducts();
        }

        private void dgJobs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgCoffee.SelectedIndex != -1)
            {
                currentIndex = dgCoffee.SelectedIndex;
            } 
        }

        private void dgJobs_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            dispatcherTimer.Stop();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            AddNewProduct newProduct = new AddNewProduct();
            newProduct.Show();
            this.Close();
        }
    }
}
