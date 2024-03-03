using FilmClub.Contracts.Utilities;

namespace FilmClub.Service.Films.Contracts.DTO
{
    public class UpdatePublicFilmeDTO
    {
        public UpdatePublicFilmeDTO(string title, int durationPerMinuts, int createdYear, int limitatedAge, int genreId)
        {
            Guard(title, durationPerMinuts, createdYear, limitatedAge);

            Title = title;
            DurationPerMinuts = durationPerMinuts;
            CreatedYear = createdYear;
            LimitatedAge = limitatedAge;
            GenreId = genreId;
        }

        public string Title { get; set; }
        public int DurationPerMinuts { get; set; }
        public int CreatedYear { get; set; }
        public int LimitatedAge { get; set; }
        public int GenreId { get; set; }

        public void Guard(string title, int durationPerMinuts, int createdYear, int limitatedAge)
        {
            if (!Utility.IsCheckLength(title, 60))
            {
                throw new InvalidDataException();
            }
            else if (durationPerMinuts < 10 || durationPerMinuts > 400)
            {
                throw new InvalidDataException();
            }
            else if (createdYear > 2024 || createdYear < 1500)
            {
                throw new InvalidDataException();
            }
            else if (limitatedAge < 0 || limitatedAge > 22)
            {
                throw new InvalidDataException();
            }
        }
    }
}
