using FilmClub.Service.Genres.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.TestTools.InfraSteructure.Genres.Factory
{
    public class CreateAddGenreDTOFactory
    {
        public static AddGenreDTO Create()
        {
            return new AddGenreDTO()
            {
                Title = "Genre1",
            };
        }
    }
}
