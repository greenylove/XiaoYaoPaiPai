using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CMSEmergencySystem
{
    public partial class Public : System.Web.UI.Page
    {
        XDocument weather24hr, weather2hr, psi;
        public string[,] weather2hrArray = new string[47, 4];
        public string[,] psiArray = new string[5, 4];
        public string[] weather24hrArray = new string[3];
        protected void loadNEA()
        {
            weather2hr = XDocument.Load("http://api.nea.gov.sg/api/WebAPI/?dataset=2hr_nowcast&keyref=781CF461BB6606AD80A87393DAFA402A507EEEB6FF2083EF");
            weather24hr = XDocument.Load("http://api.nea.gov.sg/api/WebAPI/?dataset=24hrs_forecast&keyref=781CF461BB6606AD80A87393DAFA402A507EEEB6FF2083EF");
            psi = XDocument.Load("http://api.nea.gov.sg/api/WebAPI/?dataset=psi_update&keyref=781CF461BB6606AD80A87393DAFA402A507EEEB6FF2083EF");
            load2hr(weather2hr);
            load24hr(weather24hr);
            loadPsi(psi);
        }

        private void displayNEAInfo()
        {
            if (forecastLabel.Text != "")
                forecastLabel.Text = "";

            if (psiLabel.Text != "")
                psiLabel.Text = "";

            forecastLabel.Text = weather24hrArray[0] + "<br/>" + weather24hrArray[1] + "<br/>" + weather24hrArray[2];
            for (var i = 0; i < psiArray.GetLength(0); i++)
            {
                switch (psiArray[i, 0])
                {
                    case "rNO":
                        psiLabel.Text += "PSI North: " + psiArray[i, 3] + "<br/>";
                        break;
                    case "rCE":
                        psiLabel.Text += "PSI Central: " + psiArray[i, 3] + "<br/>";
                        break;
                    case "rEA":
                        psiLabel.Text += "PSI East: " + psiArray[i, 3] + "<br/>";
                        break;
                    case "rWE":
                        psiLabel.Text += "PSI West: " + psiArray[i, 3] + "<br/>";
                        break;
                    case "rSO":
                        psiLabel.Text += "PSI South: " + psiArray[i, 3] + "<br/>";
                        break;
                }
            }
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

        /* 24hr forecast array format
         * [0] = title
         * [1] = time
         * [2] = forecast string
         */
        private void load24hr(XDocument xdoc)
        {
            var query = from t in xdoc.Descendants("main")
                        select new
                        {
                            title = t.Element("title").Value,
                            time = t.Element("validTime").Value,
                            forecast = t.Element("forecast").Value
                        };

            foreach (var feed in query)
            {
                weather24hrArray[0] = feed.title;
                weather24hrArray[1] = feed.time;
                weather24hrArray[2] = feed.forecast;
            }
        }

        /*PSI array format
         [x, 0] = id
         [x, 1] = lat
         [x, 2] = lon
         [x, 3] = psi value*/
        private void loadPsi(XDocument xdoc)
        {
            var i = 0;
            var query = from t in xdoc.Descendants("region")
                        where t.Element("id").Value != "NRS"
                        select new
                        {
                            id = t.Element("id").Value,
                            lat = t.Element("latitude").Value,
                            lon = t.Element("longitude").Value,
                            value = t.Element("record").Element("reading").Attribute("value").Value
                        };
            foreach (var feed in query)
            {
                if (i < psiArray.GetLength(0))
                {
                    psiArray[i, 0] = feed.id;
                    psiArray[i, 1] = feed.lat;
                    psiArray[i, 2] = feed.lon;
                    psiArray[i, 3] = feed.value;
                }
                //Debug.WriteLine(psiArray[i,0] + " " + psiArray[i, 1] + " " + psiArray[i, 2] + " " + psiArray[i, 3]);
                i++;
            }

        }
    }
}