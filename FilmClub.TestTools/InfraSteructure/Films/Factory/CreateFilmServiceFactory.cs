using FilmClub.prersistance;
using FilmClub.prersistance.Films;
using FilmClub.prersistance.Genres;
using FilmClub.Service.Films;
using FilmClub.Service.Genres.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.TestTools.InfraSteructure.Films.Factory
{
    public class CreateFilmServiceFactory
    {
        public static FilmManagementAppService Create(EFDataContext context)
        {
            var filmRepository = new EFFilmRepository(context.Films);
            var genreRepository = new EFGenreRepository(context.Genres);
            var unit = new EFUnitOfWork(context);
            return new FilmManagementAppService(filmRepository, unit, genreRepository);
        } 
    }
}
