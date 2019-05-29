
namespace ACTVOT.Web.Data.Entities

{
    using Newtonsoft.Json;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ActVote : IEntity
    {
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "The fild {0} only can contain{1} characters length.")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Start Event")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime Actstar { get; set; }

        [Display(Name = "End Event")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]

        public DateTime Endstar { get; set; }


        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [MaxLength(100, ErrorMessage = "The fild {0} only can contain{1} characters length.")]
        [Required]
        public string Description { get; set; }

        public User user { get; set; }

        public Candidates ActCand { get; set; }

        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImageUrl))
                {
                    return null;
                }
                return $"https://myactivityvote.azurewebsites.net/{this.ImageUrl.Substring(1)}";

            }

        }



    }
}
