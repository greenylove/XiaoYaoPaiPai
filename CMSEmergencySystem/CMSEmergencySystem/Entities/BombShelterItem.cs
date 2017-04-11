using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSEmergencySystem.Entities
{
    public class BombShelterItem
    {
        //LLLPDA

        public string Location
        {
            set;
            get;
        }
        public float Latitude
        {
            set;
            get;
        }
        public float Longitude
        {
            set;
            get;
        }
        public int Postal
        {
            set;
            get;
        }
        public string Description
        {
            set;
            get;
        }
        public string Address
        {
            set;
            get;
        }
        public BombShelterItem(string location, float latitude, float longitude, int postal, string description, string address)
        {
            this.Location = location;
            this.Latitude = latitude;
            this.Longitude = longitude;
            this.Postal = postal;
            this.Description = description;
            this.Address = address;
        }

    }
}