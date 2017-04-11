using System;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Web.UI.HtmlControls;
using CMSEmergencySystem.Entities;
using Newtonsoft.Json;
using System.Threading;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Globalization;

namespace CMSEmergencySystem
{
    public partial class EmergencyServices : System.Web.UI.Page
    {
        protected String FBAccessToken = "1677399102562906|QVDAamqpPwvP_LhYi5TsZaRP3Zs";
        protected FacebookFeeds feeds;
        protected string query = "SIUMIN";
        protected string url = "https://api.twitter.com/1.1/statuses/user_timeline.json";

        private void RefreshSocialFeed()
        {
            if (Session["FBFeed"] != null)
            {
                FacebookFeeds feeds2 = Session["FBFeed"] as FacebookFeeds;

                WebRequest request = WebRequest.Create("https://graph.facebook.com/CMSXiaoYaoPai/feed?fields=full_picture,picture,message,created_time,comments{comment_count},likes,link,name,admin_creator,description,caption&limit=10&access_token=" + FBAccessToken);
                request.Credentials = CredentialCache.DefaultCredentials;
                WebResponse response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream, Encoding.UTF8);
                String responseString = reader.ReadToEnd();

                FacebookFeeds newFeeds = JsonConvert.DeserializeObject<FacebookFeeds>(responseString);
                Session["FBFeed2"] = newFeeds;

                if (feeds2.data[0].Created_time != newFeeds.data[0].Created_time)
                {
                    LookForNewFBFeed();
                }
            }
        }

        private void LookForNewFBFeed()
        {
            System.Windows.Forms.MessageBox.Show("Got new!");
            FacebookFeeds oldfeeds = Session["FBFeed"] as FacebookFeeds;
            FacebookFeeds newfeeds = Session["FBFeed2"] as FacebookFeeds;

            foreach (FacebookFeed FBFeed in newfeeds.data)
            {
                //Session["FBFeed"] = newfeeds;
                String attachedImg = FBFeed.Picture;
                String message = FBFeed.Message;
                String time = FBFeed.Created_time;
                String link = FBFeed.Link;
                String linkName = FBFeed.Name;

                if (oldfeeds.data[0].Created_time != time)
                {
                    HtmlGenericControl mainDiv = new HtmlGenericControl("li");
                    HtmlGenericControl postUserImg = new HtmlGenericControl("img");
                    HtmlGenericControl divStatus = new HtmlGenericControl("div");
                    HtmlGenericControl p = new HtmlGenericControl("p");
                    HtmlGenericControl divLink = new HtmlGenericControl("div");
                    HtmlGenericControl attachImg = new HtmlGenericControl("img");
                    HtmlGenericControl commentsP = new HtmlGenericControl("p");
                    HtmlGenericControl divAttach = new HtmlGenericControl("div");
                    HtmlGenericControl attachPname = new HtmlGenericControl("p");
                    HtmlGenericControl attachPdesc = new HtmlGenericControl("p");
                    HtmlAnchor attachAHREF = new HtmlAnchor();
                    HtmlAnchor imgAHREF = new HtmlAnchor();

                    divStatus.Attributes.Add("class", "status");
                    p.Attributes.Add("class", "message");
                    p.InnerHtml = message;
                    divStatus.Controls.Add(p);
                    if ((link != null) && (link != String.Empty))
                    {
                        divLink.Attributes.Add("class", "attachment");
                        if (attachedImg != "")
                        {
                            attachImg.Attributes["src"] = attachedImg;
                            attachImg.Attributes.Add("class", "picture");
                            imgAHREF.Controls.Add(attachImg);
                            imgAHREF.Attributes["href"] = link;
                            imgAHREF.Attributes["target"] = "_blank";
                        }
                        divAttach.Attributes.Add("class", "attachment-data");
                        attachPname.Attributes.Add("class", "name");
                        attachPdesc.Attributes.Add("class", "description");
                        attachPdesc.InnerText = FBFeed.Description;
                        attachAHREF.Attributes["href"] = link;
                        attachAHREF.Attributes["target"] = "_blank";

                        attachAHREF.InnerText = linkName;

                        divLink.Controls.Add(imgAHREF);

                        attachPname.Controls.Add(attachAHREF);

                        divLink.Controls.Add(attachPname);
                        divLink.Controls.Add(attachPdesc);

                        divLink.Controls.Add(divAttach);
                        divStatus.Controls.Add(divLink);
                    }
                    commentsP.Attributes.Add("class", "meta");
                    DateTime dt = Convert.ToDateTime(FBFeed.Created_time);
                    commentsP.InnerHtml += ToRelativeTimeString(dt) + " ";

                    mainDiv.Controls.Add(divStatus);
                    mainDiv.Controls.Add(commentsP);
                    fbLiveFeed.Controls.Add(mainDiv);

                }
            }
        }

