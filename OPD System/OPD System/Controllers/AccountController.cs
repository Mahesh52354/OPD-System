using OPD_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OPD_System.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signin(login obj)
        {
            if (obj.loginid.Length < 10 || obj.loginid.Length > 10)
            {
                obj.mailid = obj.loginid;
                obj.confirmLoginDetails();
                ViewBag.Msg = "";
            }
            else
            {
                obj.mobile = obj.loginid;
                string[] str = obj.confirmLoginDetails();
                ViewBag.Msg = "";
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("signin");
        }

        [SessionTimeout]
        public ActionResult Profile()
        {
            return View();
        }

        [SessionTimeout]
        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string s)
        {
            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
    }
}