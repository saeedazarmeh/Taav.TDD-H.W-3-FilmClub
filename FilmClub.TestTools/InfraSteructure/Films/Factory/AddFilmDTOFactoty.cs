using FilmClub.Service.Films.Contracts.DTO;

namespace FilmClub.TestTools.InfraSteructure.Films.Factory
{
    public class AddFilmDTOFactoty
    {
        public static AddFilmeDTO Create(string? title = null, int? genreId = null)
        {
            return new AddFilmeDTO(title ?? "Genre1", 195, 1987, 16, genreId ?? 1, 200000, 20, 15);
        }
    }
}
