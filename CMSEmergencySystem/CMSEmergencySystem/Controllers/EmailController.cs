using System;
using System.Web.UI;
using System.IO;
using System.Text;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace CMSEmergencySystem.Controllers
{
    public class EmailController
    {
        public static void SendPDFEmail()
        {
            DataBaseHelper dbh = new DataBaseHelper();
            DataTable dt = dbh.getAllPendingIncident();
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //string companyName = "ASPSnippets";
                    string to = "Prime Minister's Office";
                    StringBuilder sb = new StringBuilder();
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td style='height: 100px' align='center' style='background-color: #BDC3C7' colspan = '2'><b>Crisis Management System</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>Date:  </b>");
                    sb.Append(DateTime.Now);
                    sb.Append("</td></tr><tr><td><tr><td colspan = '2'><b>To:  </b>");
                    sb.Append(to);
                    sb.Append(" </td></tr><tr></tr>");
                    sb.Append("<tr><td colspan = '2'><b>Current Crisis</b> ");
                    //sb.Append(companyName);
                    sb.Append("</td></tr>");
                    sb.Append("</table>");
                    sb.Append("<br />");
                    sb.Append("<table border = '1'>");
                    sb.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<th style = 'background-color: #BDC3C7;color:#000000'>");
                        sb.Append(column.ColumnName);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<td>");
                            sb.Append(row[column]);
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");
                    }
                    sb.Append("</table>");
                    StringReader sr = new StringReader(sb.ToString());

                    Document pdfDoc = new Document(PageSize.A3.Rotate(), 10f, 10f, 100f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, memoryStream);
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Close();
                        byte[] bytes = memoryStream.ToArray();
                        memoryStream.Close();

                        MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["FromMail"], "limjaichyi@gmail.com");
                        mm.Subject = "CMS  " + DateTime.Now;
                        mm.Body = "This is an auto-generated email provided by CMS.";
                        mm.Attachments.Add(new Attachment(new MemoryStream(bytes), "CMS  " + DateTime.Now + ".pdf"));
                        mm.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = ConfigurationManager.AppSettings["Host"];
                        // smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        NetworkCredential NetworkCred = new NetworkCredential();
                        NetworkCred.UserName = ConfigurationManager.AppSettings["FromMail"];
                        NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
                        //NetworkCred.UserName = "imtingg@gmail.com";
                        //NetworkCred.Password = "proudGrumpylion95";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(mm);
                    }
                }
            }
        }
        //public static void sendEmail()
        //{
        //    using (MailMessage mailMessage = new MailMessage())
        //    {
        //        mailMessage.From =
        //        new MailAddress(ConfigurationManager.AppSettings["FromMail"]); // sender address in web config
        //        mailMessage.Subject = "CMS Report";

        //        mailMessage.Body = "View Incident Records <a href=\"http://localhost:26909/Email/EmailData.aspx\"> Click Here! </a>";

        //        mailMessage.IsBodyHtml = true;
        //        mailMessage.To.Add(new MailAddress("limjaichyi@gmail.com")); // send to who?
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = ConfigurationManager.AppSettings["Host"];
        //        System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
        //        NetworkCred.UserName = ConfigurationManager.AppSettings["FromMail"];
        //        NetworkCred.Password = ConfigurationManager.AppSettings["Password"];
        //        smtp.UseDefaultCredentials = true;
        //        smtp.Credentials = NetworkCred;
        //        smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
        //        smtp.EnableSsl = true;
        //        smtp.Send(mailMessage);
        //    }
        //}
    }






}