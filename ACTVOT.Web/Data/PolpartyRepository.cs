

namespace ACTVOT.Web.Data
{
    using System.Linq;
    using Entities;
    public class PolpartyRepository : GenericRepository<Candidates>, IPolpartyRepository
    {
        private readonly DataContext context;

        public PolpartyRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            throw new System.NotImplementedException();
        }
    }
   
}
