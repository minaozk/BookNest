using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookNest.Web.ViewModels
{
	public class LoginVM
	{
		[Required]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[DisplayName("Şifre")]
		public string Password { get; set; }
		[DisplayName("Beni Hatırla")]
		public bool RememberMe { get; set; }
		public string? RedirectUrl { get; set; }
	}
}
