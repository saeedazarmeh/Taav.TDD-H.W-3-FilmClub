using FilmClub.Contracts.InfraStucture;
using FilmClub.prersistance;
using FilmClub.prersistance.Genres;
using FilmClub.Service.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.TestTools.InfraSteructure.Genres.Factory
{
    public static class CreateGenerServiceFactory
    {
        public static GenreManagementAppService Create(EFDataContext context)
        {
            var repository = new EFGenreRepository(context.Genres);
            var unit = new EFUnitOfWork(context);
            return new GenreManagementAppService(repository, unit);
        }
    }
}
