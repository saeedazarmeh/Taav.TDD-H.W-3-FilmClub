using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Entity.Gentes
{
    public class Genre
    {
        public Genre(string title)
        {
            Title = title;
            Rate = 0;
        }
        public int Id { get;private set; }
        public string Title { get;private set; }
        public int Rate { get; private set; }
        public void TitleEdit(string title)
        {
            Title = title;
        }
        public void RateEdit(int rate)
        {
            Rate=rate;
        }
    }
   
}
