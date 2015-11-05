namespace BirthdaySystem.Data
{
    using BirthdaySystem.Data.Repositories;
    using BirthdaySystem.Model;

    public interface IBirthdaySystemData
    {
        IRepository<Vote> Votes { get; }

        IRepository<PresentVote> PresentsVotes { get; }

        IRepository<Present> Presents { get; }

        IUserRepository Users { get; }
    }
}
