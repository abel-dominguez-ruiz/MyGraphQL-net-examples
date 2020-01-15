using Microsoft.EntityFrameworkCore.Migrations;

namespace MyGraphQL.Domain.EF.Migrations
{
    public partial class RefactorFieldsInArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ArticleInfos");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ArticleInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ArticleInfos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ArticleInfos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
