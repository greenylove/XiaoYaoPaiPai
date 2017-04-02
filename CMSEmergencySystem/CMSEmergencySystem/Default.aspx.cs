using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMSEmergencySystem.Controllers;
using CMSEmergencySystem.DAO;
using CMSEmergencySystem.Entities;
namespace CMSEmergencySystem
{
    public partial class Default : System.Web.UI.Page
    {
        IncidentManager incidentManager;
        AccountManager accountManager;
        NEAManager neaManager;
        NewsFeedManager newsFeedManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            initAllManager();
            //FOR CREATE INCIDENT
            //DataBaseHelper myDB = new DataBaseHelper();
            //DataTable DT = new DataTable();

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
            accountManager = new AccountManager();
            neaManager = new NEAManager();
            newsFeedManager = new NewsFeedManager();
            incidentManager = new IncidentManager();
        }

        public void initIncidentList()
        {
            DataTable DT = incidentManager.getAllPendingIncident();
            DataTable DT2 = incidentManager.getAllResolvedIncident();
            GridData.DataSource = DT;
            GridData.DataBind();
            GridData2.DataSource = DT2;
            GridData2.DataBind();

            ViewState["DS2"] = DT2;
            ViewState["DS"] = DT;
        }

        /*else
        {
            DT = ViewState["DS"];
        }
        GridData.DataSource = DT;
        GridData.DataBind();*/

        //FOR CREATE INCIDENT
        protected void CreateIncidentButton(object sender, EventArgs e)
        {
            float Lat = float.Parse(LatInfo.Value);
            float Long = float.Parse(LngInfo.Value);
            int incidentID = incidentManager.createIncident(reportPersonTextBox.Text, typeOfIncidentDDL.Text,
                                locationTextBox.Text, MainDispatchDDL.Text, contactNoTextBox.Text,
                                postalCodeTextBox.Text, descriptionTextBox.Text, 0, Lat, Long);

            foreach (ListItem assistTypeCBL in assistTypeCheckBoxList.Items)
                if (assistTypeCBL.Selected == true)
                    incidentManager.addSupportType(incidentID, Convert.ToInt32(assistTypeCBL.Value));

            //update UI
            updateUIIncident();
        } // end of class

        public void updateUIIncident()
        {
            DataTable DT = incidentManager.getAllPendingIncident();
            DataTable DT2 = incidentManager.getAllResolvedIncident();
            GridData.DataSource = DT;
            GridData.DataBind();
            GridData2.DataSource = DT2;
            GridData2.DataBind();
            ViewState["DS"] = DT;
        }


