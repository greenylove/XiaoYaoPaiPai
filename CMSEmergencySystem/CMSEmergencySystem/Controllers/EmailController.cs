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
using CMSEmergencySystem.Controllers;
using System.Data;
using CMSEmergencySystem.Email;

namespace CMSEmergencySystem.Controllers
{
    public class EmailController:IJob
    {
       
            public class JobSchedule
            {
                public static void Start()
                {
                    IJobDetail emailJob = JobBuilder.Create<Controllers.EmailController>()
                          .WithIdentity("job1")
                          .Build();



                ITrigger trigger = TriggerBuilder.Create()
                    .WithDailyTimeIntervalSchedule
                      (s =>
                         s.WithIntervalInSeconds(30)
                        .OnEveryDay()
                      )
                     .ForJob(emailJob)
                     .WithIdentity("trigger1")
                     .StartNow()
                     .WithCronSchedule("0 0/1 * * * ?") // Time : Every 30 Minutes job execute
                     .Build();

                ISchedulerFactory sf = new Quartz.Impl.StdSchedulerFactory();
                IScheduler sc = sf.GetScheduler();
                sc.ScheduleJob(emailJob, trigger);
                sc.Start();
                }
            }

            public void Execute(IJobExecutionContext context)
            {
            GetExcelFile.DataTable();
            
            using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From =
                    new MailAddress(ConfigurationManager.AppSettings["FromMail"]); // sender address in web config
                    mailMessage.Subject = "CMS Report";
                    //mailMessage.Body = "Your message ";

                    //IncidentController controller = new IncidentController();


                    //DataTable Datatable1 = controller.getAllResolvedIncident();
                    //DataTable Datatable2 = controller.getAllPendingIncident();
                    //GridData.DataSource = Datatable1;
                    //GridData.DataBind();
                    //GridData2.DataSource = Datatable2;
                    //GridData2.DataBind();

                    //ViewState["DS2"] = Datatable1;
                    //ViewState["DS"] = Datatable2;








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