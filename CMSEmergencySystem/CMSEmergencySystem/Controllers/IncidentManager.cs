using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMSEmergencySystem.Entities;
using CMSEmergencySystem.DAO;


namespace CMSEmergencySystem.Controllers
{
    public class IncidentManager
    {
        DataBaseHelper myDB = new DataBaseHelper();

        public int createIncident(string reportPerson, string typeOfIncident, string location, string mainDispatch
            , string contactNo, string postalCode, string description, int newIncidentID, float latitude, float longitude)
        {
            IncidentItem i = new IncidentItem(reportPerson, typeOfIncident, location, mainDispatch,
                 contactNo, postalCode, description, newIncidentID, latitude, longitude);

            //pass i to DAO, DAO deconstruct object and store to DB
            newIncidentID = myDB.Create_Incident(i);
            return newIncidentID;
        }
        public IncidentItem getIncidentByID(int incidentID)
        {
            return myDB.getOneIncident(incidentID);
        }
        public void addSupportType(int i, int val)
        {
            myDB.AddSupportTypeDB(i, val);
        }
        public DataTable getAllPendingIncident()
        {
            return myDB.getAllPendingIncidentDB();
        }

        public DataTable getAllResolvedIncident()
        {
            return myDB.getAllResolvedIncidentDB();
        }


    }
}