using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cinema.Binder;

namespace Cinema.Models
{
	//Comment - иначе не будут работать атрибуты для валидации или нужно писать логику в binder'e
	//[ModelBinder(typeof(LoginBinder))]
	public class LoginModel
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "это поле является обязательным")]
		[MinLength(5, ErrorMessage = "Логин не должен быть меньше 5 символов")]
		public string Login { get; set; }

		[Required(AllowEmptyStrings = false,ErrorMessage = "это поле является обязательным")]
		public string Password { get; set; }

	}
}