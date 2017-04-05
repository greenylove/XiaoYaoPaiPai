
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMSEmergencySystem.Entities
{
    public class FacebookFeed
    {
        private string full_picture; 
        private string picture;
        private string message;
        private string created_time;
        private string link;
        private string name;
        private string description;
        //private FacebookComments FBComment;

        public FacebookFeed()
        {
        }

        //Constructor 
        public FacebookFeed(string fullpic, string pic, string msg, string time, string Link, string Name, string desc, string comment)
        {
            this.full_picture = fullpic;
            this.picture = pic;
            this.message = msg;
            this.created_time = time;
            this.link = Link;
            this.name = Name;
            this.description = desc;
            //FacebookComments comments = JsonConvert.DeserializeObject<FacebookComments>(comment);
            //sthis.FBComment = comments;
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public string Created_time
        {
            get
            {
                return created_time;
            }

            set
            {
                created_time = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Link
        {
            get
            {
                return link;
            }

            set
            {
                link = value;
            }
        }

        public string Picture
        {
            get
            {
                return picture;
            }

            set
            {
                picture = value;
            }
        }

        public string Full_picture
        {
            get
            {
                return full_picture;
            }

            set
            {
                full_picture = value;
            }
        }

        //public FacebookComments FBComment1
        //{
        //    get
        //    {
        //        return FBComment;
        //    }

        //    set
        //    {
        //        FBComment = value;
        //    }
        //}

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
    }
}