using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyDiet.Data.Migrations
{
    public partial class fix_primaries_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
            name: "PK_Weight",  // שם המפתח הראשי
            table: "Weight");

            // 2. מחק את העמודה הישנה
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Weight");

            // 3. צור עמודה חדשה ללא IDENTITY
            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Weight",
                nullable: false);

            // 4. הגדר את העמודה החדשה כמפתח ראשי
            migrationBuilder.AddPrimaryKey(
                name: "PK_Weight",
                table: "Weight",
                column: "Date");

            migrationBuilder.DropPrimaryKey(
            name: "PK_Diets",  // שם המפתח הראשי
            table: "Diets");

            // 2. מחק את העמודה הישנה
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Diets");

            // 3. צור עמודה חדשה ללא IDENTITY
            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Diets",
                nullable: false);

            // 4. הגדר את העמודה החדשה כמפתח ראשי
            migrationBuilder.AddPrimaryKey(
                name: "PK_Diets",
                table: "Diets",
                column: "Code");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Weight",  // שם המפתח הראשי
                table: "Weight");

            // 2. מחק את העמודה הישנה
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Weight");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Weight",
                type: "DateTime",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Weight",
                table: "Weight",
                column: "Date");



            migrationBuilder.DropPrimaryKey(
                name: "PK_Diets",  // שם המפתח הראשי
                table: "Diets");

            // 2. מחק את העמודה הישנה
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Diets");

            migrationBuilder.AddColumn<int>(
                name: "Code",
                table: "Diets",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diets",
                table: "Diets",
                column: "Code");
        }
    }
}
