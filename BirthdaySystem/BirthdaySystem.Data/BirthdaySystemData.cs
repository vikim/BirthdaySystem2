namespace BirthdaySystem.Data
{
    using System;
    using System.Collections.Generic;

    using BirthdaySystem.Data.Repositories;
    using BirthdaySystem.Model;
    
    public class BirthdaySystemData : IBirthdaySystemData
    {
        private IBirthdaySystemDbContext context;

        private IDictionary<Type, object> dict;

        public BirthdaySystemData(IBirthdaySystemDbContext context)
        {
            this.context = context;
        }

        public IRepository<Vote> Votes
        {
            get
            {
                return this.GetRepository<Vote>();
            }
        }

        public IRepository<PresentVote> PresentsVotes
        {
            get
            {
                return this.GetRepository<PresentVote>();
            }
        }

        public IRepository<Present> Presents
        {
            get
            {
                return this.GetRepository<Present>();
            }
        }

        public IUserRepository Users
        {
            get
            {
                return (IUserRepository)this.GetRepository<ApplicationUser>();
            }
        }

        private IRepository<T> GetRepository<T>()
            where T : class
        {
            var type = typeof(T);

            if (!dict.ContainsKey(type))
            {
                var repositoryType = typeof(EfRepository<T>);

                if (type.IsAssignableFrom(typeof(ApplicationUser)))
                {
                    repositoryType = typeof(IUserRepository);
                }
                
                var instance = Activator.CreateInstance(repositoryType, this.context);

                dict.Add(type, instance);
            }

            return (IRepository<T>)dict[type];
        }
    }
}
