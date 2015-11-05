namespace BirthdaySystem.Data.Repositories
{
    using BirthdaySystem.Model;

    public class UserRepository : EfRepository<ApplicationUser>, IUserRepository
    {
        public UserRepository(IBirthdaySystemDbContext data)
            : base(data)
        {
        }

        public ApplicationUser GetByUsername(string username)
        {
            return this.context.Users.Find(username);
        }
    }
}
