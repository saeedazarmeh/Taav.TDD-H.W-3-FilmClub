using FilmClub.prersistance.Films;
using FilmClub.prersistance.Genres;
using FilmClub.prersistance;
using FilmClub.Service.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmClub.TestTools.InfraSteructure.InMemorySingleton;

namespace FilmClub.TestTools.InfraSteructure.Films.Fixture
{
    public class FilmServiceFixture:IDisposable
    {
        public FilmManagementAppService sut { get; set; }
        public FilmServiceFixture()
        {
            var context=CreateInMemoryDatabaseSingleton.Singleton().CreateDataContext<EFDataContext>();
            var filmRepository = new EFFilmRepository(context.Films);
            var genreRepository = new EFGenreRepository(context.Genres);
            var unit = new EFUnitOfWork(context);
            sut= new FilmManagementAppService(filmRepository, unit, genreRepository);
        }
        public void Dispose()
        {
            sut.Dispose();
        }
    }
}
