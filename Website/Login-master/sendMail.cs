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
        public void sendEmailToUser(string subject, string message)
        {
            MailMessage mail = new MailMessage();
            //157Ds9lK7y6q
            NetworkCredential cred = new NetworkCredential("SDIAF1415@gmail.com", "Software1415");

            string user = HttpContext.Current.User.Identity.Name;

            mail.To.Add(user);
            mail.Subject = subject;

            mail.From = new MailAddress("SDIAF1415@gmail.com");
            mail.IsBodyHtml = true;
            mail.Body = message;

            //if (FileUpload1.HasFile)
            //{
            //    string filename = Path.GetFileName(FileUpload1.FileName);

            //    FileUpload1.SaveAs(Server.MapPath("~/images/") + filename);
            //    string filepath = Server.MapPath("~/images/") + filename;
            //    mail.Attachments.Add(new Attachment(filepath));
            //}


            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = cred;
            smtp.Port = 587;
            smtp.Send(mail);
        }

    }
}