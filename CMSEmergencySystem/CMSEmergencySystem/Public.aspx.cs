using CMSEmergencySystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSEmergencySystem
{
    public partial class Public : System.Web.UI.Page
    {
        NewsFeedController newsFeedController;
        protected void Page_Load(object sender, EventArgs e)
        {
            loadNEA();
            displayNEAInfo();
            newsFeedController = new NewsFeedController();
            RefreshFBFeed();
            RefreshTwitterFeed(url, query);
        }
    }
}