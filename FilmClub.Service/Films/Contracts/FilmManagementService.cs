using FilmClub.Service.Films.Contracts.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Service.Films.Contracts
{
    public interface FilmManagementService
    {
        Task Add(AddFilmeDTO addFilmeDTO);
    }
}
