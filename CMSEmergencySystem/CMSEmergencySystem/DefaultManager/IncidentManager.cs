﻿using CMSEmergencySystem.Entities;
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
            DataTable DT = incidentManager.getAllPendingIncident();
            DataTable DT2 = incidentManager.getAllResolvedIncident();
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
            int incidentID = incidentManager.createIncident(reportPersonTextBox.Text, typeOfIncidentDDL.Text,
                                locationTextBox.Text, MainDispatchDDL.Text, contactNoTextBox.Text,
                                postalCodeTextBox.Text, descriptionTextBox.Text, Lat, Long);

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
                int index = (((Button)e.CommandSource).NamingContainer as GridViewRow).RowIndex; //get index of row clicked
                DataTable dt = (DataTable)ViewState["DS"]; //get data of current table
                DataRow row = dt.Rows[index]; //get row object 

                int incidentID = Int32.Parse(row[0].ToString()); //get incidentID of row

                DataTable IncidentCategory;
                DataTable statusLogUpdate;

                incidentItem = incidentManager.getIncidentByID(incidentID);
                IncidentCategory = incidentManager.getSupportTypeByID(incidentID);
                statusLogUpdate = incidentManager.getStatusLogByID(incidentID);

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
            }
            //TO BE REVISED
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

                int postalCodeConvert = 0;

                incidentItem = incidentManager.getIncidentByID(incidentID);
                IncidentCategory = incidentManager.getSupportTypeByID(incidentID);
                statusLogUpdate = incidentManager.getStatusLogByID(incidentID);

                DateTimeDisplay.Text = incidentItem.DateTime;
                incidentType.Text = incidentItem.TypeOfIncident;
                IncidentID.Text = incidentItem.NewIncidentID.ToString();
                reporterName.Text = incidentItem.ReportPerson;
                contactNumber.Text = incidentItem.ContactNo;
                Location.Text = incidentItem.Location;
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
            // TO BE REVISED
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
        } // end of view resolved

        protected void UpdateStatusOnClick(object sender, EventArgs e)
        {
            IncidentItem incidentItem;
            DataBaseHelper myDB = new DataBaseHelper();
            int incidentID = 0;
            string updateStatusLog = "";
            string updateStatus = "";
            updateStatusLog = Status.Text;
            updateStatus = statusUpdate.Text;
            incidentID = Int32.Parse(IncidentID.Text); // NEED TO CHANGE, THIS CODE IS NOT DOING ANYTHIG, GET INCIDENTID FROM SELECTED INDEX
            incidentManager.addStatusLogByID(incidentID, updateStatusLog);
            incidentManager.updateStatusByID(incidentID, updateStatus);

            DataTable IncidentCategory;
            DataTable statusLogUpdate;

            int postalCodeConvert = 0;

            incidentItem = incidentManager.getIncidentByID(incidentID);
            IncidentCategory = myDB.getOneSupportType(incidentID);
            statusLogUpdate = myDB.getOneStatusLog(incidentID);

            DateTimeDisplay.Text = incidentItem.DateTime;
            incidentType.Text = incidentItem.TypeOfIncident;
            IncidentID.Text = incidentItem.NewIncidentID.ToString();
            reporterName.Text = incidentItem.ReportPerson;
            contactNumber.Text = incidentItem.ContactNo;
            Location.Text = incidentItem.Location;
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

        } // end of updateButton.

    }// end of class
}//end of namespace