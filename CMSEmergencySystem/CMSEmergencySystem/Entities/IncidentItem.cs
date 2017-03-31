using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSEmergencySystem.Entities
{
    public class IncidentItem
    {
        private string reportPerson;
        private string typeOfIncident;
        private string location;
        private string mainDispatch;
        private string assistType;
        private string contactNo;
        private string postalCode;
        private string description;
        private int DepartmentID;
        private int newIncidentID;
        
        //Constructor 
        public IncidentItem(string reportPerson, string typeOfIncident, string location, string mainDispatch
           , string assistType, string contactNo, string postalCode, string description, int departmentID, int newIncidentID)
        {
            this.ReportPerson = reportPerson;
            this.TypeOfIncident = typeOfIncident;
            this.Location = location;
            this.MainDispatch = mainDispatch;
            this.AssistType = assistType;
            this.ContactNo = contactNo;
            this.PostalCode = postalCode;
            this.Description = description;
            this.DepartmentID1 = departmentID;
            this.NewIncidentID = newIncidentID;
        }
        //Getter setters for all variables
        public int NewIncidentID
        {
            get
            {
                return newIncidentID;
            }

            set
            {
                newIncidentID = value;
            }
        }

        public int DepartmentID1
        {
            get
            {
                return DepartmentID;
            }

            set
            {
                DepartmentID = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string PostalCode
        {
            get
            {
                return postalCode;
            }

            set
            {
                postalCode = value;
            }
        }

        public string ContactNo
        {
            get
            {
                return contactNo;
            }

            set
            {
                contactNo = value;
            }
        }

        public string AssistType
        {
            get
            {
                return assistType;
            }

            set
            {
                assistType = value;
            }
        }

        public string MainDispatch
        {
            get
            {
                return mainDispatch;
            }

            set
            {
                mainDispatch = value;
            }
        }

        public string Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        public string TypeOfIncident
        {
            get
            {
                return typeOfIncident;
            }

            set
            {
                typeOfIncident = value;
            }
        }

        public string ReportPerson
        {
            get
            {
                return reportPerson;
            }

            set
            {
                reportPerson = value;
            }
        }

       

        

        






    }
}