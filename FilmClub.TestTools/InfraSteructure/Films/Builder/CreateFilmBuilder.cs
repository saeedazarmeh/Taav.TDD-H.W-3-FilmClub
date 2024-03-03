using FilmClub.Entity.Films;
using FilmClub.Entity.Gentes;
using FilmClub.TestTools.InfraSteructure.Genres.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.TestTools.InfraSteructure.Films.Builder
{
    public class CreateFilmBuilder
    {
        private readonly Film _film;
        public CreateFilmBuilder()
        {
            _film = new Film("Title1",180,2021,12);
            _film.AddGenre(new Genre("title"));
            _film.AddAmount(new Entity.Films.ValiuOBject.Amount(20000, 15, 10));
        }

        //public CreateFilmBuilder WithTitle(string title)
        //{
        //    _film.TitleEdit(title);
        //    return this;
        //}

        public Film Builder()
        {
            return _film;
        }
    }
}
