using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Binder
{
	public class LoginBinder : IModelBinder
	{
		public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
		{
			var model = new LoginModel()
			{
				Login = controllerContext.HttpContext.Request.Form["Login"],
				Password = controllerContext.HttpContext.Request.Form["Password"]
			};
			return model;
		}
	}
}