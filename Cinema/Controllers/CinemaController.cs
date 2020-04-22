using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    public class CinemaController : Controller
    {
        // GET: Cinema
        public ActionResult Index(string param)
        {
			ViewBag.Standart = "start ViewBag";
            return View(new CinemaViewModel() { Author = "I'm the author the site!!!"});
			
        }
    }
}