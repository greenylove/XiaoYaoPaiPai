using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Dynamic;
using Facebook;
using System.Web;

namespace CMSEmergencySystem.Controllers
{
    public class NewsFeedController
    {
        public void UpdateStatustoTwitter(string message)
        {
            string twitterURL = "https://api.twitter.com/1.1/statuses/update.json";

            string oauth_consumer_key = "bZ90ol3pHIWbQudynzhNGOy3S";
            string oauth_consumer_secret = "jwuuKARCVj2AORBuEkvPvaw6DyFQTKlwdMmeexTmvbjc2UYASQ";
            string oauth_token = "847409682490642432-QNW7iK3wYSsGINN4Oe19gB3Yz7Nvfqk";
            string oauth_token_secret = "Ln87plkr89HjiqUG5OIoIEU4g5c0pOg3MNECbbQB03tBF";

            string oauth_version = "1.0";
            string oauth_signature_method = "HMAC-SHA1";

            string oauth_nonce = Convert.ToBase64String(new ASCIIEncoding().GetBytes(DateTime.Now.Ticks.ToString()));
            System.TimeSpan timeSpan = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));
            string oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();

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
                WebResponse objWebResponse = objHttpWebRequest.GetResponse();
                StreamReader objStreamReader = new StreamReader(objWebResponse.GetResponseStream());
                responseResult = objStreamReader.ReadToEnd().ToString();
            }
            catch (Exception ex)
            {
                responseResult = "Twitter Post Error: " + ex.Message.ToString() + ", authHeader: " + authorizationHeader;
            }
        }

        public void UpdateStatustoFB(string message)
        {
            string app_id = "1677399102562906";
            string app_secret = "77b29db9a93f9ed80dcae99b8af74a28";
            string scope = "publish_actions,manage_pages";

            Dictionary<string, string> tokens = new Dictionary<string, string>();

            string url = string.Format("https://graph.facebook.com/oauth/access_token?client_id={0}&redirect_uri={1}&scope={2}&code={3}&client_secret={4}",
                app_id, HttpContext.Current.Request.Url.AbsoluteUri, scope, HttpContext.Current.Request["code"].ToString(), app_secret);

            HttpWebRequest request = System.Net.WebRequest.Create(url) as HttpWebRequest;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());

                string vals = reader.ReadToEnd();

                foreach (string token in vals.Split(','))
                {
                    tokens.Add(token.Substring(0, token.IndexOf(":")),
                        token.Substring(token.IndexOf(":") + 1, token.Length - token.IndexOf(":") - 1));
                }
            }

            string access_token = tokens["{\"access_token\""];
            access_token = access_token.Replace("\"", "");
            var client = new FacebookClient(access_token);

            dynamic parameters = new ExpandoObject();
            parameters.message = message;
            parameters.access_token = access_token;

            client.Post("/406096709760870/feed", parameters);
        }

    }
}