        public void ViewPendingIncident_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            IncidentItem incidentItem;
            if (e.CommandName == "Select")
            {
                int index = (((Button)e.CommandSource).NamingContainer as GridViewRow).RowIndex;
                //DataTable dt = incidentManager.getAllPendingIncident();
                DataTable dt = (DataTable)ViewState["DS"];
                DataRow row = dt.Rows[index];


                DataBaseHelper myDB = new DataBaseHelper();
                int incidentID = Int32.Parse(row[0].ToString());

                DataTable IncidentTable;
                DataRow IncidentRow;
                DataTable IncidentCategory;
                DataTable statusLogUpdate;

         

                incidentItem = incidentManager.getIncidentByID(incidentID);
                //IncidentRow = IncidentTable.Rows[0];
                IncidentCategory = myDB.getOneSupportType(incidentID);
                statusLogUpdate = myDB.getOneStatusLog(incidentID);

                //DateTimeConvert = Convert.ToDateTime(IncidentRow["dateTime"].ToString());
                DateTimeDisplay.Text = incidentItem.DateTime;
                incidentType.Text = incidentItem.TypeOfIncident;
                //IncidentIDConvert = int.Parse(IncidentRow["IncidentID"].ToString());
                IncidentID.Text = incidentItem.NewIncidentID.ToString();
                reporterName.Text = incidentItem.ReportPerson;
                //contactNumberConvert = int.Parse(IncidentRow["reportContact"].ToString());
                contactNumber.Text = incidentItem.ContactNo;
                Location.Text = incidentItem.Location;
                //postalCodeConvert = incidentItem.PostalCode;
                postalCode.Text = incidentItem.PostalCode;
                mainDispatch.Text = incidentItem.MainDispatch;


                for (int i = 0; i < statusLogUpdate.Rows.Count; i++)
                {
                    DateTime datetime;
                    datetime = Convert.ToDateTime(statusLogUpdate.Rows[i]["dateTime"].ToString());
                    string messageLog = statusLogUpdate.Rows[i]["statusMessage"].ToString();
                    string result = "[" + datetime + "]" + messageLog;
                    statusLog.Text += (result + System.Environment.NewLine);

                }

                for (int i = 0; i < IncidentCategory.Rows.Count; i++)
                {
                    string result = IncidentCategory.Rows[i]["departmentName"].ToString();
                    supportType.Text += (result + System.Environment.NewLine);
                }

                incidentDesc.Text = incidentItem.Description;
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "displayModal();", true);
            }

            if (e.CommandName == "Delete")
            {
                DataBaseHelper myDB = new DataBaseHelper();
                int IncidentID = 0;
                int index = (((Button)e.CommandSource).NamingContainer as GridViewRow).RowIndex;
                DataTable dt = (DataTable)ViewState["DS"];
                DataRow row = dt.Rows[index];
                IncidentID = Int32.Parse(row[0].ToString());
                myDB.deleteOneIncident(IncidentID);
                Response.Redirect("Default.aspx");
            }

        }


        public void ViewResolvedIncident_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            IncidentItem incidentItem;
            if (e.CommandName == "Select")
            {
                int index = (((Button)e.CommandSource).NamingContainer as GridViewRow).RowIndex;
                DataTable dt = (DataTable)ViewState["DS2"];
                DataRow row = dt.Rows[index];
                DataBaseHelper myDB = new DataBaseHelper();
                int incidentID = Int32.Parse(row[0].ToString());

                DataTable IncidentTable;
                DataRow IncidentRow;
                DataTable IncidentCategory;
                DataTable statusLogUpdate;

                DateTime DateTimeConvert;
                int IncidentIDConvert = 0;
                int contactNumberConvert = 0;
                int postalCodeConvert = 0;

                incidentItem = incidentManager.getIncidentByID(incidentID);
                //IncidentRow = IncidentTable.Rows[0];
                IncidentCategory = myDB.getOneSupportType(incidentID);
                statusLogUpdate = myDB.getOneStatusLog(incidentID);

                //DateTimeConvert = Convert.ToDateTime(IncidentRow["dateTime"].ToString());
                DateTimeDisplay.Text = incidentItem.DateTime;
                incidentType.Text = incidentItem.TypeOfIncident;
                //IncidentIDConvert = int.Parse(IncidentRow["IncidentID"].ToString());
                IncidentID.Text = incidentItem.NewIncidentID.ToString();
                reporterName.Text = incidentItem.ReportPerson;
                //contactNumberConvert = int.Parse(IncidentRow["reportContact"].ToString());
                contactNumber.Text = incidentItem.ContactNo;
                Location.Text = incidentItem.Location;
                //postalCodeConvert = incidentItem.PostalCode;
                postalCode.Text = postalCodeConvert.ToString();
                mainDispatch.Text = incidentItem.MainDispatch;

                for (int i = 0; i < statusLogUpdate.Rows.Count; i++)
                {
                    DateTime datetime;
                    datetime = Convert.ToDateTime(statusLogUpdate.Rows[i]["dateTime"].ToString());
                    string messageLog = statusLogUpdate.Rows[i]["statusMessage"].ToString();
                    string result = "[" + datetime + "]" + messageLog;
                    statusLog.Text += (result + System.Environment.NewLine);

                }

                for (int i = 0; i < IncidentCategory.Rows.Count; i++)
                {
                    string result = IncidentCategory.Rows[i]["departmentName"].ToString();
                    supportType.Text += (result + System.Environment.NewLine);
                }

                incidentDesc.Text = incidentItem.Description;
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "displayModal();", true);
            }

            if (e.CommandName == "Delete")
            {
                DataBaseHelper myDB = new DataBaseHelper();
                int IncidentID = 0;
                int index = (((Button)e.CommandSource).NamingContainer as GridViewRow).RowIndex;
                DataTable dt = (DataTable)ViewState["DS2"];
                DataRow row = dt.Rows[index];
                IncidentID = Int32.Parse(row[0].ToString());
                myDB.deleteOneIncident(IncidentID);
                Response.Redirect("Default.aspx");
            }
        }
        //////////////////////////////

        //    /*
        //    protected void DeleteBtn_Click(object sender, EventArgs e)
        //    {
        //        int IncidentID = 0;
        //        DataBaseHelper myDB = new DataBaseHelper();
        //        CheckBox checkBoxControl = new CheckBox();

        //        foreach(GridViewRow row in GridData.Rows)
        //        {
        //            checkBoxControl = (CheckBox)row.Cells[0].FindControl("chkRecordId");

        //            if(checkBoxControl.Checked == true)
        //            {
        //                IncidentID = Int32.Parse(GridData.DataKeys[row.RowIndex].Value.ToString());
        //                myDB.deleteOneIncident(IncidentID);
        //            }
        //        }

        //        Response.Redirect("EmergencyServiceSPF.aspx");

        //    } // end of method
        //    */
        /////////////////////

        //    FOR VIEW INCIDENT
        protected void UpdateStatusOnClick(object sender, EventArgs e)
        {
            IncidentItem incidentItem;
            DataBaseHelper myDB = new DataBaseHelper();
            int incidentID = 0;
            string updateStatusLog = "";
            string updateStatus = "";
            updateStatusLog = Status.Text;
            updateStatus = statusUpdate.Text;
            incidentID = Int32.Parse(IncidentID.Text);
            myDB.addStatusLog(incidentID, updateStatusLog);
            myDB.updateIncidentStatus(incidentID, updateStatus);

            DataTable IncidentTable;
            DataRow IncidentRow;
            DataTable IncidentCategory;
            DataTable statusLogUpdate;

            DateTime DateTimeConvert;
            int IncidentIDConvert = 0;
            int contactNumberConvert = 0;
            int postalCodeConvert = 0;

            incidentItem = incidentManager.getIncidentByID(incidentID);
            //IncidentRow = IncidentTable.Rows[0];
            IncidentCategory = myDB.getOneSupportType(incidentID);
            statusLogUpdate = myDB.getOneStatusLog(incidentID);

            //DateTimeConvert = Convert.ToDateTime(IncidentRow["dateTime"].ToString());
            DateTimeDisplay.Text = incidentItem.DateTime;
            incidentType.Text = incidentItem.TypeOfIncident;
            //IncidentIDConvert = int.Parse(IncidentRow["IncidentID"].ToString());
            IncidentID.Text = incidentItem.NewIncidentID.ToString();
            reporterName.Text = incidentItem.ReportPerson;
            //contactNumberConvert = int.Parse(IncidentRow["reportContact"].ToString());
            contactNumber.Text = incidentItem.ContactNo;
            Location.Text = incidentItem.Location;
            //postalCodeConvert = incidentItem.PostalCode;
            postalCode.Text = postalCodeConvert.ToString();
            mainDispatch.Text = incidentItem.MainDispatch;

            for (int i = 0; i < statusLogUpdate.Rows.Count; i++)
            {
                DateTime datetime;
                datetime = Convert.ToDateTime(statusLogUpdate.Rows[i]["dateTime"].ToString());
                string messageLog = statusLogUpdate.Rows[i]["statusMessage"].ToString();
                string result = "[" + datetime + "]" + messageLog;
                statusLog.Text += (result + System.Environment.NewLine);

            }

            for (int i = 0; i < IncidentCategory.Rows.Count; i++)
            {
                string result = IncidentCategory.Rows[i]["departmentName"].ToString();
                supportType.Text += (result + System.Environment.NewLine);
            }

            incidentDesc.Text = incidentItem.Description;

        } // end of method.

    }//end of class
}//end of name space

