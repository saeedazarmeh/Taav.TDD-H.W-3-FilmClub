using FilmClub.Entity.Films;
using FilmClub.Service.Films.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.prersistance.Films
{
    public class EFFilmRepository : FilmRepository
    {
        private readonly DbSet<Film> _context;

        public EFFilmRepository(DbSet<Film> context)
        {
            _context = context;
        }

        public void Add(Film film)
        {
            _context.Add(film);
        }

        public async Task<Film> GetAsync(int id)
        {
            return await _context.FirstOrDefaultAsync(_=>_.Id==id);
        }

        public void Update(Film film)
        {
            _context.Update(film);
        }
    }
}
