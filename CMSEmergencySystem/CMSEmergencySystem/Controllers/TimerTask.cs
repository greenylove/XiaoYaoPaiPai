using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;


namespace CMSEmergencySystem.Controllers
{
    
    public class TimerTask
    {
        int sec = 1000;
        int min = 1000 * 60;
        int hour = 1000 * 60 * 60;

        DataBaseHelper myDB = new DataBaseHelper();

        public void initAllTimerTask()
        {
            initEmailTask();   
            //init more timer task
        }

        private void initEmailTask()
        {
            var timer = new System.Threading.Timer((e) =>
            {
                EmailController.SendPDFEmail();
                //EmailController.sendEmail();
            }, null, 0, 10 * sec);
        }

        // for more timer task
    }
}