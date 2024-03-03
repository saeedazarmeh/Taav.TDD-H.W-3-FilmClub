using FilmClub.Entity.Gentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.TestTools.InfraSteructure.Genres.Builder
{
    public class CreateGenreBuilder
    {
        private readonly Genre _genre;
        public CreateGenreBuilder()
        {
            _genre = new Genre("Title1");
        }

        public CreateGenreBuilder WithTitle(string title)
        {
            _genre.TitleEdit(title);
            return this;
        }

        public Genre Builder()
        {
            return _genre;
        }
    }
}
