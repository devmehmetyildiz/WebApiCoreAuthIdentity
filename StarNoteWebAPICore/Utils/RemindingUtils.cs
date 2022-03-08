using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace StarNoteWebAPICore.Utils
{
    public class RemindingUtils
    {
        public RemindingUtils()
        {
            //mailsend("yildiz655@gmail.com", "123.konZek", "yildiz655@gmail.com", "test maili", "test mesajı");
        }
        public bool mailsend(string username, string pw, string client, string subject, string msg)
        {
            bool issended = false;
            try
            {              
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = true;
                string konu = subject;
                string icerik = msg;
                sc.Credentials = new NetworkCredential("starnoterapor@gmail.com", "123.konZek");
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("starnoterapor@gmail.com", "Star Note");
                mail.To.Add(client);
                mail.Subject = konu;
                mail.IsBodyHtml = true;
                mail.Body = icerik;
                sc.Send(mail);
                issended = true;               
            }
            catch (Exception)
            {

              
            }
            return issended;
        }
    }
}