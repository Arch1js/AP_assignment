﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Data;
using System.Data.OleDb;
using System.Timers;
using Microsoft.Win32;
using System.IO;
using System.Diagnostics;

namespace AP_assignment
{
    public partial class AddNewProduct : MetroWindow
    {
        dataBaseConnection database = new dataBaseConnection(); //new database connection instance
        string filepath;
        string appStartPath;
        OpenFileDialog open = new OpenFileDialog();

        public AddNewProduct()
        {
            InitializeComponent();
            loadUser();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)//redirect back to home page
        {
            Manage_Shop manage = new Manage_Shop();
            manage.Show();
            this.Close();
        }

        public void loadUser()
        {
            string username = Application.Current.Properties["sessionUsername"].ToString();

            string user = "Welcome, " + username;
            cmbUser.SetValue(TextBoxHelper.WatermarkProperty, user);
        }

        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e) //logout
        {
            Login loginWindow = new Login();
            this.Close();
            loginWindow.Show();
        }
        private void txtDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblTextCount2.Content = txtDescription.Text.Length + "/200"; //change used character count
        }
        private void txtComments_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblTextCount.Content = txtComments.Text.Length + "/300";
        }

        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {           
            try
            {
                try //upload the picture
                {
                    ImageSource imgsource = new BitmapImage(new Uri(filepath));

                    appStartPath = System.IO.Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

                    string filename = System.IO.Path.GetFileName(open.FileName);
                    string foldername = "Resources";

                    string resourcePath = System.IO.Path.GetFullPath(System.IO.Path.Combine(appStartPath, @"..\..\..\..\"));
                    appStartPath = String.Format(resourcePath + "\\{0}\\" + filename, foldername);

                    File.Copy(filepath, appStartPath, true);
                }
                catch
                {
                    
                }
                string sqlUpdateField = "INSERT INTO Coffee (Name, Strength, Grind, Origin, Stock, Trigger_Quantity, Price, Picture, Description, InternalComments)" +
                "VALUES (@Name, @Strength, @Grind, @Origin, @Available_Quantity, @Trigger_Quantity, @Price, @Picture, @Description, @InternalComments)";

                var cmd = database.dataConnection(sqlUpdateField);
                cmd.Parameters.AddWithValue("@Name", OleDbType.VarChar).Value = txtName.Text;
                cmd.Parameters.AddWithValue("@Strength", OleDbType.VarChar).Value = txtStrength.Text;
                cmd.Parameters.AddWithValue("@Grind", OleDbType.VarChar).Value = txtGrind.Text;
                cmd.Parameters.AddWithValue("@Origin", OleDbType.VarChar).Value = txtOrigin.Text;
                cmd.Parameters.AddWithValue("@Available_quantity", OleDbType.VarChar).Value = txtAvailable.Text;
                cmd.Parameters.AddWithValue("@Trigger_Quantity", OleDbType.VarChar).Value = txtTrigger.Text;
                cmd.Parameters.AddWithValue("@Price", OleDbType.VarChar).Value = txtPrice.Text;
                cmd.Parameters.AddWithValue("@Picture", OleDbType.VarChar).Value = appStartPath;
                cmd.Parameters.AddWithValue("@Description", OleDbType.VarChar).Value = txtDescription.Text;
                cmd.Parameters.AddWithValue("@InternalComments", OleDbType.VarChar).Value = txtComments.Text;

                var data = database.parameters();

                MessageBox.Show("Successfuly added new product!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                Manage_Shop shop = new Manage_Shop();
                this.Close();
                shop.Show();
            }
            catch
            {
                MessageBox.Show("Error occured while adding new Product!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);                
            }
            
        }

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {                 
            open.Multiselect = false;
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png"; //allow only these file types as the upload image
            bool? result = open.ShowDialog();

            if (result == true)
            {
                filepath = open.FileName;
                imageUpload.Source = new BitmapImage(new Uri(filepath));              
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e) //clear all the textbox values
        {
            txtName.Clear();
            txtStrength.Clear();
            txtGrind.Clear();
            txtOrigin.Clear();
            txtAvailable.Clear();
            txtTrigger.Clear();
        }

    }
}
