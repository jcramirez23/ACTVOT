

namespace ACTVOT.Web.Data
{
    using System.Linq;
    using Entities;
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        private readonly DataContext context;

        public CountryRepository(DataContext context) : base(context)
        {
            this.context = context;
        }

        public IQueryable GetAllWithUsers()
        {
            throw new System.NotImplementedException();
        }
    }
      
}
