using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.Binder;

namespace Cinema.Models
{
	[ModelBinder(typeof(LoginBinder))]
	public class LoginModel
	{
		public string Login { get; set; }
		public string Password { get; set; }

	}
}