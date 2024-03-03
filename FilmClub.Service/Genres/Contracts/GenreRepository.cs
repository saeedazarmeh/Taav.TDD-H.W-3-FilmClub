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
        Task<bool> ExistTitle(string title);
    }
}
