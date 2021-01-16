using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"(?=^.{6,10}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$",
            ErrorMessage = "Password must have 1 Uppercase, 1 Lowercase, 1 special character, 1 number and the length should be between 6-10 characters")]
        public string Password { get; set; }
    }
}
