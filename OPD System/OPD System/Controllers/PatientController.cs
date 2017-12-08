using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OPD_System.Models;

namespace OPD_System.Controllers
{
    [SessionTimeout]
    public class PatientController : Controller
    {
        public ActionResult PatientRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PatientRegistration(PatientRegistration obj)
        {
            return View();
        }

        public JsonResult getPatient(int patientid)
        {


            return Json("", JsonRequestBehavior.AllowGet);
        }


        public ActionResult Treatment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Treatment(PatientTreatment obj)
        {
            return View();
        }
       
    }
}