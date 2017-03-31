using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMSEmergencySystem.Entities;

namespace CMSEmergencySystem.Controllers
{
    public class IncidentManager
    {
        public static void createIncident(string reportPerson, string typeOfIncident, string location, string mainDispatch
            , string assistType, string contactNo, string postalCode, string description, int departmentID, int newIncidentID)
        {
            IncidentItem i = new IncidentItem(reportPerson, typeOfIncident, location, mainDispatch,
                assistType, contactNo, postalCode, description, departmentID, newIncidentID);
            
            //pass i to DAO, DAO deconstruct object and store to DB
        }
    }
}