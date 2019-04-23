
namespace ACTVOT.Web.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using ACTVOT.Web.Data.Entities;


    public class CandidatesRepository : ICandidatesRepository
    {
        private readonly DataContext context;

        public CandidatesRepository(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Candidates> GetCandidat()
        {
            return this.context.Candidates.OrderBy(p => p.name);
        }

        public Candidates GetCandidat(int id)
        {
            return this.context.Candidates.Find(id);
        }

        public void AddCandidat(Candidates candidates)
        {
            this.context.Candidates.Add(candidates);
        }

        public void UpdateCandidat(Candidates candidates)
        {
            this.context.Update(candidates);
        }

        public void RemoveCandidat(Candidates candidates)
        {
            this.context.Candidates.Remove(candidates);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public bool CandidatExists(int id)
        {
            return this.context.Candidates.Any(p => p.Id == id);
        }
    }

}
