 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 using Cinema.Interfaces;
 using Cinema.Models;
 using Cinema.Models.Domain;
 using Cinema.Services;
 using Newtonsoft.Json;

 namespace Cinema.Controllers
{
    public class AdminController : Controller
    {
		#region OldLogic
		//   private const string path = "/Files/Data.json";
		//// GET: Admin

		#region CreatJsonFile
		//public ActionResult Index()
		//      {
		//	var movies = new Movie[]
		//	{
		//		new Movie()
		//		{
		//			Id = 1,
		//			Title = "Однажды в голивуде",
		//			Description = "1969 год, золотой век Голливуда уже закончился. Известный актёр Рик Далтон и его дублер Клифф Бут пытаются найти свое место в стремительно меняющемся мире киноиндустрии.",
		//			ActorNames = new string[]{"Di Kaprio", "Брэд Питт", "Маргарет Куэлли",  "Дакота Фаннинг" },
		//			Duration = 161,
		//			DirectorFio = "Kventin",
		//			Genres = new Genre[] {Genre.Comedy, Genre.Drama},
		//			ImageUrl = "https://st.kp.yandex.net/images/film_iphone/iphone360_1047883.jpg",
		//			MinAge = 18,
		//			Rating = 7.6f,
		//			ReleaseDate = 2019
		//		}
		//	};

		//	var halls = new Hall[]
		//	{
		//		new Hall()
		//		{
		//			Id = 1,
		//			Name = "Hall 1",
		//			Places = 50
		//		},
		//		new Hall()
		//		{
		//			Id = 2,
		//			Name = "Hall 2",
		//			Places = 100
		//		}
		//	};

		//	var timeSlots = new TimeSlot[]
		//	{
		//		new TimeSlot()
		//		{
		//			Id = 1,
		//			Cost = 170,
		//			Format = Format.TwoD,
		//			Hall = halls[0],
		//			Movie =  movies[0],
		//			StartTime = DateTime.Now
		//		},
		//		new TimeSlot()
		//		{
		//			Id = 1,
		//			Cost = 350,
		//			Format = Format.IMax,
		//			Hall = halls[1],
		//			Movie =  movies[0],
		//			StartTime = DateTime.Now
		//		}
		//	};

		//	var fileModel = new FileModel()
		//	{
		//		TimeSlots = timeSlots,
		//		Halls = halls,
		//		Movies = movies
		//	};



		//	var jsonFile = JsonConvert.SerializeObject(fileModel);

		//	System.IO.File.WriteAllText(HttpContext.Server.MapPath(path), jsonFile);


		//          return View();
		//      }


		#endregion


		//      public ActionResult Tickets()
		//      {
		//       var stringFile = System.IO.File.ReadAllText(HttpContext.Server.MapPath(path));
		//       var modelJson = JsonConvert.DeserializeObject<FileModel>(stringFile);

		//       return View(modelJson);
		//      }


		#endregion

		private readonly ITicketService jsonTicketService;

		public AdminController()
		{
			jsonTicketService = new JsonTicketServices(System.Web.HttpContext.Current);
		}

		public ActionResult FindMovieById(int id)
		{
			var movie = jsonTicketService.GetMovieById(id);
			if (movie == null)
				return Content($"Movie such id:{id} does not find", "application/json");
			var movieJson = JsonConvert.SerializeObject(movie);
			return Content(movieJson, "application/json");
		}

		public ActionResult FindHallById(int id)
		{
			var hall = jsonTicketService.GetHallById(id);
			if (hall == null)
			{
				return Content($"Hall such id:{id} does not find", "application/json");
			}

			var hallJson = JsonConvert.SerializeObject(hall);
			return Content(hallJson, "applicant/json");
		}

		public ActionResult FindTimeSlotById(int id)
		{
			var timeSlot = jsonTicketService.GetTimeSlotById(id);
			if(timeSlot == null)
				return Content($"TimeSlot such id:{id} does not find", "application/json");
			var timeSlotJson = JsonConvert.SerializeObject(timeSlot);
			return Content(timeSlotJson, "applicant/json");
		}

		public ActionResult DisplayMoviesList()
		{
			var modelMovie = jsonTicketService.GetAllMovies();

			return View(modelMovie);
		}
		
		
		[HttpGet]
		public ActionResult EditMovie(int id)
		{
			var getMovie = jsonTicketService.GetMovieById(id);
			return View(getMovie);
		}

		[HttpPost]
		public ActionResult EditMovie(Movie model)
		{
			if (ModelState.IsValid)
			{
				var isUpdate = jsonTicketService.UpdateMovie(model);
				if (isUpdate)
				{
					return RedirectToAction("DisplayMoviesList");
				}

				return Content("Update failed");
			}

			return View("EditMovie",model);
		}

		public ActionResult EditTimeSlot(int id)
		{
			var timeSlot = jsonTicketService.GetTimeSlotById(id);
			return View(timeSlot);
		}
    }


}