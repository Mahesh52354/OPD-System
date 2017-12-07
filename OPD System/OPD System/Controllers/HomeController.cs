using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPD_System.Models;

namespace OPD_System.Controllers
{
    [SessionTimeout]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ErrorPage()
        {
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult StaffRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StaffRegistration(StaffRegistration obj)
        {
            return View();
        }

        public ActionResult Registration()
        {
            return View();
        }
    }
}