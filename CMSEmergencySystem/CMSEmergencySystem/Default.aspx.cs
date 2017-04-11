using System;
using CMSEmergencySystem.Controllers;
using System.Threading;
using System.Web;

namespace CMSEmergencySystem
{
    public partial class Default : System.Web.UI.Page
    {
        IncidentController incidentController;
        AccountController accountController;
        NEAController neaController;
        NewsFeedController newsFeedController;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Facebook page authentication
            string app_id = "1677399102562906";
            string scope = "publish_actions,manage_pages";

            if (HttpContext.Current.Request["code"] == null)
            {
                HttpContext.Current.Response.Redirect(string.Format("https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}", app_id, HttpContext.Current.Request.Url.AbsoluteUri, scope));
            }

            RefreshFBFeed();
            RefreshTwitterFeed(url, query);

            //Load NEA API
            loadNEA();
            displayNEAInfo(); 
            initAllController();
            
            if (!this.IsPostBack)
            {
                initIncidentList();
            } // end of if post back
        } // end page load

        public void initAllController()
        {
            accountController = new AccountController();
            neaController = new NEAController();
            newsFeedController = new NewsFeedController();
            incidentController = new IncidentController();
        }
    }//end of class
}//end of name space

