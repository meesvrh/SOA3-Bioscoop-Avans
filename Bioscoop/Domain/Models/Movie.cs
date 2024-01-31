using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Movie
    {
        public string Title { get; }
        private List<MovieScreening>? movieScreenings;

        public Movie(string title)
        {
            Title = title;
        }

        public void addScreening(MovieScreening screening)
        {
            if (this.movieScreenings == null)
            {
                this.movieScreenings = new List<MovieScreening>();
            }
            
            this.movieScreenings.Add(screening);
        }

        public string toString()
        {
            return "Movie |-| Title: " + Title;
        }
    }
}
