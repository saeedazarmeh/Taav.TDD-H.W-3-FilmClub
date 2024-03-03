using FilmClub.Service.Genres.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Service.Genres.Contracts
{
    public interface GenreManagementService
    {
        Task Add(AddGenreDTO addGenreDTO);
    }
}
