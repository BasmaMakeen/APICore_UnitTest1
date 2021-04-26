using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class firstMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Role_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Role_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.User_id);
                });

            migrationBuilder.CreateTable(
                name: "User_Roles",
                columns: table => new
                {
                    UR_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role_id = table.Column<int>(type: "int", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Roles", x => x.UR_ID);
                    table.ForeignKey(
                        name: "FK_User_Roles_Roles_Role_id",
                        column: x => x.Role_id,
                        principalTable: "Roles",
                        principalColumn: "Role_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Roles_users_User_id",
                        column: x => x.User_id,
                        principalTable: "users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Role_id", "Role_name" },
                values: new object[,]
                {
                    { 1, "admin" },
                    { 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "User_id", "Email", "Password", "Phone", "User_name" },
                values: new object[,]
                {
                    { 1, null, 123, 0, "Basma" },
                    { 2, null, 456, 0, "Eman" },
                    { 3, null, 789, 0, "admin" }
                });

            migrationBuilder.InsertData(
                table: "User_Roles",
                columns: new[] { "UR_ID", "Role_id", "User_id" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "User_Roles",
                columns: new[] { "UR_ID", "Role_id", "User_id" },
                values: new object[] { 1, 1, 2 });

            migrationBuilder.InsertData(
                table: "User_Roles",
                columns: new[] { "UR_ID", "Role_id", "User_id" },
                values: new object[] { 3, 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_User_Roles_Role_id",
                table: "User_Roles",
                column: "Role_id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Roles_User_id",
                table: "User_Roles",
                column: "User_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Roles");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
