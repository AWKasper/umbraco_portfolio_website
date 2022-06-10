using System.ComponentModel.DataAnnotations;

namespace Portfolio.Core.Models.FormModels
{
    public class ContactFormModel
    {
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(5)]
        public string Comment { get; set; }
    }
}