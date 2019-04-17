


namespace ACTVOT.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Data.Entities;
    using Microsoft.AspNetCore.Http;
 

    public class ActVoteViewModel :ActVote
    {
        [Display(Name = "Image")]
        public IFormFile ImageFile { get; set; }

    }
}
