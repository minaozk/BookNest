using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class seedVillaToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqmeters", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, "\r\n\"Lavanta Konağı\", geniş lavanta bahçeleriyle çevrili, huzur dolu bir tatil villasıdır. Büyüleyici mor manzaraların ve gün batımının keyfini çıkarabileceğiniz bu konak, modern ve konforlu odalarıyla evinizin rahatlığını sunar. Özel yüzme havuzu ve doğayla iç içe dinlenme alanları ile doğaseverler için ideal bir kaçış noktasıdır. Lavanta Konağı'nda geçireceğiniz zaman, sizi şehrin stresinden uzaklaştırıp, doğanın kucağında huzura kavuşturacak.", "https://www.tatilpremium.com/thumbs/1200/630/catalog/127/kiralik-villa-yazlik-o%CC%88lu%CC%88deniz-tatil-premium1-7297.jpg", "Lavanta Konağı", 4, 4000.0, 120, null },
                    { 2, null, "\r\n\"Manzara Köşkü\", muhteşem doğa manzaralarına sahip şık bir tatil villasıdır. Modern ve konforlu iç mekanları, geniş terasları ve panoramik pencereleri ile ziyaretçilere doğa ile iç içe bir deneyim sunar. Özel yüzme havuzu ve geniş bahçe alanları, aktif veya rahatlatıcı bir tatil için idealdir. Manzara Köşkü, doğa severler için huzurlu bir kaçış noktası olarak mükemmel bir seçenektir.", "https://www.book4stay.com/thumbs/1000/700/catalog/513/dscf3902-2-1097.jpg", "Manzara Köşkü", 4, 4200.0, 320, null },
                    { 3, null, "\r\n\"Okyanus Vadisi\", deniz kenarında, sakin bir konumda yer alan lüks bir tatil villasıdır. Modern mimarisi ve geniş cam duvarlarıyla panoramik okyanus manzaralarını sunar. Villada, rahat bir konaklama için her detay düşünülmüş olup, özel yüzme havuzu ve geniş açık hava yaşam alanları bulunmaktadır. Doğa yürüyüşleri, su sporları ve dinlenme fırsatları ile Okyanus Vadisi, unutulmaz bir tatil deneyimi vaat eder.", "https://www.homeinmontenegro.com/wp-content/uploads/2018/11/luxury-waterfront-villa-rizon-sale-heated-pool-private-yacht-berth-risan-kotor-montenegro-6.jpg", "Okyanus Vadisi", 4, 6500.0, 400, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
