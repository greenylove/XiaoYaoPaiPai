using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.UI;
using System.Configuration;
using System.Diagnostics;
using System.Text;

namespace CMSEmergencySystem.Email
{
    public class EmailJob : IJob

    {
     
            public void Execute(IJobExecutionContext context)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.From =
                new MailAddress(ConfigurationManager.AppSettings["FromMail"]); // sender address in web config
                mailMessage.Subject = "CMS Report";
                //mailMessage.Body = "Your message ";


              
                mailMessage.Body = "View Incident Records <a href=\"http://localhost:26909/Email/EmailData.aspx\"> Click Here! </a>";

                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress("ngyaosheng92@gmail.com")); // send to who?
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = ConfigurationManager.AppSettings["FromMail"];
                NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                smtp.EnableSsl = true;
                smtp.Send(mailMessage);
            }
        }
    }
 }

    
