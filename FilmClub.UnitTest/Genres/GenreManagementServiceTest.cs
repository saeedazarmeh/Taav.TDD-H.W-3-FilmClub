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
        private EFInMemoryDatabase db;
        private EFDataContext context;
        private EFDataContext readContext;

        public GenreManagementServiceTest()
        {
            db = CreateEfInmemoryDataBaseFactory.Create();
            context = db.CreateDataContext<EFDataContext>();
            readContext = db.CreateDataContext<EFDataContext>();
        }

        [Fact]
        public async Task Add_Add_One_Genre_Properly()
        {
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
            var sut = CreateGenerServiceFactory.Create(context);
            var title = "Title";
            var genre1 = new CreateGenreBuilder().WithTitle(title).Builder();
            var genre2 = CreateAddGenreDTOFactory.Create();

            context.Save(genre1);
            var action = async () => await sut.Add(genre2);

            action.Should().ThrowAsync<DuplicateGenreTitleException>();

        }

        [Fact]
        public async Task Update_Update_One_Genre_Properly()
        {
           
            var sut = CreateGenerServiceFactory.Create(context);
            var genre = new CreateGenreBuilder().Builder();
            var updateDTO = CreateUpdateGenreDTOFactory.Create();

            context.Save(genre);
            await sut.Update(1, updateDTO);

            var actual = readContext.Genres.FirstOrDefault();
            actual.Title.Should().Be(updateDTO.Title);

        }

        [Fact]
        public async Task Update_Should_Throw_GenreNotFoundException_Because_Of_Duplicate_Title()
        {
            var updateDTO = CreateUpdateGenreDTOFactory.Create();
            var sut = CreateGenerServiceFactory.Create(context);

            var action=async () =>await sut.Update(3, updateDTO);

            action.Should().ThrowAsync<GenreNotFoundException>();
        }
    }
}
