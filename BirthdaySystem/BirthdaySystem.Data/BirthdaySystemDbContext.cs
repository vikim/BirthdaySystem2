namespace BirthdaySystem.Data
{
    using System.Data.Entity;

    using BirthdaySystem.Model;
    
    public class BirthdaySystemDbContext: DbContext, IBirthdaySystemDbContext
    {
        public BirthdaySystemDbContext()
            : base("BirthdaySystemConnection")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public virtual IDbSet<Present> Presents { get; set; }
               
        public virtual IDbSet<Vote> Votes { get; set; }
              
        public virtual IDbSet<PresentVote> PresentsVotes { get; set; }
               
        public virtual IDbSet<ApplicationUser> Users { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /*
        public DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new System.NotImplementedException();
        }
         */
    }
}
