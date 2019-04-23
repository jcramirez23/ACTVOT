
namespace ACTVOT.Web.Data
{
    using System.Linq;
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class CandidatesRepository : GenericRepository<Candidates>, ICandidatesRepository
    {
        private readonly DataContext context;

        public CandidatesRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

    }
}
