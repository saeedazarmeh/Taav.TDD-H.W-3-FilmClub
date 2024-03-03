using FilmClub.prersistance;
using FilmClub.Service.Films.Exceptions;
using FilmClub.TestTools.InfraSteructure.DataBaseConfig.Unit;
using FilmClub.TestTools.InfraSteructure.Films.Builder;
using FilmClub.TestTools.InfraSteructure.Films.Factory;
using FilmClub.TestTools.InfraSteructure.Genres.Builder;
using FilmClub.TestTools.InfraSteructure.Genres.Factory;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CreateEfInmemoryDataBaseFactory = FilmClub.TestTools.InfraSteructure.Films.Factory.CreateEfInmemoryDataBaseFactory;

namespace FilmClub.UnitTest.Films
{
    public class FilmManagementServiceTest
    {
        [Fact]
        public async Task Add_Add_One_Film_Properly()
        {
            var db = CreateEfInmemoryDataBaseFactory.Create();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = CreateFilmServiceFactory.Create(context);
            var genre = new CreateGenreBuilder().Builder();
            var dto = AddFilmDTOFactoty.Create(null,1);

            context.Save(genre);
            await sut.Add(dto);

            var actual=readContext.Films.First();
            actual.Title.Should().Be(dto.Title);
            actual.Amount.Price.Should().Be(dto.Price);
            actual.GenreId.Should().Be(dto.GenreId);

        }

        [Fact]
        public async Task Add_Should_throw_DataNotFoundException_Becuse_OfNotFounding_Genre()
        {
            var db = CreateEfInmemoryDataBaseFactory.Create();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = CreateFilmServiceFactory.Create(context);
            var dto = AddFilmDTOFactoty.Create(null, 1);

            var action=async()=> await sut.Add(dto);

            await action.Should().ThrowAsync<DataNotFoundException>();
        }
        [Fact]
        public async Task PublicUpdate_Update_Film_Properly()
        {
            var db = CreateEfInmemoryDataBaseFactory.Create();
            var context = db.CreateDataContext<EFDataContext>();
            var readContext = db.CreateDataContext<EFDataContext>();
            var sut = CreateFilmServiceFactory.Create(context);
            var genre = new CreateGenreBuilder().Builder();
            var film = new CreateFilmBuilder().Builder();
            var updatePublic = AddUpdatePublicFilmeDTOFacrory.Create();

            context.Save(genre);
            context.Save(film);
            await sut.UpdatePublicData(1, updatePublic);

            var actual = await readContext.Films.FirstOrDefaultAsync();
            actual.Title.Should().Be(updatePublic.Title);
            actual.LimitatedAge.Should().Be(updatePublic.LimitatedAge);
            actual.GenreId.Should().Be(updatePublic.GenreId);
        }
    }
}
