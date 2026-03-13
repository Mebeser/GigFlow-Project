using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                columns: new[] { "CreatedDate", "Id" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("63b1bac1-04dc-41ad-bc74-82bb4353d7af") });

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111112") },
                columns: new[] { "CreatedDate", "Id" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("47b03908-287a-4dd3-b3e3-ea2db0adf550") });

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a5555555-5555-5555-5555-555555555553") },
                columns: new[] { "CreatedDate", "Id" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("50ae6219-05b3-42cb-923f-78483636c652") });

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b2222222-2222-2222-2222-222222222222"), new Guid("a3333333-3333-3333-3333-333333333331") },
                columns: new[] { "CreatedDate", "Id" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("75213731-94b9-44b1-b0da-f488846ffca4") });

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b2222222-2222-2222-2222-222222222222"), new Guid("a3333333-3333-3333-3333-333333333332") },
                columns: new[] { "CreatedDate", "Id" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("cb983f9b-374c-4d85-9d8e-8ffa176b473b") });

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b3333333-3333-3333-3333-333333333333"), new Guid("a2222222-2222-2222-2222-222222222221") },
                columns: new[] { "CreatedDate", "Id" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("5c0dcba5-89f7-4474-a329-ac89b6a5783e") });

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

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111112"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111113"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222221"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222223"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333331"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333332"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333333"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444441"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444442"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444443"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555551"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555552"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555553"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 305, DateTimeKind.Utc).AddTicks(1966));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 305, DateTimeKind.Utc).AddTicks(3116));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 305, DateTimeKind.Utc).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 305, DateTimeKind.Utc).AddTicks(3124));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 305, DateTimeKind.Utc).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111111") },
                columns: new[] { "CreatedDate", "Id" },
                values: new object[] { new DateTime(2026, 3, 11, 14, 3, 22, 322, DateTimeKind.Local).AddTicks(4537), new Guid("669851b1-aaac-477e-94c4-bf09f92b0f8d") });

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a1111111-1111-1111-1111-111111111112") },
                columns: new[] { "CreatedDate", "Id" },
                values: new object[] { new DateTime(2026, 3, 11, 14, 3, 22, 322, DateTimeKind.Local).AddTicks(5932), new Guid("67805fe8-965f-4772-8100-3d4eba5dced1") });

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b1111111-1111-1111-1111-111111111111"), new Guid("a5555555-5555-5555-5555-555555555553") },
                columns: new[] { "CreatedDate", "Id" },
                values: new object[] { new DateTime(2026, 3, 11, 14, 3, 22, 322, DateTimeKind.Local).AddTicks(5940), new Guid("c1940682-ba48-4c6e-a7df-a5544f7a397a") });

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b2222222-2222-2222-2222-222222222222"), new Guid("a3333333-3333-3333-3333-333333333331") },
                columns: new[] { "CreatedDate", "Id" },
                values: new object[] { new DateTime(2026, 3, 11, 14, 3, 22, 322, DateTimeKind.Local).AddTicks(5943), new Guid("0bc03500-f98c-4433-925f-3603074cefca") });

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b2222222-2222-2222-2222-222222222222"), new Guid("a3333333-3333-3333-3333-333333333332") },
                columns: new[] { "CreatedDate", "Id" },
                values: new object[] { new DateTime(2026, 3, 11, 14, 3, 22, 322, DateTimeKind.Local).AddTicks(5947), new Guid("44c61e73-b504-47e9-b42a-bab60219d32f") });

            migrationBuilder.UpdateData(
                table: "JobPostingSkills",
                keyColumns: new[] { "JobPostingId", "SkillId" },
                keyValues: new object[] { new Guid("b3333333-3333-3333-3333-333333333333"), new Guid("a2222222-2222-2222-2222-222222222221") },
                columns: new[] { "CreatedDate", "Id" },
                values: new object[] { new DateTime(2026, 3, 11, 14, 3, 22, 322, DateTimeKind.Local).AddTicks(5950), new Guid("738a315b-4392-467b-a4f8-5e0ef537e477") });

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: new Guid("b1111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 312, DateTimeKind.Utc).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: new Guid("b2222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 312, DateTimeKind.Utc).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "JobPostings",
                keyColumn: "Id",
                keyValue: new Guid("b3333333-3333-3333-3333-333333333333"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 312, DateTimeKind.Utc).AddTicks(4324));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111111"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6938));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111112"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a1111111-1111-1111-1111-111111111113"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6978));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222221"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222222"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6987));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a2222222-2222-2222-2222-222222222223"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333331"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6993));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333332"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a3333333-3333-3333-3333-333333333333"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444441"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(7007));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444442"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(7010));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a4444444-4444-4444-4444-444444444443"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(7015));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555551"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555552"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(7022));

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a5555555-5555-5555-5555-555555555553"),
                column: "CreatedDate",
                value: new DateTime(2026, 3, 11, 11, 3, 22, 327, DateTimeKind.Utc).AddTicks(7025));
        }
    }
}
