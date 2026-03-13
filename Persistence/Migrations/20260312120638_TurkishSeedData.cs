using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TurkishSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Ön yüz ve arka yüz web geliştirme hizmetleri", "Yazılım Geliştirme" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "iOS ve Android uygulama geliştirme", "Mobil Uygulama" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Logo, UI/UX ve illüstrasyon tasarımı", "Grafik Tasarım" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "SEO, SEM ve Sosyal Medya Yönetimi", "Dijital Pazarlama" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Veri analizi, Makine Öğrenmesi ve Yapay Zeka", "Veri Bilimi" });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444443"),
                column: "Name",
                value: "Sosyal Medya Yönetimi");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555552"),
                column: "Name",
                value: "Makine Öğrenmesi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Front-end and Back-end web development services", "Web Development" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "iOS and Android app development", "Mobile Development" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Logo, UI/UX, and Illustration design", "Graphic Design" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "SEO, SEM, and Social Media Marketing", "Digital Marketing" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Data analysis, Machine Learning, and AI", "Data Science" });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444443"),
                column: "Name",
                value: "Social Media Management");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555552"),
                column: "Name",
                value: "Machine Learning");
        }
    }
}
