﻿namespace MovieLibrary.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Director { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public List<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}