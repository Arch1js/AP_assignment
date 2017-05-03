using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace Coffee_Shop
{
    public class sendMail
    {
        public void sendEmailToUser(string subject, string message) //sending email notifications to user
        {
            MailMessage mail = new MailMessage();
            NetworkCredential cred = new NetworkCredential("SDIAF1415@gmail.com", "Software1415");

            string user = HttpContext.Current.User.Identity.Name;
            string html = "<div><p>" + message + "</p></div>"+"<div><img id='logo' src='https://image.ibb.co/b3CimQ/Coffee_shop_logo2_png.png'/></div>";
            mail.To.Add(user);
            mail.Subject = subject;
            mail.From = new MailAddress("SDIAF1415@gmail.com");
            mail.IsBodyHtml = true;
            mail.Body = html;
            
                
            //mail.Attachments.Add(new Attachment(filepath)); //mail attachments can be added later
            
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = cred;
            smtp.Port = 587;
            smtp.Send(mail);
        }

    }
}