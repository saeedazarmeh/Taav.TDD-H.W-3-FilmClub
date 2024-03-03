using FilmClub.Service.Films.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.TestTools.InfraSteructure.Films.Factory
{
    public class AddUpdatePublicFilmeDTOFacrory
    {
        public static UpdatePublicFilmeDTO Create()
        {
            return new UpdatePublicFilmeDTO("title2", 120, 2020, 5,1);
        }
    }
}
