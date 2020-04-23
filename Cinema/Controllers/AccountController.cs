using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
	public class AccountController : Controller
	{
        // GET: Account
		[HttpGet]
        public ActionResult Login()
        {
			var model = new LoginModel(){Login="Piter", Password = "Piter"};
            return View(model);
        }

		[HttpPost]
		public ActionResult Login(LoginModel model)
		{
			if (ModelState.IsValid)
			{
				return View("LoginResult",model);
			}
			return View(model);
		}
    }
}