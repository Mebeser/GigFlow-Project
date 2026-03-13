using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Description", "Name", "ParentCategoryId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), null, new DateTime(2026, 3, 11, 11, 3, 22, 305, DateTimeKind.Utc).AddTicks(1966), "Front-end and Back-end web development services", "Web Development", null, null },
                    { new Guid("22222222-2222-2222-2222-222222222222"), null, new DateTime(2026, 3, 11, 11, 3, 22, 305, DateTimeKind.Utc).AddTicks(3116), "iOS and Android app development", "Mobile Development", null, null },
                    { new Guid("33333333-3333-3333-3333-333333333333"), null, new DateTime(2026, 3, 11, 11, 3, 22, 305, DateTimeKind.Utc).AddTicks(3121), "Logo, UI/UX, and Illustration design", "Graphic Design", null, null },
                    { new Guid("44444444-4444-4444-4444-444444444444"), null, new DateTime(2026, 3, 11, 11, 3, 22, 305, DateTimeKind.Utc).AddTicks(3124), "SEO, SEM, and Social Media Marketing", "Digital Marketing", null, null },
                    { new Guid("55555555-5555-5555-5555-555555555555"), null, new DateTime(2026, 3, 11, 11, 3, 22, 305, DateTimeKind.Utc).AddTicks(3127), "Data analysis, Machine Learning, and AI", "Data Science", null, null }
                });

            migrationBuilder.InsertData(
                table: "JobPostings",
                columns: new[] { "Id", "BudgetMax", "BudgetMin", "BudgetType", "CategoryId", "ClientId", "CreatedDate", "Deadline", "Description", "Duration", "ExperienceLevel", "Status", "Title", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("b1111111-1111-1111-1111-111111111111"), 5000m, 2000m, 0, new Guid("11111111-1111-1111-1111-111111111111"), null, new DateTime(2026, 3, 11, 11, 3, 22, 312, DateTimeKind.Utc).AddTicks(4278), null, "We are looking for an experienced .NET Core and React developer to build our next gen e-commerce platform.", 2, 2, 0, "Full Stack .NET Developer Needed for E-Commerce App", null },
                    { new Guid("b2222222-2222-2222-2222-222222222222"), 50m, 30m, 1, new Guid("33333333-3333-3333-3333-333333333333"), null, new DateTime(2026, 3, 11, 11, 3, 22, 312, DateTimeKind.Utc).AddTicks(4303), null, "Looking for a talented Figma designer to redesign our existing fitness tracking mobile application.", 1, 1, 0, "UI/UX Designer for Mobile App Redesign", null },
                    { new Guid("b3333333-3333-3333-3333-333333333333"), 3000m, 1500m, 0, new Guid("22222222-2222-2222-2222-222222222222"), null, new DateTime(2026, 3, 11, 11, 3, 22, 312, DateTimeKind.Utc).AddTicks(4324), null, "We need an MVP for an ad-hoc local delivery app built and shipped in 6 weeks using Flutter.", 0, 1, 0, "Flutter Developer required for MVP", null }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("a1111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6938), "React", null },
                    { new Guid("a1111111-1111-1111-1111-111111111112"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6970), ".NET Core", null },
                    { new Guid("a1111111-1111-1111-1111-111111111113"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6978), "Node.js", null },
                    { new Guid("a2222222-2222-2222-2222-222222222221"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6983), "Flutter", null },
                    { new Guid("a2222222-2222-2222-2222-222222222222"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6987), "Swift", null },
                    { new Guid("a2222222-2222-2222-2222-222222222223"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6990), "Kotlin", null },
                    { new Guid("a3333333-3333-3333-3333-333333333331"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6993), "Figma", null },
                    { new Guid("a3333333-3333-3333-3333-333333333332"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6997), "Adobe Illustrator", null },
                    { new Guid("a3333333-3333-3333-3333-333333333333"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(7000), "Adobe Photoshop", null },
                    { new Guid("a4444444-4444-4444-4444-444444444441"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(7007), "SEO", null },
                    { new Guid("a4444444-4444-4444-4444-444444444442"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(7010), "Google Ads", null },
                    { new Guid("a4444444-4444-4444-4444-444444444443"), new Guid("44444444-4444-4444-4444-444444444444"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(7015), "Social Media Management", null },
                    { new Guid("a5555555-5555-5555-5555-555555555551"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(7018), "Python", null },
                    { new Guid("a5555555-5555-5555-5555-555555555552"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(7022), "Machine Learning", null },
                    { new Guid("a5555555-5555-5555-5555-555555555553"), new Guid("55555555-5555-5555-5555-555555555555"), new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(7025), "SQL", null }
                });

            migrationBuilder.InsertData(
                table: "JobPostingSkills",
                columns: new[] { "JobPostingId", "SkillId", "CreatedDate", "Id", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111111"), new DateTime(2026, 3, 11, 14, 3, 22, 322, DateTimeKind.Local).AddTicks(4537), new Guid("669851b1-aaac-477e-94c4-bf09f92b0f8d"), null },
                    { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111112"), new DateTime(2026, 3, 11, 14, 3, 22, 322, DateTimeKind.Local).AddTicks(5932), new Guid("67805fe8-965f-4772-8100-3d4eba5dced1"), null },
                    { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a5555555-5555-5555-5555-555555555553"), new DateTime(2026, 3, 11, 14, 3, 22, 322, DateTimeKind.Local).AddTicks(5940), new Guid("c1940682-ba48-4c6e-a7df-a5544f7a397a"), null },
                    { new Guid("b2222222-2222-2222-2222-222222222222"), new Guid("a3333333-3333-3333-3333-333333333331"), new DateTime(2026, 3, 11, 14, 3, 22, 322, DateTimeKind.Local).AddTicks(5943), new Guid("0bc03500-f98c-4433-925f-3603074cefca"), null },
                    { new Guid("b2222222-2222-2222-2222-222222222222"), new Guid("a3333333-3333-3333-3333-333333333332"), new DateTime(2026, 3, 11, 14, 3, 22, 322, DateTimeKind.Local).AddTicks(5947), new Guid("44c61e73-b504-47e9-b42a-bab60219d32f"), null },
                    { new Guid("b3333333-3333-3333-3333-333333333333"), new Guid("a2222222-2222-2222-2222-222222222221"), new DateTime(2026, 3, 11, 14, 3, 22, 322, DateTimeKind.Local).AddTicks(5950), new Guid("738a315b-4392-467b-a4f8-5e0ef537e477"), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111111") });

            migrationBuilder.DeleteData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111112") });

            migrationBuilder.DeleteData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a5555555-5555-5555-5555-555555555553") });

            migrationBuilder.DeleteData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b2222222-2222-2222-2222-222222222222"), new Guid("a3333333-3333-3333-3333-333333333331") });

            migrationBuilder.DeleteData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b2222222-2222-2222-2222-222222222222"), new Guid("a3333333-3333-3333-3333-333333333332") });

            migrationBuilder.DeleteData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b3333333-3333-3333-3333-333333333333"), new Guid("a2222222-2222-2222-2222-222222222221") });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111113"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222223"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444441"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444442"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444443"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555551"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555552"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111112"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222221"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333331"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333332"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555553"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));
        }
    }
}
