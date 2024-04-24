using System.ComponentModel.DataAnnotations;

namespace Pet.API.Models
{
	public class RegisterModel
	{
        [Required]
        [EmailAddress]
        public  string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

		[DataType(DataType.Password)]
        [Display(Name = "Confirmar password")]
        [Compare("Password", ErrorMessage = "Senhas não são iguais")]
		public string ConfirmPassword { get; set; }
    }
}
