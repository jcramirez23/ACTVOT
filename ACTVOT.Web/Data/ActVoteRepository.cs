
namespace ACTVOT.Web.Data
{
    using Entities;
    public class ActVoteRepository :GenericRepository<ActVote>, IActVoteRepository
    {
        public ActVoteRepository(DataContext context) : base(context)
        {
        }

    }
}
