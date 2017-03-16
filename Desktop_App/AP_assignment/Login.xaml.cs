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
using MahApps.Metro.Controls;
using System.Data.OleDb;


namespace AP_assignment
{
    public partial class Login : MetroWindow
    {
        dataBaseConnection database = new dataBaseConnection();
        encryptPassword encrypt = new encryptPassword();

        public Login()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        private void userLogin()
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            if (username != "" && password != "")
            {

                var enteredPassword = encrypt.sha256_hash(password);

                try
                {
                    string sql = "SELECT username, password FROM Users WHERE username= @username AND password= @password";
                    var cmd = database.dataConnection(sql);

                    cmd.Parameters.Add("@username", OleDbType.VarChar).Value = username;
                    cmd.Parameters.Add("@password", OleDbType.VarChar).Value = enteredPassword;
                    var data = database.parameters();

                    var userUsername = data.Tables[0].Rows[0]["username"].ToString();
                    var userPassword = data.Tables[0].Rows[0]["password"].ToString();


                    if (username == userUsername && enteredPassword == userPassword)
                    {

                        Application.Current.Properties["sessionUsername"] = userUsername;

                        Manage_Shop manage = new Manage_Shop();
                        manage.Show();
                        this.Close();                                       
                    }

                    else
                    {
                        MessageBox.Show("Failed to LogIn!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch
                {
                    MessageBox.Show("Wrong username/password. Please try again!", "Login", MessageBoxButton.OK, MessageBoxImage.Error);
                    txtPassword.Password = "";
                }

            }
            else
            {
                txtUsername.BorderBrush = Brushes.Red;
                txtPassword.BorderBrush = Brushes.Red;
                MessageBox.Show("Username and Password required!", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
            }   
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            userLogin();
        }

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                userLogin();
            }
        }

    }
}
