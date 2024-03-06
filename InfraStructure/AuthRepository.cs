namespace InfraStructure
{
    public interface AuthRepository
    {
        bool IsAthonticated();
        bool HasPermission();

    }
}
