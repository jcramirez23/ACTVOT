
namespace ACTVOT.Web.Data
{
    using Entities;
    using System.Linq;

    public interface ICountryRepository : IGenericRepository<Country>
    {

        IQueryable GetAllWithUsers();
    }
}
