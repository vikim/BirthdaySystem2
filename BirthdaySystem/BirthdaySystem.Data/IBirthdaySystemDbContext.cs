namespace BirthdaySystem.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using BirthdaySystem.Model;

    public interface IBirthdaySystemDbContext
    {
        IDbSet<Present> Presents { get; set; }

        IDbSet<Vote> Votes { get; set; }

        IDbSet<PresentVote> PresentsVotes { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
