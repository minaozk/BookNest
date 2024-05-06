using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookNest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addAllToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Sqmeters = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenities_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    Villa_Number = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.Villa_Number);
                    table.ForeignKey(
                        name: "FK_VillaNumbers_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqmeters", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, "\r\n\"Lavanta Konağı\", geniş lavanta bahçeleriyle çevrili, huzur dolu bir tatil villasıdır. Büyüleyici mor manzaraların ve gün batımının keyfini çıkarabileceğiniz bu konak, modern ve konforlu odalarıyla evinizin rahatlığını sunar. Özel yüzme havuzu ve doğayla iç içe dinlenme alanları ile doğaseverler için ideal bir kaçış noktasıdır. Lavanta Konağı'nda geçireceğiniz zaman, sizi şehrin stresinden uzaklaştırıp, doğanın kucağında huzura kavuşturacak.", "https://www.tatilpremium.com/thumbs/1200/630/catalog/127/kiralik-villa-yazlik-o%CC%88lu%CC%88deniz-tatil-premium1-7297.jpg", "Lavanta Konağı", 4, 4000.0, 120, null },
                    { 2, null, "\r\n\"Manzara Köşkü\", muhteşem doğa manzaralarına sahip şık bir tatil villasıdır. Modern ve konforlu iç mekanları, geniş terasları ve panoramik pencereleri ile ziyaretçilere doğa ile iç içe bir deneyim sunar. Özel yüzme havuzu ve geniş bahçe alanları, aktif veya rahatlatıcı bir tatil için idealdir. Manzara Köşkü, doğa severler için huzurlu bir kaçış noktası olarak mükemmel bir seçenektir.", "https://www.book4stay.com/thumbs/1000/700/catalog/513/dscf3902-2-1097.jpg", "Manzara Köşkü", 4, 4200.0, 320, null },
                    { 3, null, "\r\n\"Okyanus Vadisi\", deniz kenarında, sakin bir konumda yer alan lüks bir tatil villasıdır. Modern mimarisi ve geniş cam duvarlarıyla panoramik okyanus manzaralarını sunar. Villada, rahat bir konaklama için her detay düşünülmüş olup, özel yüzme havuzu ve geniş açık hava yaşam alanları bulunmaktadır. Doğa yürüyüşleri, su sporları ve dinlenme fırsatları ile Okyanus Vadisi, unutulmaz bir tatil deneyimi vaat eder.", "https://www.homeinmontenegro.com/wp-content/uploads/2018/11/luxury-waterfront-villa-rizon-sale-heated-pool-private-yacht-berth-risan-kotor-montenegro-6.jpg", "Okyanus Vadisi", 4, 6500.0, 400, null }
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Description", "Name", "VillaId" },
                values: new object[,]
                {
                    { 1, null, "Özel Havuz", 1 },
                    { 2, null, "Mikrodalga", 1 },
                    { 3, null, "Özel Balkon", 1 },
                    { 4, null, "1 çift kişilik yatak ve 1 tek kişilik yatak", 1 },
                    { 5, null, "Özel Dalma Havuzu\r\n", 2 },
                    { 6, null, "Mikrodalga ve Mini Buzdolabı", 2 },
                    { 7, null, "Özel Balkon", 2 },
                    { 8, null, "Kral yatak veya 2 adet çift kişilik yatak", 2 },
                    { 9, null, "Özel Havuz", 3 },
                    { 10, null, "Jakuzi", 3 },
                    { 11, null, "Özel Balkon", 3 }
                });

            migrationBuilder.InsertData(
                table: "VillaNumbers",
                columns: new[] { "Villa_Number", "SpecialDetails", "VillaId" },
                values: new object[,]
                {
                    { 201, null, 2 },
                    { 202, null, 2 },
                    { 301, null, 3 },
                    { 302, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_VillaId",
                table: "Amenities",
                column: "VillaId");

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
