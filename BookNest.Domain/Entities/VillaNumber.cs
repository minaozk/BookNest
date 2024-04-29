using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookNest.Domain.Entities
{
	public class VillaNumber
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
		[DisplayName("Villa Numarası")]
		public int Villa_Number { get; set; }
		[ForeignKey("Villa")]
		public int VillaId { get; set; }
		[ValidateNever]
		public Villa Villa { get; set; }
		[DisplayName("Özellikler")]
		public string? SpecialDetails { get; set; }
	}
}
