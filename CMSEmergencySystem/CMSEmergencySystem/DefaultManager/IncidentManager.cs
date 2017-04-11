using CMSEmergencySystem.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSEmergencySystem
{
    public partial class Default : System.Web.UI.Page
    {
        public void initIncidentList()
        {
            DataTable DT = incidentController.getAllPendingIncident();
            DataTable DT2 = incidentController.getAllResolvedIncident();
            GridData.DataSource = DT;
            GridData.DataBind();
            GridData2.DataSource = DT2;
            GridData2.DataBind();

            ViewState["DS2"] = DT2;
            ViewState["DS"] = DT;
        }
        protected void CreateIncidentButton(object sender, EventArgs e)
        {
            
            float Lat = float.Parse(LatInfo.Value);
           float Long = float.Parse(LngInfo.Value);
            //pass form variable into incidentManager
            IncidentItem incident = incidentController.createIncident(reportPersonTextBox.Text, typeOfIncidentDDL.Text,
                                locationTextBox.Text, MainDispatchDDL.Text, contactNoTextBox.Text,
                                postalCodeTextBox.Text, descriptionTextBox.Text, Lat, Long);
            //call newsfeed controller to do something

            foreach (ListItem assistTypeCBL in assistTypeCheckBoxList.Items)
                if (assistTypeCBL.Selected == true)
                    incidentController.addSupportType(incident.NewIncidentID, Convert.ToInt32(assistTypeCBL.Value));
            foreach (ListItem assistTypeCBL1 in CheckBoxList1.Items)
                if (assistTypeCBL1.Selected == true)
                    incidentController.addSupportType(incident.NewIncidentID, Convert.ToInt32(assistTypeCBL1.Value));
            foreach (ListItem assistTypeCBL2 in CheckBoxList2.Items)
                if (assistTypeCBL2.Selected == true)
                    incidentController.addSupportType(incident.NewIncidentID, Convert.ToInt32(assistTypeCBL2.Value));

            //update UI
            clearTextBox();
            updateUIIncident();
            //pass json string to javascript
            System.Web.Script.Serialization.JavaScriptSerializer oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string sIncident = oSerializer.Serialize(incident); //converts object to json string
            ScriptManager.RegisterStartupScript(this, GetType(), "script", "replaceDefaultMarker(" + sIncident + ");", true);
            //Response.Redirect("Default.aspx");
            //ScriptManager.RegisterStartupScript(this, GetType(), "script", "test();", true);
        
        } // end of class

        protected void sendQuery_Click(object sender, EventArgs e)
        {
            string searchQuery = searchResult.Text;
            DataTable DT = incidentController.getSearchIncident(searchQuery);
            GridData.DataSource = DT;
            GridData.DataBind();
            ViewState["DS"] = DT;
        }

        protected void clearQuery_Click(object sender, EventArgs e)
        {
            initIncidentList();
        }

        protected void showFire_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        public void clearTextBox()
        {
            DateTimeDisplay.Text = incidentType.Text = IncidentID.Text = reporterName.Text = contactNumber.Text = Location.Text = postalCode.Text =
            mainDispatch.Text = statusLog.Text = incidentDesc.Text = supportType.Text = reportPersonTextBox.Text = contactNoTextBox.Text
            = postalCodeTextBox.Text = descriptionTextBox.Text = "";

            for (int i = 0; i < 4; i++)
            {
                assistTypeCheckBoxList.Items[i].Selected = false;
                CheckBoxList1.Items[i].Selected = false;
            }
            CheckBoxList2.Items[0].Selected = false;

        }

        public void updateUIIncident()
        {
            DataTable DT = incidentController.getAllPendingIncident();
            DataTable DT2 = incidentController.getAllResolvedIncident();
            GridData.DataSource = DT;
            GridData.DataBind();
            GridData2.DataSource = DT2;
            GridData2.DataBind();
            ViewState["DS"] = DT;
            ViewState["DS2"] = DT2;
        }

       

        public void ViewPendingIncident_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            IncidentItem incidentItem;
            if (e.CommandName == "Select")
            {

                int index = (((Button)e.CommandSource).NamingContainer as GridViewRow).RowIndex; //get index of row clicked
                DataTable dt = (DataTable)ViewState["DS"]; //get data of current table
                DataRow row = dt.Rows[index]; //get row object 

                int incidentID = Int32.Parse(row[0].ToString()); //get incidentID of row

                DataTable IncidentCategory;
                DataTable statusLogUpdate;

                incidentItem = incidentController.getIncidentByID(incidentID);
                IncidentCategory = incidentController.getSupportTypeByID(incidentID);
                statusLogUpdate = incidentController.getStatusLogByID(incidentID);

                clearTextBox();
                DateTimeDisplay.Text = incidentItem.DateTime;
                incidentType.Text = incidentItem.TypeOfIncident;
                IncidentID.Text = incidentItem.NewIncidentID.ToString();
                reporterName.Text = incidentItem.ReportPerson;
                contactNumber.Text = incidentItem.ContactNo;
                Location.Text = incidentItem.Location;
                postalCode.Text = incidentItem.PostalCode;
                mainDispatch.Text = incidentItem.MainDispatch;

                for (int i = 0; i < statusLogUpdate.Rows.Count; i++){
                    DateTime datetime;
                    datetime = Convert.ToDateTime(statusLogUpdate.Rows[i]["dateTime"].ToString());
                    string messageLog = statusLogUpdate.Rows[i]["statusMessage"].ToString();
                    string result = "[" + datetime + "]" + messageLog;
                    statusLog.Text += (result + System.Environment.NewLine);
                }

                for (int i = 0; i < IncidentCategory.Rows.Count; i++){
                    string result = IncidentCategory.Rows[i]["departmentName"].ToString();
                    supportType.Text += (result + System.Environment.NewLine);
                }

                incidentDesc.Text = incidentItem.Description;
                ScriptManager.RegisterStartupScript(this, GetType(), "script", "displayModal();", true);
            }
            //TO BE REVISED
         

        } // end of ViewPending
        public void ViewResolvedIncident_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            IncidentItem incidentItem;
            if (e.CommandName == "Select")
            {
                int index = (((Button)e.CommandSource).NamingContainer as GridViewRow).RowIndex;
                DataTable dt = (DataTable)ViewState["DS2"];
                DataRow row = dt.Rows[index];
                int incidentID = Int32.Parse(row[0].ToString());

                DataTable IncidentCategory;
                DataTable statusLogUpdate;

       

                incidentItem = incidentController.getIncidentByID(incidentID);
                IncidentCategory = incidentController.getSupportTypeByID(incidentID);
                statusLogUpdate = incidentController.getStatusLogByID(incidentID);

                clearTextBox();
                DateTimeDisplay.Text = incidentItem.DateTime;
                incidentType.Text = incidentItem.TypeOfIncident;
                IncidentID.Text = incidentItem.NewIncidentID.ToString();
                reporterName.Text = incidentItem.ReportPerson;
                contactNumber.Text = incidentItem.ContactNo;
                Location.Text = incidentItem.Location;
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
                initIncidentList();
            }
            // TO BE REVISED
            
        } // end of view resolved

        protected void UpdateStatusOnClick(object sender, EventArgs e)
        {
            DataTable IncidentCategory;
            DataTable statusLogUpdate;
            IncidentItem incidentItem;
            DataBaseHelper myDB = new DataBaseHelper();
            int incidentID = 0;
            string updateStatus = "";
            updateStatus = statusUpdate.Text;
            incidentID = Int32.Parse(IncidentID.Text); // NEED TO CHANGE, THIS CODE IS NOT DOING ANYTHIG, GET INCIDENTID FROM SELECTED INDEX
            incidentController.updateStatusByID(incidentID, updateStatus);
                        
            incidentItem = incidentController.getIncidentByID(incidentID);
            IncidentCategory = myDB.getOneSupportType(incidentID);
            statusLogUpdate = myDB.getOneStatusLog(incidentID);

            clearTextBox();
            DateTimeDisplay.Text = incidentItem.DateTime;
            incidentType.Text = incidentItem.TypeOfIncident;
            IncidentID.Text = incidentItem.NewIncidentID.ToString();
            reporterName.Text = incidentItem.ReportPerson;
            contactNumber.Text = incidentItem.ContactNo;
            Location.Text = incidentItem.Location;
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
            updateUIIncident();
        } // end of updateButton.

    }// end of class
}//end of namespace