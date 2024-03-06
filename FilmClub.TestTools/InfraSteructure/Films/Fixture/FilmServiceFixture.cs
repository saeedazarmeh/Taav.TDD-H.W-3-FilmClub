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
using Moq;
using FilmClub.Service.Auth;

namespace FilmClub.TestTools.InfraSteructure.Films.Fixture
{
    public class FilmServiceFixture:IDisposable
    {
        public FilmManagementAppService sut { get; set; }
        public Mock<AuthRepository> mock = new Mock<AuthRepository>();
        public FilmServiceFixture()
        {
            var context=CreateInMemoryDatabaseSingleton.Singleton().CreateDataContext<EFDataContext>();
            var filmRepository = new EFFilmRepository(context.Films);
            var genreRepository = new EFGenreRepository(context.Genres);
            mock.Setup(a=>a.IsAthonticated()).Returns(true);    
            mock.Setup(a=>a.HasPermission()).Returns(true);
            var unit = new EFUnitOfWork(context);
            sut= new FilmManagementAppService(filmRepository, unit, genreRepository,mock.Object);
        }
        public void Dispose()
        {
            sut.Dispose();
        }
    }
}
