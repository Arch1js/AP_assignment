using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AP_assignment
{
    class notifications
    {
        
        dataBaseConnection database = new dataBaseConnection();
        public void checkStockChange(int coffeeID)
        {
            string sqlStock = "SELECT Id, Name, Stock, Trigger_Quantity FROM Coffee WHERE Id = @ID";
            var cmd = database.dataConnection(sqlStock);
            cmd.Parameters.AddWithValue("@ID", OleDbType.VarChar).Value = coffeeID;

            var data = database.parameters();
            int coffee = Convert.ToInt32(data.Tables[0].Rows[0].ItemArray[0]);
            string coffeeName = data.Tables[0].Rows[0].ItemArray[1].ToString();
            int stock = Convert.ToInt32(data.Tables[0].Rows[0].ItemArray[2]);
            int trigger = Convert.ToInt32(data.Tables[0].Rows[0].ItemArray[3]);

            if(stock > trigger)
            {
                string sqlNotifications = "SELECT userID FROM Notifications WHERE productID = @ID";
                var cmd2 = database.dataConnection(sqlNotifications);
                cmd2.Parameters.AddWithValue("@ID", OleDbType.VarChar).Value = coffeeID;

                var data2 = database.parameters();
                int userID = Convert.ToInt32(data2.Tables[0].Rows[0].ItemArray[0]);

                string sqlUser = "SELECT username FROM Users WHERE userID = @ID";
                var cmd3 = database.dataConnection(sqlUser);
                cmd3.Parameters.AddWithValue("@ID", OleDbType.VarChar).Value = userID;

                var data3 = database.parameters();
                string userEmail = data3.Tables[0].Rows[0].ItemArray[0].ToString();

                sendEmailNotification(userEmail, coffeeName);
            }

        }

        private void sendEmailNotification(string email, string coffee) //send email notification to users 
        {
            MailMessage mail = new MailMessage();

            NetworkCredential cred = new NetworkCredential("SDIAF1415@gmail.com", "Software1415");

            mail.To.Add(email);
            mail.Subject = "Back in stock!";

            mail.From = new MailAddress("SDIAF1415@gmail.com");
            mail.IsBodyHtml = true;
            mail.Body = "Just letting you know that " + coffee + " is back in stock :)";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = cred;
            smtp.Port = 587;
            smtp.Send(mail);
        }
    }
}
