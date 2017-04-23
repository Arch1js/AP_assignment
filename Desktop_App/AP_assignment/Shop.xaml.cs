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
    /// <summary>
    /// Interaction logic for Shop.xaml
    /// </summary>
    public partial class Shop : MetroWindow
    {
        public Shop()
        {
            InitializeComponent();
        }

        private void btnManage_Click(object sender, RoutedEventArgs e)
        {
            Manage_Shop manage = new Manage_Shop();
            this.Close();
            manage.Show();
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
    }
}
