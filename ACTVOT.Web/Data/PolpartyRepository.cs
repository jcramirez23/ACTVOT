

namespace ACTVOT.Web.Data
{
    using Entities;
    public class PolpartyRepository : GenericRepository<Candidates>, IPolpartyRepository
    {
        public PolpartyRepository(DataContext context) : base(context)
        {
        }
       
    }
   
}
