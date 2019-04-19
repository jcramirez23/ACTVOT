
namespace ACTVOT.Web.Data
{
    using Entities;
    using System.Linq;

    public interface IActVoteRepository : IGenericRepository<ActVote>
    {
        IQueryable GetAllWithUsers();

    }
}
