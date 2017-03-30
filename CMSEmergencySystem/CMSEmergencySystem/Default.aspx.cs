using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSEmergencySystem
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //FOR CREATE INCIDENT
            ////DataBaseHelper myDB = new DataBaseHelper();
            ////DataTable DT = new DataTable();


            //if (!this.IsPostBack)
            //{
            //    DataBaseHelper myDB = new DataBaseHelper();
            //    DataTable DT = new DataTable();
            //    DT = myDB.getAllIncident();
            //    GridData.DataSource = DT;
            //    GridData.DataBind();

            //    ViewState["DS"] = DT;
            //}

            ///*else
            //{
            //    DT = ViewState["DS"];
            //}
            //GridData.DataSource = DT;
            //GridData.DataBind();*/

            //FOR VIEW INCIDENT
            //if (Page.IsPostBack == false)
            //{
            //    DataBaseHelper myDB = new DataBaseHelper();
            //    string incidentID = "";
            //    incidentID = Request.QueryString["ID"];

            //    DataTable CategoryTable = new DataTable();
            //    CategoryTable = myDB.getAllCategoryData();

            //    DataTable IncidentTable;
            //    DataRow IncidentRow;
            //    DataTable IncidentCategory;
            //    DataTable statusLogUpdate;

            //    DateTime DateTimeConvert;
            //    int IncidentIDConvert = 0;
            //    int contactNumberConvert = 0;
            //    int postalCodeConvert = 0;

            //    IncidentTable = myDB.getOneIncident(incidentID);
            //    IncidentRow = IncidentTable.Rows[0];
            //    IncidentCategory = myDB.getOneSupportType(incidentID);
            //    statusLogUpdate = myDB.getOneStatusLog(incidentID);

            //    DateTimeConvert = Convert.ToDateTime(IncidentRow["dateTime"].ToString());
            //    DateTimeDisplay.Text = DateTimeConvert.ToString();
            //    incidentType.Text = (string)IncidentRow["incidentType"];
            //    IncidentIDConvert = int.Parse(IncidentRow["IncidentID"].ToString());
            //    IncidentID.Text = IncidentIDConvert.ToString();
            //    reporterName.Text = (string)IncidentRow["reporterName"];
            //    contactNumberConvert = int.Parse(IncidentRow["reportContact"].ToString());
            //    contactNumber.Text = contactNumberConvert.ToString();
            //    Location.Text = (string)IncidentRow["Location"];
            //    postalCodeConvert = int.Parse(IncidentRow["postalCode"].ToString());
            //    postalCode.Text = postalCodeConvert.ToString();
            //    mainDispatch.Text = (string)IncidentRow["mainDispatch"];

            //    for (int i = 0; i < statusLogUpdate.Rows.Count; i++)
            //    {
            //        DateTime datetime;
            //        datetime = Convert.ToDateTime(statusLogUpdate.Rows[i]["dateTime"].ToString());
            //        string messageLog = statusLogUpdate.Rows[i]["statusMessage"].ToString();
            //        string result = "[" + datetime + "]" + messageLog;
            //        statusLog.Text += (result + System.Environment.NewLine);

            //    }

            //    for (int i = 0; i < IncidentCategory.Rows.Count; i++)
            //    {
            //        string result = IncidentCategory.Rows[i]["departmentName"].ToString();
            //        supportType.Text += (result + System.Environment.NewLine);
            //    }

            //    incidentDesc.Text = (string)IncidentRow["incidentDesc"];


            //}
        }

        //FOR CREAT INCIDENT
        protected void CreateIncidentButton(object sender, EventArgs e)
        {
            //DataBaseHelper myDB = new DataBaseHelper();
            //ConnectionStringSettings settings;
            //settings = System.Configuration.ConfigurationManager.ConnectionStrings["Connection"];
            //string connectionString = settings.ConnectionString;
            //SqlConnection con = new SqlConnection(connectionString);
            //SqlCommand cmd = new SqlCommand();

            //string reportPerson = reportPersonTextBox.Text;
            //string typeOfIncident = typeOfIncidentDDL.Text;
            //string location = locationTextBox.Text;
            //string mainDispatch = MainDispatchDDL.Text;
            //string assistType = assistTypeCheckBoxList.Text;
            //string contactNo = contactNoTextBox.Text;
            //string postalCode = postalCodeTextBox.Text;
            //string description = descriptionTextBox.Text;
            //int DepartmentID = 0;
            //int newIncidentID = 0;

            //con.Open();
            //newIncidentID = myDB.Create_Incident(typeOfIncident, reportPerson, contactNo, location, postalCode, mainDispatch, description);
            //con.Close();

            //foreach (ListItem assistTypeCBL in assistTypeCheckBoxList.Items)
            //{
            //    if (assistTypeCBL.Selected == true)
            //    {
            //        con.Open();
            //        DepartmentID = myDB.AddSupportType(newIncidentID, Convert.ToInt32(assistTypeCBL.Value));
            //        con.Close();
            //    }
            //}




            //Response.Redirect("EmergencyServiceSPF.aspx");

        } // end of class

        /*protected void Testing(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
        GridViewRow gvr = (GridViewRow)btn.NamingContainer;
        if(gvr.RowType == DataControlRowType.DataRow)
        {
              
            int rowIndex = ((sender as Button).NamingContainer as GridViewRow).RowIndex;
            DataRow row = ((DataTable)GridData.DataSource).Rows[rowIndex];
            displayIncidentID.Text = row[0].ToString() + " " + row[2].ToString();
        }
    }<asp:Button ID = "testing" runat = "server" Text = "BUtton" OnClick ="Testing" />*/

        //public void ViewIncident_RowCommand(Object sender, GridViewCommandEventArgs e)
        //{
        //    if (e.CommandName == "Select")
        //    {
        //        int index = (((Button)e.CommandSource).NamingContainer as GridViewRow).RowIndex;
        //        DataTable dt = (DataTable)ViewState["DS"];
        //        DataRow row = dt.Rows[index];
        //        //displayIncidentID.Text = row[0].ToString() + " " + row[2].ToString();
        //        Response.Redirect("ViewIncidentPopUp.aspx?ID=" + row[0].ToString());
        //    }

        //    if (e.CommandName == "Delete")
        //    {
        //        DataBaseHelper myDB = new DataBaseHelper();
        //        int IncidentID = 0;
        //        int index = (((Button)e.CommandSource).NamingContainer as GridViewRow).RowIndex;
        //        DataTable dt = (DataTable)ViewState["DS"];
        //        DataRow row = dt.Rows[index];
        //        IncidentID = Int32.Parse(row[0].ToString());
        //        myDB.deleteOneIncident(IncidentID);
        //        Response.Redirect("EmergencyServiceSPF.aspx");
        //    }

        //}

        /*
        protected void DeleteBtn_Click(object sender, EventArgs e)
        {
            int IncidentID = 0;
            DataBaseHelper myDB = new DataBaseHelper();
            CheckBox checkBoxControl = new CheckBox();

            foreach(GridViewRow row in GridData.Rows)
            {
                checkBoxControl = (CheckBox)row.Cells[0].FindControl("chkRecordId");

                if(checkBoxControl.Checked == true)
                {
                    IncidentID = Int32.Parse(GridData.DataKeys[row.RowIndex].Value.ToString());
                    myDB.deleteOneIncident(IncidentID);
                }
            }

            Response.Redirect("EmergencyServiceSPF.aspx");

        } // end of method
        */

        //FOR VIEW INCIDENT
        //protected void Update_Click(object sender, EventArgs e)
        //{
        //    DataBaseHelper myDB = new DataBaseHelper();
        //    int incidentID = 0;
        //    string updateStatusLog = "";
        //    string updateStatus = "";
        //    updateStatusLog = Status.Text;
        //    updateStatus = statusUpdate.Text;
        //    incidentID = Int32.Parse(Request.QueryString["ID"]);
        //    myDB.addStatusLog(incidentID, updateStatusLog);
        //    myDB.updateIncidentStatus(incidentID, updateStatus);



        //    Response.Redirect("EmergencyServiceSPF.aspx");

        //}
    }
}