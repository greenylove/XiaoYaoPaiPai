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


namespace CMSEmergencySystem.Controllers
{
    public class IncidentController
    {
        DataBaseHelper myDB = new DataBaseHelper();

        public int createIncident(string reportPerson, string typeOfIncident, string location, string mainDispatch
            , string contactNo, string postalCode, string description, float latitude, float longitude)
        {
            //using create item constructor
            IncidentItem i = new IncidentItem(reportPerson, typeOfIncident, location, mainDispatch,
                 contactNo, postalCode, description, latitude, longitude);

            string message = "A " + typeOfIncident + " has occured at " + location + " at " + DateTime.Now.ToString();
            
            new NewsFeedController().UpdateStatustoFB(message);
            new NewsFeedController().UpdateStatustoTwitter(message);
            
            //pass object to DAO, DAO deconstruct object and store to DB
            int newIncidentID = myDB.Create_Incident(i);
            return newIncidentID;
        }
        public IncidentItem getIncidentByID(int incidentID)
        {
            return myDB.getOneIncident(incidentID);
        }
        public void addSupportType(int incidentID, int departmentID)
        {
            myDB.AddSupportTypeDB(incidentID, departmentID);
        }
        public DataTable getAllPendingIncident()
        {
            return myDB.getAllPendingIncidentDB();
        }

        public DataTable getAllResolvedIncident()
        {
            return myDB.getAllResolvedIncidentDB();
        }

        public DataTable getSupportTypeByID(int incidentID)
        {
            return myDB.getOneSupportType(incidentID);
        }
        public DataTable getStatusLogByID(int incidentID)
        {
            return myDB.getOneStatusLog(incidentID);
        }
        public void addStatusLogByID(int id, string status)
        {
            myDB.addStatusLog(id, status);
        }
        public void updateStatusByID(int id, string status)
        {
            myDB.updateIncidentStatus(id, status);
        }
        public DataTable getSearchIncident(string Query)
        {
            return myDB.getSearchIncident(Query);
        }

    }
}