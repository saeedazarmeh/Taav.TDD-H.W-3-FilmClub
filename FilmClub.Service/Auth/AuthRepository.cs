namespace FilmClub.Service.Auth
{
    public interface AuthRepository
    {
        bool IsAthonticated();
        bool HasPermission();

    }
}
