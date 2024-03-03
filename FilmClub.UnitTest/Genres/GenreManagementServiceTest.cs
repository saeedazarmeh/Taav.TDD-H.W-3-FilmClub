using FilmClub.prersistance;
using FilmClub.Service.Genres.Exceptions;
using FilmClub.TestTools.InfraSteructure.DataBaseConfig.Unit;
using FilmClub.TestTools.InfraSteructure.Genres.Builder;
using FilmClub.TestTools.InfraSteructure.Genres.Factory;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.UnitTest.Genres
{
    public class GenreManagementServiceTest
    {
        [Fact]
        public async Task Add_Add_One_Genre_Properly()
        {
            var db = CreateEfInmemoryDataBaseFactory.Create();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = CreateGenerServiceFactory.Create(context);
            var dto = CreateAddGenreDTOFactory.Create();

            await sut.Add(dto);

            var actual = readContext.Genres.First();
            actual.Title.Should().Be(dto.Title);
            actual.Rate.Should().Be(0);
        }

        [Fact]
        public async Task Add_Should_Throw_DuplicateGenreTitleException_Because_Of_Duplicate_Title()
        {
            var db = CreateEfInmemoryDataBaseFactory.Create();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = CreateGenerServiceFactory.Create(context);
            var title = "Title";
            var genre1 = new CreateGenreBuilder().WithTitle(title).Builder();
            var genre2 =CreateAddGenreDTOFactory.Create();

            context.Save(genre1);
            var action=async ()=>await sut.Add(genre2);

            action.Should().ThrowAsync<DuplicateGenreTitleException>();

        }
    }
}
