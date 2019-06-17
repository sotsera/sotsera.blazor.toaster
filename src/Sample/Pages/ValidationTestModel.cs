using System.ComponentModel.DataAnnotations;

namespace Sample.Pages
{
    public class ValidationTestModel
    {
        [Required]
        [StringLength(5, ErrorMessage = "Name too long (5 character limit).")]
        public string Name { get; set; }
        
        [Required]
        [StringLength(5, ErrorMessage = "Surname too long (5 character limit).")]
        public string Surname { get; set; }

        [Required]
        [StringLength(5, ErrorMessage = "Country too long (5 character limit).")]
        public string Country { get; set; }
    }
}