using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AP_assignment
{
    public partial class manageShopPage : MetroWindow
    {
        dataBaseConnection database = new dataBaseConnection();
        public manageShopPage()
        {           
            InitializeComponent();
            loadUser();
            getURLFromDatabase();           
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int id = Convert.ToInt32(button.Tag.ToString());

            string sqlUpdateField = "UPDATE CMS SET picture = @url, text = @text WHERE Id = @id";

            var cmd = database.dataConnection(sqlUpdateField);

            if (id == 2)
            {
                cmd.Parameters.AddWithValue("@url", OleDbType.VarChar).Value = txtImage1.Text;
                cmd.Parameters.AddWithValue("@text", OleDbType.VarChar).Value = txtTitle.Text;
            }
            else if (id == 3)
            {
                cmd.Parameters.AddWithValue("@url", OleDbType.VarChar).Value = txtImage2.Text;
                cmd.Parameters.AddWithValue("@text", OleDbType.VarChar).Value = txtTitle2.Text;
            }
            else if (id == 4)
            {
                cmd.Parameters.AddWithValue("@url", OleDbType.VarChar).Value = txtImage3.Text;
                cmd.Parameters.AddWithValue("@text", OleDbType.VarChar).Value = txtTitle3.Text;
            }

            cmd.Parameters.AddWithValue("@id", OleDbType.VarChar).Value = id;

            var data = database.parameters();

            MessageBox.Show("Carousel image updated!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

            getURLFromDatabase();
        }

        private void getURLFromDatabase()
        {
            string sqlUpdateField = "SELECT picture, text FROM CMS";

            var cmd = database.dataConnection(sqlUpdateField);

            var data = database.parameters();

            string image1 = data.Tables[0].Rows[0].ItemArray[0].ToString();
            string image2 = data.Tables[0].Rows[1].ItemArray[0].ToString();
            string image3 = data.Tables[0].Rows[2].ItemArray[0].ToString();

            string title1 = data.Tables[0].Rows[0].ItemArray[1].ToString();
            string title2 = data.Tables[0].Rows[1].ItemArray[1].ToString();
            string title3 = data.Tables[0].Rows[2].ItemArray[1].ToString();

            try
            {
                carousel1.Source = new BitmapImage(new Uri(image1));
                carousel2.Source = new BitmapImage(new Uri(image2));
                carousel3.Source = new BitmapImage(new Uri(image3));

                txtTitle.Text = title1;
                txtTitle2.Text = title2;
                txtTitle3.Text = title3;
            }
            catch
            {

            }           
        }

        private void txtImage1_TextChanged(object sender, TextChangedEventArgs e)
        {
            image.Source = new BitmapImage(new Uri(txtImage1.Text));
        }

        private void txtImage2_TextChanged(object sender, TextChangedEventArgs e)
        {
            image2.Source = new BitmapImage(new Uri(txtImage2.Text));
        }

        private void txtImage3_TextChanged(object sender, TextChangedEventArgs e)
        {
            image3.Source = new BitmapImage(new Uri(txtImage3.Text));
        }
        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Shop main = new Shop();
            this.Close();
            main.Show();

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
    }
}
