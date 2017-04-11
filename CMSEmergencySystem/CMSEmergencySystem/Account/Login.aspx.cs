using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace CMSEmergencySystem.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginUser_Click(object sender, EventArgs e)
        {
            DataBaseHelper myDB = new DataBaseHelper();

            string userName = UserName.Text;
            string userPW = Password.Text;

            DataRow userRow;
            userRow = myDB.loginUser(userName, userPW);
            int userRole = 0;

            if ((int)userRow["departmentID"] != 0)
            {

                userRole = (Int32)userRow["departmentID"];

                if (userRole == 1)
                {
                    //store the username into session["username"];
                    Session["UserName"] = userName;
                    Response.Redirect("~/Default.aspx");
                }
                if (userRole == 2)
                {
                    // CredentialDB check the user's departmentID.
                    // Response.Redirect();
                }
                if (userRole == 3)
                {
                    // Response.Redirect();
                }

            }
            else
            {
                displayError.Text = "Username or Password is wrong";
            }
        }
    }
}