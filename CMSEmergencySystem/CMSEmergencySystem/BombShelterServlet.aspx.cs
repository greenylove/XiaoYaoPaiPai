using System;
using System.Collections.Generic;
using System.Data;
using Newtonsoft.Json;
using CMSEmergencySystem.Entities;

namespace CMSEmergencySystem
{
    public partial class BombShelterServlet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<BombShelterItem> BombShelterObj = GetBombShelterObj();
            Response.Write(JsonConvert.SerializeObject(BombShelterObj));
        }

        protected List<BombShelterItem> GetBombShelterObj()
        {
            DataBaseHelper myDB = new DataBaseHelper();
            DataTable BombShelterLocation;
            BombShelterLocation = myDB.getAllBombShelter();
            List<BombShelterItem> BombShelterObj = new List<BombShelterItem>();
            for (int i = 0; i < BombShelterLocation.Rows.Count; i++)
            {
                BombShelterItem BombShelter = new BombShelterItem(
                    BombShelterLocation.Rows[i]["Location"].ToString(),
                    float.Parse(BombShelterLocation.Rows[i]["Latitude"].ToString()),
                    float.Parse(BombShelterLocation.Rows[i]["Longitude"].ToString()),
                    Int32.Parse(BombShelterLocation.Rows[i]["Postal"].ToString()),
                    BombShelterLocation.Rows[i]["Description"].ToString(),
                    BombShelterLocation.Rows[i]["Address"].ToString());

                BombShelterObj.Add(BombShelter);
            }
            return BombShelterObj;
        }


    }
}