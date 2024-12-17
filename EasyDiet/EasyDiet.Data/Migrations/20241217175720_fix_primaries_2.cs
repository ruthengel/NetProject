using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyDiet.Data.Migrations
{
    public partial class fix_primaries_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // 1. מחק Foreign Key אם קיים
            migrationBuilder.DropForeignKey(
                name: "FK_Weight_Customers_CustomerId",
                table: "Weight");

            migrationBuilder.DropPrimaryKey(
            name: "PK_Customers",  // שם המפתח הראשי
            table: "Customers");

            // 2. מחק את העמודה הישנה
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Customers");

            // 3. צור עמודה חדשה ללא IDENTITY
            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Customers",
                nullable: false);

            // 4. הגדר את העמודה החדשה כמפתח ראשי
            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            // 5. שחזר את Foreign Key
            migrationBuilder.AddForeignKey(
                name: "FK_Weight_Customers_CustomerId",
                table: "Weight",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // במקרה של שחזור
            migrationBuilder.DropForeignKey(
               name: "FK_Weight_Customers_CustomerId",
               table: "Weight");


            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",  // שם המפתח הראשי
                table: "Customers");

            // 2. מחק את העמודה הישנה
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Customers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Weight_Customers_CustomerId",
                table: "Weight",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);


        }
    }
}
