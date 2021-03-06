﻿using System;
using System.Collections.Generic;
using Cinema.Models.Domain;

namespace Cinema.Interfaces
{
	public interface ITicketService
	{
		Movie GetMovieById(int id);
		Movie[] GetAllMovies();

		Hall GetHallById(int id);
		Hall[] GetAllHall();

		TimeSlot GetTimeSlotById(int id);
		TimeSlot[] GetAllTimeSlots();

		bool UpdateMovie(Movie updateMovie);

		bool UpdateTimeSlot(TimeSlot updateTimeSlot);

		TimeSlot[] GetTimeSlotsByMovieId(int id);

		Hall[] GetHalls();

		bool UpdateHall(Hall hall);
	}
}