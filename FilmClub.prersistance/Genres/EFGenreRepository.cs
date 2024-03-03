using FilmClub.Entity.Gentes;
using FilmClub.Service.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.prersistance.Genres
{
    public class EFGenreRepository: GenreRepository
    {
        private readonly DbSet<Genre> _context;


        public EFGenreRepository(DbSet<Genre> context)
        {
            _context = context;
        }

        public void Add(Genre genre)
        {
            _context.Add(genre);
        }

        public async Task<bool> ExistTitleAsync(string title)
        {
            return await _context.AnyAsync(g=>g.Title==title);
        }

        public async Task<Genre> GetAsynk(int id)
        {
            return await _context.FirstOrDefaultAsync(g=>g.Id==id);
        }

        public void Update(Genre genre)
        {
            _context.Update(genre);
        }
    }
}
