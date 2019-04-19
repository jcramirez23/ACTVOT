
namespace ACTVOT.Web.Data
{
    using System.Linq;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class ActVoteRepository :GenericRepository<ActVote>, IActVoteRepository
    {
        private readonly DataContext context;

        public ActVoteRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            return this.context.ActVotes.Include(p =>p.user);
                
        }
    }
}
