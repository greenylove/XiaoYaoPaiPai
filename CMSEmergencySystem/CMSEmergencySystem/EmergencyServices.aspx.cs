using System;
using CMSEmergencySystem.Controllers;
using System.Threading;

namespace CMSEmergencySystem
{
    public partial class EmergencyServices : System.Web.UI.Page
    {
        IncidentController incidentController;
        AccountController accountController;
        NEAController neaController;
        NewsFeedController newsFeedController;

        protected void Page_Load(object sender, EventArgs e)
        {
            Thread printer = new Thread(new ThreadStart(InvokeMethod));
            printer.Start();

            RefreshFBFeed();
            RefreshTwitterFeed(url, query);

            //Load NEA API
            loadNEA();
            displayNEAInfo();
            initAllController();

            if (!this.IsPostBack)
            {
                initIncidentList();

                //    string incidentID = "";
                //    incidentID = Request.QueryString["ID"];

                //    DataTable CategoryTable = new DataTable();
                //    CategoryTable = myDB.getAllCategoryData();
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

