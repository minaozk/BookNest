﻿using BookNest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Infrastructure.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Villa> Villas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);

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
		}
	}
}
