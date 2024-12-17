using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyDiet.Data.Migrations
{
    public partial class fixprimarykey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. מחק Foreign Key אם קיים
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Coaches_CoachId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Diets_Coaches_CoachId",
                table: "Diets");

            migrationBuilder.DropPrimaryKey(
            name: "PK_Coaches",  // שם המפתח הראשי
            table: "Coaches");

            // 2. מחק את העמודה הישנה
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Coaches");

            // 3. צור עמודה חדשה ללא IDENTITY
            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Coaches",
                nullable: false);

            // 4. הגדר את העמודה החדשה כמפתח ראשי
            migrationBuilder.AddPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches",
                column: "Id");

            // 5. שחזר את Foreign Key
            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Coaches_CoachId",
                table: "Customers",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_Coaches_CoachId",
                table: "Diets",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // במקרה של שחזור
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Coaches_CoachId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Diets_Coaches_CoachId",
                table: "Diets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Coaches");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Coaches",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coaches",
                table: "Coaches",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Coaches_CoachId",
                table: "Customers",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_Coaches_CoachId",
                table: "Diets",
                column: "CoachId",
                principalTable: "Coaches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

    }
}
