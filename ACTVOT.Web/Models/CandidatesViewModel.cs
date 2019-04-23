


namespace ACTVOT.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Entities;
    using Microsoft.AspNetCore.Http;
 

    public class CandidatesViewModel : Candidates
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
