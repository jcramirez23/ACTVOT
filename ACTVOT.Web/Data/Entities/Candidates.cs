
namespace ACTVOT.Web.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    public class Candidates : IEntity
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "The fild {0} only can contain{1} characters length.")]
        [Required]
        [Display(Name = "Name Candidat")]
        public string name { get; set; }

        [MaxLength(100, ErrorMessage = "The fild {0} only can contain{1} characters length.")]
        [Required]
        public string LastName { get; set; }

        [MaxLength(100, ErrorMessage = "The fild {0} only can contain{1} characters length.")]
        [Required]
        [Display(Name = "Political Party")]
        public string Polparty { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

       

    }
}
