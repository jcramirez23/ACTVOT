
namespace ACTVOT.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Candidates : IEntity
    {
        public int Id { get; set; }

        public string name { get; set; }

        public string LastName { get; set; }

        [Display(Name = "Political Party")]
        public string Polparty { get; set; }

    }
}
