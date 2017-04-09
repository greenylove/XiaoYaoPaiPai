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
using System.Collections.Generic;
using System.Dynamic;
using Facebook;

namespace CMSEmergencySystem
{
    public partial class Default : System.Web.UI.Page
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

        protected void UpdateStatustoTwitter(object sender, EventArgs e)
        {
            //The facebook json url to update the status
            string twitterURL = "https://api.twitter.com/1.1/statuses/update.json";
            string message = "whoooohooooo";

            //set the access tokens (REQUIRED)
            string oauth_consumer_key = "bZ90ol3pHIWbQudynzhNGOy3S";
            string oauth_consumer_secret = "jwuuKARCVj2AORBuEkvPvaw6DyFQTKlwdMmeexTmvbjc2UYASQ";
            string oauth_token = "847409682490642432-QNW7iK3wYSsGINN4Oe19gB3Yz7Nvfqk";
            string oauth_token_secret = "Ln87plkr89HjiqUG5OIoIEU4g5c0pOg3MNECbbQB03tBF";

            // set the oauth version and signature method
            string oauth_version = "1.0";
            string oauth_signature_method = "HMAC-SHA1";

            // create unique request details
            string oauth_nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
            System.TimeSpan timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            string oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();

            // create oauth signature
            string baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" + "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}&status={6}";

            string baseString = string.Format(
                baseFormat,
                oauth_consumer_key,
                oauth_nonce,
                oauth_signature_method,
                oauth_timestamp, oauth_token,
                oauth_version,
                Uri.EscapeDataString(message)
            );

            string oauth_signature = null;
            using (HMACSHA1 hasher = new HMACSHA1(ASCIIEncoding.ASCII.GetBytes(Uri.EscapeDataString(oauth_consumer_secret) + "&" + Uri.EscapeDataString(oauth_token_secret))))
            {
                oauth_signature = Convert.ToBase64String(hasher.ComputeHash(ASCIIEncoding.ASCII.GetBytes("POST&" + Uri.EscapeDataString(twitterURL) + "&" + Uri.EscapeDataString(baseString))));
            }

            // create the request header
            string authorizationFormat = "OAuth oauth_consumer_key=\"{0}\", oauth_nonce=\"{1}\", " + "oauth_signature=\"{2}\", oauth_signature_method=\"{3}\", " + "oauth_timestamp=\"{4}\", oauth_token=\"{5}\", " + "oauth_version=\"{6}\"";

            string authorizationHeader = string.Format(
                authorizationFormat,
                Uri.EscapeDataString(oauth_consumer_key),
                Uri.EscapeDataString(oauth_nonce),
                Uri.EscapeDataString(oauth_signature),
                Uri.EscapeDataString(oauth_signature_method),
                Uri.EscapeDataString(oauth_timestamp),
                Uri.EscapeDataString(oauth_token),
                Uri.EscapeDataString(oauth_version)
            );

            HttpWebRequest objHttpWebRequest = (HttpWebRequest)WebRequest.Create(twitterURL);
            objHttpWebRequest.Headers.Add("Authorization", authorizationHeader);
            objHttpWebRequest.Method = "POST";
            objHttpWebRequest.ContentType = "application/x-www-form-urlencoded";
            using (Stream objStream = objHttpWebRequest.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes("status=" + Uri.EscapeDataString(message));
                objStream.Write(content, 0, content.Length);
            }

            var responseResult = "";
            try
            {
                //success posting
                WebResponse objWebResponse = objHttpWebRequest.GetResponse();
                StreamReader objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                responseResult = objStreamReader.ReadToEnd().ToString();
            }
            catch (Exception ex)
            {
                //throw exception error
                responseResult = "Twitter Post Error: " + ex.Message.ToString() + ", authHeader: " + authorizationHeader;
            }
        }
    

        protected void UpdateStatustoFB(object sender, EventArgs e)
        {
            //WebRequest request = WebRequest.Create("https://graph.facebook.com/406096709760870/feed?message=Hellofans&access_token=" + FBAccessToken);
            string app_id = "1677399102562906";
            string app_secret = "77b29db9a93f9ed80dcae99b8af74a28";
            string scope = "publish_actions,manage_pages";

            if (Request["code"] == null)
            {
                Response.Redirect(string.Format(
                    "https://graph.facebook.com/oauth/authorize?client_id={0}&redirect_uri={1}&scope={2}",
                    app_id, Request.Url.AbsoluteUri, scope));
            }
            else
            {
                Dictionary<string, string> tokens = new Dictionary<string, string>();

                string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                    app_id, Request.Url.AbsoluteUri, scope, Request["code"].ToString(), app_secret);

                HttpWebRequest request = System.Net.WebRequest.Create(url) as HttpWebRequest;

                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());

                    string vals = reader.ReadToEnd();

                    foreach (string token in vals.Split(','))
                    {
                        //meh.aspx?token1=steve&token2=jake&...
                        tokens.Add(token.Substring(0, token.IndexOf(":")),
                            token.Substring(token.IndexOf(":") + 1, token.Length - token.IndexOf(":") - 1));
                    }
                }

                string access_token = tokens["{\"access_token\""];
                access_token = access_token.Replace("\"", "");
                var client = new FacebookClient(access_token);

                dynamic parameters = new ExpandoObject();
                parameters.message = "Check out this funny article";
                //parameters.link = "http://www.natiska.com/article.html";
                //parameters.picture = "http://www.natiska.com/dav.png";
                //parameters.name = "Article Title";
                //parameters.caption = "Caption for the link";
                parameters.access_token = access_token;

                //446533181408238 is my fan page
                client.Post("/406096709760870/feed", parameters);

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
                    int commentCount = 0;
                    //if ((FBFeed.FBComment1 != null) && (FBFeed.FBComment1.data.Count > 0))
                    //{
                    //    commentCount = FBFeed.FBComment1.data.Count;
                    //}
                    if (oldfeeds.data[0].Created_time != time) { 
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
                    //commentsP.InnerHtml += commentCount + " Comments";

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
                    int commentCount = 0;
                    //if ((FBFeed.FBComment1 != null) && (FBFeed.FBComment1.data.Count > 0))
                    //{
                    //    commentCount = FBFeed.FBComment1.data.Count;
                    //}

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
                    //commentsP.InnerHtml += commentCount + " Comments";

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
                    RefreshSocialFeed();
                    Thread.Sleep(10000); // 30 sec
                }
            }

            //protected void Page_Load(object sender, EventArgs e)
            //{
               
            //}

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
