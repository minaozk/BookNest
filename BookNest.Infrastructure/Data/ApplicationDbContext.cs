using BookNest.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Villa> Villas { get; set; }
		public DbSet<VillaNumber> VillaNumbers { get; set; }
		public DbSet<Amenity> Amenities { get; set; }
		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<Booking> Bookings { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<ApplicationUser>(builder =>
			{
				builder.ToTable("ApplicationUser");
			});

			modelBuilder.Entity<Villa>().HasData(
				new Villa
				{
					Id = 1,
					Name = "Lavanta Konağı",
					Description = "\r\n\"Lavanta Konağı\", geniş lavanta bahçeleriyle çevrili, huzur dolu bir tatil villasıdır. Büyüleyici mor manzaraların ve gün batımının keyfini çıkarabileceğiniz bu konak, modern ve konforlu odalarıyla evinizin rahatlığını sunar. Özel yüzme havuzu ve doğayla iç içe dinlenme alanları ile doğaseverler için ideal bir kaçış noktasıdır. Lavanta Konağı'nda geçireceğiniz zaman, sizi şehrin stresinden uzaklaştırıp, doğanın kucağında huzura kavuşturacak.",
					ImageUrl = "https://www.tatilpremium.com/thumbs/1200/630/catalog/127/kiralik-villa-yazlik-o%CC%88lu%CC%88deniz-tatil-premium1-7297.jpg",
					Occupancy = 4,
					Price = 4000,
					Sqmeters = 120,
				},
				new Villa
				{
					Id = 2,
					Name = "Manzara Köşkü",
					Description = "\r\n\"Manzara Köşkü\", muhteşem doğa manzaralarına sahip şık bir tatil villasıdır. Modern ve konforlu iç mekanları, geniş terasları ve panoramik pencereleri ile ziyaretçilere doğa ile iç içe bir deneyim sunar. Özel yüzme havuzu ve geniş bahçe alanları, aktif veya rahatlatıcı bir tatil için idealdir. Manzara Köşkü, doğa severler için huzurlu bir kaçış noktası olarak mükemmel bir seçenektir.",
					ImageUrl = "https://www.book4stay.com/thumbs/1000/700/catalog/513/dscf3902-2-1097.jpg",
					Occupancy = 4,
					Price = 4200,
					Sqmeters = 320,
				},

				new Villa
				{
					Id = 3,
					Name = "Okyanus Vadisi",
					Description = "\r\n\"Okyanus Vadisi\", deniz kenarında, sakin bir konumda yer alan lüks bir tatil villasıdır. Modern mimarisi ve geniş cam duvarlarıyla panoramik okyanus manzaralarını sunar. Villada, rahat bir konaklama için her detay düşünülmüş olup, özel yüzme havuzu ve geniş açık hava yaşam alanları bulunmaktadır. Doğa yürüyüşleri, su sporları ve dinlenme fırsatları ile Okyanus Vadisi, unutulmaz bir tatil deneyimi vaat eder.",
					ImageUrl = "https://www.homeinmontenegro.com/wp-content/uploads/2018/11/luxury-waterfront-villa-rizon-sale-heated-pool-private-yacht-berth-risan-kotor-montenegro-6.jpg",
					Occupancy = 4,
					Price = 6500,
					Sqmeters = 400
				}
				);

			modelBuilder.Entity<VillaNumber>().HasData(
				new VillaNumber
				{
					Villa_Number = 201,
					VillaId = 2,

				},
				new VillaNumber
				{
					Villa_Number = 202,
					VillaId = 2,

				},
				new VillaNumber
				{
					Villa_Number = 301,
					VillaId = 3,

				},
				new VillaNumber
				{
					Villa_Number = 302,
					VillaId = 3,

				}

				);

			modelBuilder.Entity<Amenity>().HasData(
		  new Amenity
		  {
			  Id = 1,
			  VillaId = 1,
			  Name = "Özel Havuz"
		  }, new Amenity
		  {
			  Id = 2,
			  VillaId = 1,
			  Name = "Mikrodalga"
		  }, new Amenity
		  {
			  Id = 3,
			  VillaId = 1,
			  Name = "Özel Balkon"
		  }, new Amenity
		  {
			  Id = 4,
			  VillaId = 1,
			  Name = "1 çift kişilik yatak ve 1 tek kişilik yatak"
		  },

		  new Amenity
		  {
			  Id = 5,
			  VillaId = 2,
			  Name = "Özel Dalma Havuzu\r\n"
		  }, new Amenity
		  {
			  Id = 6,
			  VillaId = 2,
			  Name = "Mikrodalga ve Mini Buzdolabı"
		  }, new Amenity
		  {
			  Id = 7,
			  VillaId = 2,
			  Name = "Özel Balkon"
		  }, new Amenity
		  {
			  Id = 8,
			  VillaId = 2,
			  Name = "Kral yatak veya 2 adet çift kişilik yatak"
		  },

		  new Amenity
		  {
			  Id = 9,
			  VillaId = 3,
			  Name = "Özel Havuz"
		  }, new Amenity
		  {
			  Id = 10,
			  VillaId = 3,
			  Name = "Jakuzi"
		  }, new Amenity
		  {
			  Id = 11,
			  VillaId = 3,
			  Name = "Özel Balkon"
		  });
		}
	}
}
