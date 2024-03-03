using FilmClub.Contracts.Utilities;

namespace FilmClub.Service.Films.Contracts.DTO
{
    public class UpdateDescriptionFilmeDTO
    {
        public UpdateDescriptionFilmeDTO(string description)
        {
            Guard(description);

            Description = description;
        }
        public string Description { get; set; }

        public void Guard(string description)
        {
            if (Utility.IsCheckLength(description, 1000))
            {
                throw new InvalidDataException();
            }
        }
    }
}
