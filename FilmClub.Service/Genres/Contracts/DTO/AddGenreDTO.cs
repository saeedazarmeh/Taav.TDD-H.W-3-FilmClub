using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmClub.Service.Genres.Contracts.DTO
{
    public class AddGenreDTO
    {
        [Required]
        [MaxLength(40)]
        [MinLength(3)]
        public string Title { get; set; }
    }
}
