using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace OPD_System.Models
{
    public class User
    {
        public int hid { get; set; }
        public int userid { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string mailid { get; set; }
        public string country_code { get; set; }
        public string mobile { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string dob { get; set; }
        public string gender { get; set; }
        public string create_dt { get; set; }
        public string updateby { get; set; }
        public string update_dt { get; set; }
    }

    public class role
    {
        public int hid { get; set; }
        public int roleid { get; set; }
        public string rolename { get; set; }
        public string create_dt { get; set; }
        public string updateby { get; set; }
        public string update_dt { get; set; }
    }

    public class login
    {
        public int userid { get; set; }
        public int hid { get; set; }
        public int roleid { get; set; }
        public string loginid { get; set; }
        public string mailid { get; set; }
        public string mobile { get; set; }
        public string password { get; set; }        
        public string CMD { get; set; }

        public string[] confirmLoginDetails()
        {
            this.CMD = "ConfirmLogin";
            string xml = Common.ToXML(this);
            dbconnection con = new dbconnection();
            DataSet ds = con.ExecuteProcedure("SP_Login", xml);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    HttpContext.Current.Session["UserName"] = ds.Tables[0].Rows[0]["UserName"];
                    HttpContext.Current.Session["UserRole"] = ds.Tables[0].Rows[0]["UserRole"];
                }
            }
            return Common.notificationMsg(ds);
        }
    }
}