using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace W10_EFCore_TPH.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[Characters] ON");
            migrationBuilder.Sql("INSERT INTO[dbo].[Characters]([Id], [Name], [Level], [CharacterType], [AggressionLevel], [Experience]) VALUES(1, N'Sir John', 1, N'Player', NULL, 100)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Characters] ([Id], [Name], [Level], [CharacterType], [AggressionLevel], [Experience]) VALUES(2, N'Lady Jane', 2, N'Player', NULL, 200)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Characters] ([Id], [Name], [Level], [CharacterType], [AggressionLevel], [Experience]) VALUES(3, N'Bob Goblin', 1, N'Goblin', 1, NULL)");
            migrationBuilder.Sql("INSERT INTO[dbo].[Characters] ([Id], [Name], [Level], [CharacterType], [AggressionLevel], [Experience]) VALUES(4, N'Gob Boblin', 1, N'Goblin', 1, NULL)");
            migrationBuilder.Sql("SET IDENTITY_INSERT[dbo].[Characters] OFF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROOM Characters");
        }
    }
}
