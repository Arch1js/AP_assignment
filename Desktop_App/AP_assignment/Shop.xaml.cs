using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
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
    public partial class Shop : MetroWindow
    {
        public Shop()
        {
            InitializeComponent();
            loadUser();
        }

        private void btnManage_Click(object sender, RoutedEventArgs e)
        {
            Manage_Shop manage = new Manage_Shop();
            this.Close();
            manage.Show();
        }

        public void loadUser()
        {
            string username = Application.Current.Properties["sessionUsername"].ToString();

            string user = "Welcome, " + username;
            cmbUser.SetValue(TextBoxHelper.WatermarkProperty, user);
        }

        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e) //logout
        {
            Login loginWindow = new Login();
            this.Close();
            loginWindow.Show();
        }

        private void btnWebsite_Click(object sender, RoutedEventArgs e)
        {
            manageShopPage defaultPage = new manageShopPage();
            this.Close();
            defaultPage.Show();
        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            Shop main = new Shop();
            this.Close();
            main.Show();
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
            dashboard metrics = new dashboard();
            metrics.Show();
            this.Close();
        }
    }
}
