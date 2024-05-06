using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookNest.Domain.Entities
{
    public class Villa
    {
        public int Id { get; set; }
        [Display(Name = "Villa Adı")]
        [MaxLength(255, ErrorMessage = "Villa Adı 255 karakterden uzun olamaz.")]
        public required string Name { get; set; }
        [Display(Name = "Açıklama")]
        public string? Description { get; set; }
        [Display(Name = "Gecelik Fiyat")]
        [Range(500, 30000)]
        public double Price { get; set; }
        [Display(Name = "Metrekare")]
        public int Sqmeters { get; set; }
        [Display(Name = "Doluluk")]
        [Range(1, 10)]
        public int Occupancy { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }

        [Display(Name = "ResimUrl")]
        public string? ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
