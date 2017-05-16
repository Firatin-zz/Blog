using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BlogApp.Models.ORM.Entity
{
    public class Gmail
    {
        public static void SendMail(string body)
        {
            var fromAddress = new MailAddress("sevvgi.yilmaz@gmail.com", "Geri Bildirim");
            var toAddress = new MailAddress("sevvgi.yilmaz@gmail.com");
            const string subject = "Bildirim";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "sevgi+47")

            };

            using (var message = new MailMessage(fromAddress, toAddress) { Subject = subject, Body = body })
            {
                smtp.Send(message);
            }
        }
    }
}