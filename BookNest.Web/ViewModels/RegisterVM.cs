using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookNest.Web.ViewModels
{
	public class RegisterVM
	{
		[Required]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[DisplayName("Şifre")]
		public string Password { get; set; }
		[Required]
		[DataType(DataType.Password)]
		[DisplayName("Şifre Tekrar")]
		[Compare(nameof(Password))]
		public string ConfirmPassword { get; set; }
		[Required]
		[DisplayName("İsim")]
		public string Name { get; set; }
		[DisplayName("Telefon Numarası")]
		public string? PhoneNumber { get; set; }
		public string? RedirectUrl { get; set; }
		public string? Role { get; set; }
		[ValidateNever]
		public IEnumerable<SelectListItem>? RoleList { get; set; }
	}
}
