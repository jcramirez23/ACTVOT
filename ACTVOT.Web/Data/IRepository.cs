
namespace ACTVOT.Web.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;
    public interface IRepository
    {
        bool ActVoteExists(int id);

        void AddActVote(ActVote ActVote);

        ActVote GetActVote(int id);

        IEnumerable<ActVote> GetActVotes();

        void RemoveActVote(ActVote ActVote);

        Task<bool> SaveAllAsync();

        void UpdateActVote(ActVote ActVote);
    }
}