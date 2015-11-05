namespace BirthdaySystem.Data.Repositories
{
    using BirthdaySystem.Model;

    public interface IUserRepository
    {
        ApplicationUser GetByUsername(string username);
    }
}
