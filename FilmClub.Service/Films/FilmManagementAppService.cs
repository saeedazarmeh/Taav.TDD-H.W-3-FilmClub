using FilmClub.Contracts.InfraStucture;
using FilmClub.Entity.Films;
using FilmClub.Entity.Films.ValiuOBject;
using FilmClub.Service.Auth;
using FilmClub.Service.Films.Contracts;
using FilmClub.Service.Films.Contracts.DTO;
using FilmClub.Service.Films.Exceptions;
using FilmClub.Service.Genres.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Service.Films
{
    public class FilmManagementAppService : FilmManagementService,IDisposable
    {
        private readonly FilmRepository _filmrepository;
        private readonly GenreRepository _genrerepository;
        private readonly UnitOfWork _unit;
        private readonly AuthRepository _auth;

        public FilmManagementAppService(FilmRepository repository, UnitOfWork unit,GenreRepository genreRepository, AuthRepository auth)
        {
            _filmrepository = repository;
            _genrerepository = genreRepository;
            _unit = unit;
            _auth = auth;
        }

        public async Task Add(AddFilmeDTO addFilmeDTO)
        {
            if (_auth.HasPermission() && _auth.IsAthonticated())
            {
                var genre = await _genrerepository.GetAsynk(addFilmeDTO.GenreId);
                if (genre == null)
                {
                    throw new DataNotFoundException();
                }
                var amount = new Amount(addFilmeDTO.Price, addFilmeDTO.DelayPenaltyPersantage, addFilmeDTO.RentPrice);
                var film = new Film(addFilmeDTO.Title, addFilmeDTO.DurationPerMinuts, addFilmeDTO.CreatedYear, addFilmeDTO.LimitatedAge);
                film.AddAmount(amount);
                film.AddGenre(genre);
                _filmrepository.Add(film);
                _unit.Complete();
            }
        }

        public void Dispose()
        {
            
        }

        public async Task UpdatePublicData(int id, UpdatePublicFilmeDTO dTO)
        {
            var film = await _filmrepository.GetAsync(id);
            if(film == null)
            {
                throw new DataNotFoundException();
            }
            film.PublicEdit(dTO.Title,dTO.DurationPerMinuts,dTO.CreatedYear,dTO.LimitatedAge);
            var genre=await _genrerepository.GetAsynk(dTO.GenreId);
            if(genre == null) 
            {
                throw new DataNotFoundException(); 
            }
            film.AddGenre(genre);
            _filmrepository.Update(film);
            await _unit.Complete();
        }
    }
}
