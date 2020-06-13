using System.IO;
using System.Linq;
using System.Web;
using Cinema.Interfaces;
using Cinema.Models;
using Cinema.Models.Domain;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace Cinema.Services
{
	public class JsonTicketServices:ITicketService
	{
		private const string path = "/Files/Data.json";
		public HttpContext Context { get; set; }

		public JsonTicketServices(HttpContext context)
		{
			Context = context;
		}

		public Movie GetMovieById(int id)
		{
			#region Работа Linq

			//Аналог того, что делает LINQ
			//Movie movi;
			//foreach (var mobie in fullModel.Movies)
			//{
			//	if (mobie.Id == id)
			//	{
			//		movi = mobie;
			//		break;
			//	}
			//}

			//return movi;
			#endregion

			var fullModel = GetDataFromFile();
			//Идем циклом по всем фильмам 1-ый элемент который удовлетворяет условию, будет выбран
			return fullModel.Movies.FirstOrDefault(i=> i.Id == id);
		}

		public Movie[] GetAllMovies()
		{
			var fullModel = GetDataFromFile();
			return fullModel.Movies;
		}

		public Hall GetHallById(int id)
		{
			var fullModel = GetDataFromFile();
			return fullModel.Halls.FirstOrDefault(i => i.Id == id);
		}

		public Hall[] GetAllHall()
		{
			var fullModel = GetDataFromFile();
			return fullModel.Halls;
		}

		public TimeSlot GetTimeSlotById(int id)
		{
			var fullModel = GetDataFromFile();
			return fullModel.TimeSlots.FirstOrDefault(i => i.Id == id);
		}

		public TimeSlot[] GetAllTimeSlots()
		{
			var fullModel = GetDataFromFile();
			return fullModel.TimeSlots;
		}

		private FileModel GetDataFromFile()
		{
			var jsonFile = Context.Server.MapPath(path);
			if (!File.Exists(jsonFile))
				return null;
			var stringFile = File.ReadAllText(jsonFile);
			var fileModel = JsonConvert.DeserializeObject<FileModel>(stringFile);
			return fileModel;
		}

		public bool UpdateMovie(Movie updateMovie)
		{
			var fullModel = GetDataFromFile();
			var movieToUpdate = fullModel.Movies.FirstOrDefault(m => m.Id == updateMovie.Id);
			if (movieToUpdate == null)
				return false;
			movieToUpdate.Duration = updateMovie.Duration;
			movieToUpdate.ActorNames = updateMovie.ActorNames;
			movieToUpdate.DirectorFio = updateMovie.DirectorFio;
			movieToUpdate.Description = updateMovie.Description;
			movieToUpdate.ImageUrl = updateMovie.ImageUrl;
			movieToUpdate.MinAge = updateMovie.MinAge;
			movieToUpdate.Rating = updateMovie.Rating;
			movieToUpdate.ReleaseDate = updateMovie.ReleaseDate;
			movieToUpdate.Title = updateMovie.Title;
			if (updateMovie.Genres != null)
				movieToUpdate.Genres = updateMovie.Genres;
			SaveToFile(fullModel);

			return true;
		}

		public bool UpdatetimeSlot(TimeSlot timeSlot)
		{
			var fullModel = GetDataFromFile();
			var timeSlotUpdate = fullModel.TimeSlots.FirstOrDefault(t => t.Id == timeSlot.Id);
			if (timeSlotUpdate == null)
			{
				return false;
			}

			timeSlotUpdate.StartTime = timeSlot.StartTime;
			timeSlotUpdate.Cost = timeSlot.Cost;
			timeSlotUpdate.Format = timeSlot.Format;
			timeSlotUpdate.MovieId = timeSlot.MovieId;
			timeSlotUpdate.HallId = timeSlot.HallId;

			SaveToFile(fullModel);
			return true;
		}

		//Возможность просмотра TimeSlot для конкретного фильма, то есть в каких сеансах он идет
		public TimeSlot[] GetTimeSlotsByMovieId(int movieId)
		{
			var fullModel = GetDataFromFile();
			return fullModel.TimeSlots.Where(ts => ts.MovieId == movieId).ToArray();
		}

		private void SaveToFile(FileModel fullModel)
		{
			//путь к файлу
			var jsonFilePath = Context.Server.MapPath(path);
			 // сериализуем модель в json
			var serializeJson = JsonConvert.SerializeObject(fullModel);
			//Пишем в файл
			File.WriteAllText(jsonFilePath,serializeJson);
		}
	}
}