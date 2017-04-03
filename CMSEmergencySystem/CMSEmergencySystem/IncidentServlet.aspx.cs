using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using CMSEmergencySystem.Entities;


namespace CMSEmergencySystem
{
    public partial class IncidentServlet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<IncidentItem> IncidentObj = GetIncidentObject();
            Response.Write(JsonConvert.SerializeObject(IncidentObj));
        }
        protected List<IncidentItem> GetIncidentObject()
        {
            DataBaseHelper myDB = new DataBaseHelper();
            DataTable Location;
            Location = myDB.getAllLocation();
            List<IncidentItem> IncidentObj = new List<IncidentItem>();
            for (int i = 0; i < Location.Rows.Count; i++)
            {
                IncidentItem incident = new IncidentItem(Location.Rows[i]["reporterName"].ToString(),
                    Location.Rows[i]["incidentType"].ToString(),
                    Location.Rows[i]["Location"].ToString(),
                    Location.Rows[i]["mainDispatch"].ToString(),
                    Location.Rows[i]["reportContact"].ToString(),
                    Location.Rows[i]["postalCode"].ToString(),
                    Location.Rows[i]["incidentDesc"].ToString(),
                    float.Parse(Location.Rows[i]["Latitude"].ToString()),
                    float.Parse(Location.Rows[i]["Longitude"].ToString()));
                incident.Status = Location.Rows[i]["Status"].ToString();
                IncidentObj.Add(incident);
            }
            return IncidentObj;
        }
    }
}