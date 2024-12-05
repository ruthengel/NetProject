using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyDiet.Data.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Diets_MyDietCode",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MyDietCode",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "MyDietCode",
                table: "Customers",
                newName: "MyDiet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MyDiet",
                table: "Customers",
                newName: "MyDietCode");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MyDietCode",
                table: "Customers",
                column: "MyDietCode");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Diets_MyDietCode",
                table: "Customers",
                column: "MyDietCode",
                principalTable: "Diets",
                principalColumn: "Code",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
