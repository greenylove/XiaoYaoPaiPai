using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CMSEmergencySystem
{
    public partial class Default : System.Web.UI.Page
    {
        XDocument weather24hr, weather2hr, psi;
        public string[,] weather2hrArray = new string[47, 4];
        protected void loadNEA()
        {
            weather2hr = XDocument.Load("http://api.nea.gov.sg/api/WebAPI/?dataset=2hr_nowcast&keyref=781CF461BB6606AD80A87393DAFA402A507EEEB6FF2083EF");
            weather24hr = XDocument.Load("http://api.nea.gov.sg/api/WebAPI/?dataset=24hrs_forecast&keyref=781CF461BB6606AD80A87393DAFA402A507EEEB6FF2083EF");
            psi = XDocument.Load("http://api.nea.gov.sg/api/WebAPI/?dataset=psi_update&keyref=781CF461BB6606AD80A87393DAFA402A507EEEB6FF2083EF");
            load2hr(weather2hr);
            load24hr(weather24hr);
            loadPsi(psi);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }



        private void load2hr(XDocument xdoc)
        {
            int i = 0;
            var query = from t in xdoc.Descendants("area")
                        select new
                        {
                            name = t.Attribute("name").Value,
                            forecast = t.Attribute("forecast").Value,
                            lat = t.Attribute("lat").Value,
                            lon = t.Attribute("lon").Value
                        };

            /*weather2hrArray format
             [x, 0] = name
             [x, 1] = lat
             [x, 2] = lon
             [x, 3] = forecast
             *x = individual townships
             eg. weather2hrArray[0, 0] displays 'Ang Mo Kio'*/
            foreach (var feed in query)
            {
                if (i < weather2hrArray.GetLength(0))
                {
                    weather2hrArray[i, 0] = feed.name;
                    weather2hrArray[i, 1] = feed.lat;
                    weather2hrArray[i, 2] = feed.lon;
                    weather2hrArray[i, 3] = feed.forecast;
                    Debug.WriteLine(weather2hrArray[i, 0] + " " + weather2hrArray[i, 3]);
                }
                i++;
            }


        }

        private void load24hr(XDocument xdoc)
        {
            var query = from t in xdoc.Descendants("main")
                        select new
                        {
                            title = t.Element("title").Value,
                            time = t.Element("validTime").Value,
                            forecast = t.Element("forecast").Value
                        };

            //foreach (var feed in query)
            //{
            //    afternoonLabel.Text = feed.title + "<br/>" + feed.time + "<br/>" + feed.forecast;
            //}
        }

        private void loadPsi(XDocument xdoc)
        {
            var query = from t in xdoc.Descendants("region")
                        where t.Element("id").Value != "NRS"
                        select new
                        {
                            id = t.Element("id"),
                            lat = t.Element("latitude"),
                            lon = t.Element("longitude"),
                            value = t.Element("record").Element("reading").Attribute("value").Value
                        };

        }
    }
}