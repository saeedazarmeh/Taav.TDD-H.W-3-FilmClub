using FilmClub.Contracts.InfraStucture;
using FilmClub.Entity.Gentes;
using FilmClub.Service.Contracts;
using FilmClub.Service.Genres.Contracts;
using FilmClub.Service.Genres.Contracts.DTO;
using FilmClub.Service.Genres.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Service.Genres
{
    public class GenreManagementAppService:GenreManagementService
    {
        private readonly GenreRepository _repository;
        private readonly UnitOfWork _unit;

        public GenreManagementAppService(GenreRepository repository, UnitOfWork unit)
        {
            _repository = repository;
            _unit = unit;
        }
        public async Task Add(AddGenreDTO addGenreDTO)
        {
            if (await _repository.ExistTitle(addGenreDTO.Title))
            {
                throw new DuplicateGenreTitleException();
            }
            var genre = new Genre(addGenreDTO.Title);
            _repository.Add(genre);
            await _unit.Complete();
        }
    }
}
