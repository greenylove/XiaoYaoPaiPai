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
        private string contactNo;
        private string postalCode;
        private string description;
        private int newIncidentID;
        private float latitude;
        private float longitude;
        private string dateTime;
        private string status;
        private string incidentDescription;
        private string updateDescription;

        //Constructor 
        public IncidentItem(string reportPerson, string typeOfIncident, string location, string mainDispatch
           , string contactNo, string postalCode, string description, int newIncidentID, float lat, float longi)
        {
            this.ReportPerson = reportPerson;
            this.TypeOfIncident = typeOfIncident;
            this.Location = location;
            this.MainDispatch = mainDispatch;
            this.ContactNo = contactNo;
            this.PostalCode = postalCode;
            this.Description = description;
            this.NewIncidentID = newIncidentID;
            this.Latitude = lat;
            this.Longitude = longi;
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

        public float Latitude
        {
            get
            {
                return latitude;
            }

            set
            {
                latitude = value;
            }
        }

        public float Longitude
        {
            get
            {
                return longitude;
            }

            set
            {
                longitude = value;
            }
        }

        public string DateTime
        {
            get
            {
                return dateTime;
            }

            set
            {
                dateTime = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string IncidentDescription
        {
            get
            {
                return incidentDescription;
            }

            set
            {
                incidentDescription = value;
            }
        }

        public string UpdateDescription
        {
            get
            {
                return updateDescription;
            }

            set
            {
                updateDescription = value;
            }
        }
    }
}