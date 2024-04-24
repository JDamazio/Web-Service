using System.ComponentModel.DataAnnotations;

namespace Pet.API.Models
{
	public class LoginModel
	{
		[Required(ErrorMessage = "Email é obrigatorio")]
		[EmailAddress(ErrorMessage = "Formato invalido")]
		public string? Email { get; set; }

		[Required(ErrorMessage = "Password é obrigatorio")]
		[StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max " +
			"{1} characters long.", MinimumLength = 10)]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
