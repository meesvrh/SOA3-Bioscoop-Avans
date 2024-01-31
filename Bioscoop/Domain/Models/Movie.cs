using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Movie
    {
        private string title;
        private List<MovieScreening>? movieScreenings;

        public Movie(string title)
        {
            this.title = title;
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
            return "Movie: " + this.title;
        }   
    }
}
