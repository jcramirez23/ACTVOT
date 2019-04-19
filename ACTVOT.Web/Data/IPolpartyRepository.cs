
namespace ACTVOT.Web.Data
{
    using Entities;
    using System.Linq;

    public interface IPolpartyRepository : IGenericRepository<Candidates>
    {
        IQueryable GetAllWithUsers();
    }
}
