using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSEmergencySystem.Controllers;
using CMSEmergencySystem.Entities;
namespace CMSEmergencySystem
{
    public partial class Default : System.Web.UI.Page
    {
        IncidentController incidentManager;
        AccountController accountManager;
        NEAController neaManager;
        NewsFeedController newsFeedManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            initAllManager();

            if (!this.IsPostBack)
            {
                initIncidentList();

                //    string incidentID = "";
                //    incidentID = Request.QueryString["ID"];

                //    DataTable CategoryTable = new DataTable();
                //    CategoryTable = myDB.getAllCategoryData();
            } // end of if post back
        } // end page load

        public void initAllManager()
        {
            accountManager = new AccountController();
            neaManager = new NEAController();
            newsFeedManager = new NewsFeedController();
            incidentManager = new IncidentController();
        }

    }//end of class
}//end of name space

