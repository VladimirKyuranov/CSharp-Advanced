using System;
using System.Collections.Generic;
using System.Linq;

class MovieTime
{
    static void Main(string[] args)
    {
        string favoriteGenre = Console.ReadLine();
        string prefferedDuration = Console.ReadLine();
        int totalSeconds = 0;
        string input;
        List<Movie> movies = new List<Movie>();

        while ((input = Console.ReadLine()) != "POPCORN!")
        {
            string[] movieInfo = input.Split('|');
            string movieName = movieInfo[0];
            string movieGenre = movieInfo[1];
            string movieDuration = movieInfo[2];
            Movie movie = new Movie(movieName, movieGenre, movieDuration);
            totalSeconds += movie.DurationInSeconds;

            if (movie.Genre == favoriteGenre)
            {
                movies.Add(movie);
            }
        }

        if (prefferedDuration == "Short")
        {
            movies = movies.OrderBy(m => m.DurationInSeconds).ThenBy(m => m.Title).ToList();
        }
        else
        {
            movies = movies.OrderByDescending(m => m.DurationInSeconds).ThenBy(m => m.Title).ToList();
        }

        foreach (Movie movie in movies)
        {
            Console.WriteLine($"{movie.Title}");

            if ((input = Console.ReadLine()) != "Yes")
            {
                continue;
            }
            else
            {
                Console.WriteLine($"We're watching {movie.Title} - {movie.Duration}");
                Console.WriteLine($"Total Playlist Duration: {DurationToString(totalSeconds)}");
                break;
            }
        }
    }

    static string DurationToString(int seconds)
    {
        int hours = seconds / 3600;
        seconds %= 3600;
        int minutes = seconds / 60;
        seconds %= 60;

        return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }

    class Movie
    {
        public Movie(string title, string genre, string duration)
        {
            this.Title = title;
            this.Genre = genre;
            this.Duration = duration;
        }

        public string Title { get; }

        public string Genre { get; }

        public string Duration { get; set; }

        public int DurationInSeconds
        {
            get
            {
                string[] tokens = this.Duration.Split(':');
                int seconds = 0;

                seconds += int.Parse(tokens[0]) * 3600;
                seconds += int.Parse(tokens[1]) * 60;
                seconds += int.Parse(tokens[2]);

                return seconds;
            }
        }
    }
}