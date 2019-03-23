
namespace ACTVOT.Web.Data.Entities
    
{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ActVote
    {         
            public int Id { get; set; }

            [MaxLength(100, ErrorMessage = "The fild {0} only can contain{1} characters length.")]
            [Required]
            public string Name { get; set; }
               
            [Display(Name = "Start Event")]
            public DateTime Actstar { get; set; }

            [Display(Name = "End Event")]
            public DateTime Endstar { get; set; }


            [Display(Name = "Image")]
            public string ImageUrl { get; set; }
      


    }
}
