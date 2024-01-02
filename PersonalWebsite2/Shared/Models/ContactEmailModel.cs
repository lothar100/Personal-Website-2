using System.ComponentModel.DataAnnotations;

namespace PersonalWebsite2.Shared.Models
{
    public class ContactEmailModel
    {
        [Required]
        [Display(Name = " Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = " Email")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = " Message")]
        public string Message { get; set; }
    }
}