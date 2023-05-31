using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication4NetFrame.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication4NetFrame.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var studentIds = new string[6] { "Pedro", "Pablo", "Juan", "Antonio", "Carlos","hugo" };
            ViewBag.Message = studentIds[6];
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