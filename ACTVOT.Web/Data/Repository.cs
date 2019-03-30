namespace ACTVOT.Web.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;

    public class Repository : IRepository
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<ActVote> GetActVotes()
        {
            return this.context.ActVotes.OrderBy(A => A.Name);
        }

        public ActVote GetActVote(int id)
        {
            return this.context.ActVotes.Find(id);
        }

        public void AddActVote(ActVote ActVote)
        {
            this.context.ActVotes.Add(ActVote);
        }

        public void UpdateActVote(ActVote ActVote)
        {
            this.context.ActVotes.Update(ActVote);
        }

        public void RemoveActVote(ActVote ActVote)
        {
            this.context.ActVotes.Remove(ActVote);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool ActVoteExists(int id)
        {
            return this.context.ActVotes.Any(A => A.Id == id);
        }

    }
}