        private void RefreshFBFeed()
        {
            WebRequest request = WebRequest.Create("https://graph.facebook.com/CMSXiaoYaoPai/feed?fields=full_picture,picture,message,created_time,comments{comment_count},likes,link,name,admin_creator,description,caption&limit=10&access_token=" + FBAccessToken);
            request.Credentials = CredentialCache.DefaultCredentials;
            WebResponse response = request.GetResponse();

            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream, Encoding.UTF8);
            String responseString = reader.ReadToEnd();

            feeds = JsonConvert.DeserializeObject<FacebookFeeds>(responseString);
            Session["FBFeed"] = feeds;
            foreach (FacebookFeed FBFeed in feeds.data)
            {
                String attachedImg = FBFeed.Picture;
                String message = FBFeed.Message;
                String time = FBFeed.Created_time;
                String link = FBFeed.Link;
                String linkName = FBFeed.Name;

                HtmlGenericControl mainDiv = new HtmlGenericControl("li");
                HtmlGenericControl postUserImg = new HtmlGenericControl("img");
                HtmlGenericControl divStatus = new HtmlGenericControl("div");
                HtmlGenericControl p = new HtmlGenericControl("p");
                HtmlGenericControl divLink = new HtmlGenericControl("div");
                HtmlGenericControl attachImg = new HtmlGenericControl("img");
                HtmlGenericControl commentsP = new HtmlGenericControl("p");
                HtmlGenericControl divAttach = new HtmlGenericControl("div");
                HtmlGenericControl attachPname = new HtmlGenericControl("p");
                HtmlGenericControl attachPdesc = new HtmlGenericControl("p");
                HtmlAnchor attachAHREF = new HtmlAnchor();
                HtmlAnchor imgAHREF = new HtmlAnchor();

                divStatus.Attributes.Add("class", "status");
                p.Attributes.Add("class", "message");
                p.InnerHtml = message;
                divStatus.Controls.Add(p);
                if ((link != null) && (link != String.Empty))
                {
                    divLink.Attributes.Add("class", "attachment");
                    if (attachedImg != "")
                    {
                        attachImg.Attributes["src"] = attachedImg;
                        attachImg.Attributes.Add("class", "picture");
                        imgAHREF.Controls.Add(attachImg);
                        imgAHREF.Attributes["href"] = link;
                        imgAHREF.Attributes["target"] = "_blank";
                    }
                    divAttach.Attributes.Add("class", "attachment-data");
                    attachPname.Attributes.Add("class", "name");
                    attachPdesc.Attributes.Add("class", "description");
                    attachPdesc.InnerText = FBFeed.Description;
                    attachAHREF.Attributes["href"] = link;
                    attachAHREF.Attributes["target"] = "_blank";

                    attachAHREF.InnerText = linkName;

                    divLink.Controls.Add(imgAHREF);

                    attachPname.Controls.Add(attachAHREF);

                    divLink.Controls.Add(attachPname);
                    divLink.Controls.Add(attachPdesc);

                    divLink.Controls.Add(divAttach);
                    divStatus.Controls.Add(divLink);
                }
                commentsP.Attributes.Add("class", "meta");
                DateTime dt = Convert.ToDateTime(FBFeed.Created_time);
                commentsP.InnerHtml += ToRelativeTimeString(dt) + " ";

                mainDiv.Controls.Add(divStatus);
                mainDiv.Controls.Add(commentsP);
                fbLiveFeed.Controls.Add(mainDiv);

            }
            response.Close();
        }

        private void RefreshTwitterFeed(String resource_url, String q)
        {
            // oauth application keys
            var oauth_token = "847409682490642432-QNW7iK3wYSsGINN4Oe19gB3Yz7Nvfqk"; //"insert here...";
            var oauth_token_secret = "Ln87plkr89HjiqUG5OIoIEU4g5c0pOg3MNECbbQB03tBF"; //"insert here...";
            var oauth_consumer_key = "bZ90ol3pHIWbQudynzhNGOy3S";// = "insert here...";
            var oauth_consumer_secret = "jwuuKARCVj2AORBuEkvPvaw6DyFQTKlwdMmeexTmvbjc2UYASQ";// = "insert here...";

            // oauth implementation details
            var oauth_version = "1.0";
            var oauth_signature_method = "HMAC-SHA1";

            // unique request details
            var oauth_nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
            var timeSpan = DateTime.UtcNow
                - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();

            // create oauth signature
            var baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" +
                            "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&q={6}";

            var baseString = string.Format(baseFormat,
                                        oauth_consumer_key,
                                        oauth_nonce,
                                        oauth_signature_method,
                                        oauth_timestamp,
                                        oauth_token,
                                        oauth_version,
                                        Uri.EscapeDataString(q)
                                        );

            baseString = string.Concat("GET&", Uri.EscapeDataString(resource_url), "&", Uri.EscapeDataString(baseString));

            var compositeKey = string.Concat(Uri.EscapeDataString(oauth_consumer_secret),
                                    "&", Uri.EscapeDataString(oauth_token_secret));

            string oauth_signature;
            using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(compositeKey)))
            {
                oauth_signature = Convert.ToBase64String(
                    hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes(baseString)));
            }

            // create the request header
            var headerFormat = "OAuth oauth_nonce=\"{0}\", oauth_signature_method=\"{1}\", " +
                               "oauth_timestamp=\"{2}\", oauth_consumer_key=\"{3}\", " +
                               "oauth_token=\"{4}\", oauth_signature=\"{5}\", " +
                               "oauth_version=\"{6}\"";

            var authHeader = string.Format(headerFormat,
                                    Uri.EscapeDataString(oauth_nonce),
                                    Uri.EscapeDataString(oauth_signature_method),
                                    Uri.EscapeDataString(oauth_timestamp),
                                    Uri.EscapeDataString(oauth_consumer_key),
                                    Uri.EscapeDataString(oauth_token),
                                    Uri.EscapeDataString(oauth_signature),
                                    Uri.EscapeDataString(oauth_version)
                            );

            ServicePointManager.Expect100Continue = false;

            // make the request
            var postBody = "q=" + Uri.EscapeDataString(q);//
            resource_url += "?" + postBody;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resource_url);
            request.Headers.Add("Authorization", authHeader);
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            var response = (HttpWebResponse)request.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());
            var objText = reader.ReadToEnd();
            twitterLiveFeed.InnerHtml = objText;
            string html = "";
            try
            {
                JArray jsonDat = JArray.Parse(objText);
                for (int x = 0; x < jsonDat.Count(); x++)
                {
                    html += "<li>";
                    html += "<div class=\"status\">";
                    String mystring = jsonDat[x]["text"].ToString();

                    foreach (Match item in Regex.Matches(mystring, @"(http|ftp|https):\/\/([\w\-_]+(?:(?:\.[\w\-_]+)+))([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?"))
                    {
                        String url = item.Value;
                        mystring = mystring.Replace(url, "<a href=\"" + url + "\" >" + url + "</a>");
                    }

                    String time = jsonDat[x]["created_at"].ToString();
                    DateTime dt = DateTime.ParseExact(jsonDat[x]["created_at"].ToString(), "ddd MMM dd HH:mm:ss K yyyy", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

                    html += "<p class=\"message\">" + mystring + "</p>";
                    html += "<p class=\"meta\">" + ToRelativeTimeString(dt) + "</p>";
                    html += "</div>";
                    html += "</li>";
                }
                twitterLiveFeed.InnerHtml = html;
            }
            catch (Exception twit_error)
            {
                twitterLiveFeed.InnerHtml = html + twit_error.ToString();
            }
        }

        private void InvokeMethod()
        {
            while (true)
            {
                //RefreshSocialFeed();
                Thread.Sleep(10000); // 30 sec
            }
        }

        protected static string ToRelativeTimeString(DateTime value)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = DateTime.Now.Subtract(value);
            double seconds = ts.TotalSeconds;

            // Less than one minute
            if (seconds < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (seconds < 60 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (seconds < 120 * MINUTE)
                return "an hour ago";

            if (seconds < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (seconds < 48 * HOUR)
                return "yesterday";

            if (seconds < 30 * DAY)
                return ts.Days + " days ago";

            if (seconds < 12 * MONTH)
            {
                int months = System.Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            int years = System.Convert.ToInt32(Math.Floor((double)ts.Days / 365));
            return years <= 1 ? "one year ago" : years + " years ago";
        }
    }
}
