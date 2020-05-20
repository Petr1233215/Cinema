 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 using Cinema.Models;
 using Cinema.Models.Domain;
 using Newtonsoft.Json;

 namespace Cinema.Controllers
{
    public class AdminController : Controller
    {
	    private const string path = "/Files/Data.json";
		// GET: Admin
		public ActionResult Index()
        {
			var movies = new Movie[]
			{
				new Movie()
				{
					Id = 1,
					Title = "Однажды в голивуде",
					Description = "1969 год, золотой век Голливуда уже закончился. Известный актёр Рик Далтон и его дублер Клифф Бут пытаются найти свое место в стремительно меняющемся мире киноиндустрии.",
					ActorNames = new string[]{"Di Kaprio", "Брэд Питт", "Маргарет Куэлли",  "Дакота Фаннинг" },
					Duration = 161,
					DirectorFio = "Kventin",
					Genres = new Genre[] {Genre.Comedy, Genre.Drama},
					ImageUrl = "https://st.kp.yandex.net/images/film_iphone/iphone360_1047883.jpg",
					MinAge = 18,
					Rating = 7.6f,
					ReleaseDate = 2019
				}
			};

			var halls = new Hall[]
			{
				new Hall()
				{
					Id = 1,
					Name = "Hall 1",
					Places = 50
				},
				new Hall()
				{
					Id = 2,
					Name = "Hall 2",
					Places = 100
				}
			};

			var timeSlots = new TimeSlot[]
			{
				new TimeSlot()
				{
					Id = 1,
					Cost = 170,
					Format = Format.TwoD,
					Hall = halls[0],
					Movie =  movies[0],
					StartTime = DateTime.Now
				},
				new TimeSlot()
				{
					Id = 1,
					Cost = 350,
					Format = Format.IMax,
					Hall = halls[1],
					Movie =  movies[0],
					StartTime = DateTime.Now
				}
			};

			var fileModel = new FileModel()
			{
				TimeSlots = timeSlots,
				Halls = halls,
				Movies = movies
			};

			

			var jsonFile = JsonConvert.SerializeObject(fileModel);

			System.IO.File.WriteAllText(HttpContext.Server.MapPath(path), jsonFile);


            return View();
        }

        public ActionResult Tickets()
        {
	        var stringFile = System.IO.File.ReadAllText(HttpContext.Server.MapPath(path));
	        var modelJson = JsonConvert.DeserializeObject<FileModel>(stringFile);

	        return View(modelJson);
        }
	}

	
}