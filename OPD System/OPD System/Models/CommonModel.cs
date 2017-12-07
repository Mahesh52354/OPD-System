using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace OPD_System.Models
{
    public class Common
    {
        public static string ToXML(object obj)
        {
            var stringwriter = new System.IO.StringWriter();
            var serializer = new XmlSerializer(obj.GetType());
            serializer.Serialize(stringwriter, obj);
            return stringwriter.ToString();
        }
                
        public static string[] notificationMsg(DataSet ds)
        {
            string[] str = new string[2];
            if (ds != null)
            {
                if (ds.Tables[0].Rows[0][0].ToString() == "Success")
                {
                    str[0] = "success";
                }
                else
                {
                    str[0] = "danger";
                }
                str[1] = ds.Tables[0].Rows[0][1].ToString();
            }
            return str;
        }
    }
    public class SessionTimeoutAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;
            if(HttpContext.Current.Session["UserName"]==null&& HttpContext.Current.Session["UserRole"] == null)
            {

                filterContext.Result = new RedirectResult("~/Account/Signin");
                return;
            }

            base.OnActionExecuting(filterContext);
        }
    }

    public class dbconnection
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);

        public DataSet ExecuteQuery(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, con);
                DataSet ds = new DataSet();
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                adt.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }

        }
        public DataSet ExecuteProcedure(string SpName)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = SpName;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                adt.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }

        }

        public DataSet ExecuteProcedure(string SpName, string xml)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = SpName;
                cmd.Parameters.AddWithValue("@xmltext", xml);
                cmd.Connection = con;
                DataSet ds = new DataSet();
                SqlDataAdapter adt = new SqlDataAdapter(cmd);
                adt.Fill(ds);
                return ds;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}