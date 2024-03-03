using FilmClub.Entity.Films;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Service.Films.Contracts
{
    public interface FilmRepository
    {
        void Add(Film film);
        Task<Film> GetAsync(int id);
        void Update(Film film); 
    }
}
