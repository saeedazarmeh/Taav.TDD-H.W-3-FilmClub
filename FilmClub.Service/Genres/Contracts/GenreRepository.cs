using FilmClub.Entity.Gentes;
using FilmClub.Service.Genres.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Service.Contracts
{
    public interface GenreRepository
    {
        public void Add(Genre genre);
        public Task<Genre> GetAsynk(int id);
        Task<bool> ExistTitleAsync(string title);
        void Update(Genre genre);
    }
}
