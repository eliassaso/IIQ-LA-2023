using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4NetFrame.Models;

namespace WebApplication4NetFrame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var studentIds = new string[10] { "Pedro", "Pablo", "Juan", "Antonio", "Carlos", "hugo", "Michael", "Mario", "Daniel", "Paquita" };
            ViewBag.Message = studentIds[7];
            Result test = new Result();
            test.value = studentIds[0];
            return View(test);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}