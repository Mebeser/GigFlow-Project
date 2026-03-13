using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FinalizeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111111") },
                column: "Id",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111112") },
                column: "Id",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a5555555-5555-5555-5555-555555555553") },
                column: "Id",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b2222222-2222-2222-2222-222222222222"), new Guid("a3333333-3333-3333-3333-333333333331") },
                column: "Id",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b2222222-2222-2222-2222-222222222222"), new Guid("a3333333-3333-3333-3333-333333333332") },
                column: "Id",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b3333333-3333-3333-3333-333333333333"), new Guid("a2222222-2222-2222-2222-222222222221") },
                column: "Id",
                value: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 12, 52, 1, 190, DateTimeKind.Utc).AddTicks(3527));

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 12, 52, 1, 190, DateTimeKind.Utc).AddTicks(3539));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 12, 46, 42, 551, DateTimeKind.Utc).AddTicks(8479));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 12, 46, 42, 551, DateTimeKind.Utc).AddTicks(8972));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 12, 46, 42, 551, DateTimeKind.Utc).AddTicks(8975));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 12, 46, 42, 551, DateTimeKind.Utc).AddTicks(8979));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 12, 46, 42, 551, DateTimeKind.Utc).AddTicks(8982));

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111111") },
                column: "Id",
                value: new Guid("63b1bac1-04dc-41ad-bc74-82bb4353d7af"));

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111112") },
                column: "Id",
                value: new Guid("47b03908-287a-4dd3-b3e3-ea2db0adf550"));

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a5555555-5555-5555-5555-555555555553") },
                column: "Id",
                value: new Guid("50ae6219-05b3-42cb-923f-78483636c652"));

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b2222222-2222-2222-2222-222222222222"), new Guid("a3333333-3333-3333-3333-333333333331") },
                column: "Id",
                value: new Guid("75213731-94b9-44b1-b0da-f488846ffca4"));

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b2222222-2222-2222-2222-222222222222"), new Guid("a3333333-3333-3333-3333-333333333332") },
                column: "Id",
                value: new Guid("cb983f9b-374c-4d85-9d8e-8ffa176b473b"));

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b3333333-3333-3333-3333-333333333333"), new Guid("a2222222-2222-2222-2222-222222222221") },
                column: "Id",
                value: new Guid("5c0dcba5-89f7-4474-a329-ac89b6a5783e"));

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 12, 46, 42, 560, DateTimeKind.Utc).AddTicks(5242));

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 12, 46, 42, 560, DateTimeKind.Utc).AddTicks(5274));

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 12, 46, 42, 560, DateTimeKind.Utc).AddTicks(5281));
        }
    }
}
