using FilmClub.Entity.Films.ValiuOBject;
using FilmClub.Entity.Gentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Entity.Films
{
    public class Film
    {
        public Film(string title, int durationPerMinuts, int createdYear, int limitatedAge)
        {
            Title = title;
            Description = null;
            DurationPerMinuts = durationPerMinuts;
            CreatedYear = createdYear;
            LimitatedAge = limitatedAge;
            Rate = 0;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string? Description { get; private set; }
        public int DurationPerMinuts { get; private set; }
        public int CreatedYear { get; private set; }
        public int LimitatedAge { get; private set; }
        public int Rate { get; private set; }
        public Amount Amount { get; private set; }
        public int GenreId { get; private set; }
        public Genre Genre { get; private set; }

        public void AddGenre(Genre genre)
        {
            Genre = genre;
        }

        public void PublicEdit(string? title=null, int durationPerMinuts = 0, int createdYear=0, int limitatedAge =0)
        {
            if(title != null)
            {
                Title = title;
            }
            if(durationPerMinuts != 0)
            {
                DurationPerMinuts = durationPerMinuts;
            }
            if (createdYear != 0 )
            {
                CreatedYear = createdYear;
            }
            if(limitatedAge != 0)
            {
                LimitatedAge = limitatedAge;
            }
        }
        public void AddRate()
        {
            Rate++;
        }
        public void AddAmount(Amount amount)
        {
            Amount = amount;
        }
        public void DescriptionEdit( string? description)
        {
            Description = description;
        }
    }
}
