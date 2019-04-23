using System.Collections.Generic;
using System.Threading.Tasks;
using ACTVOT.Web.Data.Entities;

namespace ACTVOT.Web.Data
{
    public interface ICandidatesRepository
    {
        void AddCandidat(Candidates candidates);

        bool CandidatExists(int id);

        IEnumerable<Candidates> GetCandidat();

        Candidates GetCandidat(int id);

        void RemoveCandidat(Candidates candidates);

        Task<bool> SaveAllAsync();

        void UpdateCandidat(Candidates candidates);
    }
}