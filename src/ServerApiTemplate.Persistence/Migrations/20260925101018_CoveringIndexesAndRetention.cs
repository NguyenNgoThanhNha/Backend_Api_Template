using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerApiTemplate.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CoveringIndexesAndRetention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sys_UserRole_CreatedDate",
                table: "Sys_UserRole");

            migrationBuilder.DropIndex(
                name: "IX_Sys_UserActivity_CreatedDate",
                table: "Sys_UserActivity");

            migrationBuilder.DropIndex(
                name: "IX_Sys_RoleActivity_CreatedDate",
                table: "Sys_RoleActivity");

            migrationBuilder.DropIndex(
                name: "IX_Sys_Role_CreatedDate",
                table: "Sys_Role");

            migrationBuilder.DropIndex(
                name: "IX_Sys_RefreshToken_CreatedDate",
                table: "Sys_RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_Sys_Activity_CreatedDate",
                table: "Sys_Activity");

            migrationBuilder.DropIndex(
                name: "IX_Sys_Account_CreatedDate",
                table: "Sys_Account");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_UserRole_CreatedDate",
                table: "Sys_UserRole",
                column: "CreatedDate")
                .Annotation("SqlServer:Include", new[] { "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Sys_UserActivity_CreatedDate",
                table: "Sys_UserActivity",
                column: "CreatedDate")
                .Annotation("SqlServer:Include", new[] { "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Sys_RoleActivity_CreatedDate",
                table: "Sys_RoleActivity",
                column: "CreatedDate")
                .Annotation("SqlServer:Include", new[] { "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Sys_Role_CreatedDate",
                table: "Sys_Role",
                column: "CreatedDate")
                .Annotation("SqlServer:Include", new[] { "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Sys_RefreshToken_CreatedDate",
                table: "Sys_RefreshToken",
                column: "CreatedDate")
                .Annotation("SqlServer:Include", new[] { "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Sys_RefreshToken_ExpiresAt",
                table: "Sys_RefreshToken",
                column: "ExpiresAt");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_Activity_CreatedDate",
                table: "Sys_Activity",
                column: "CreatedDate")
                .Annotation("SqlServer:Include", new[] { "IsDeleted" });

            migrationBuilder.CreateIndex(
                name: "IX_Sys_Account_CreatedDate",
                table: "Sys_Account",
                column: "CreatedDate")
                .Annotation("SqlServer:Include", new[] { "IsDeleted" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sys_UserRole_CreatedDate",
                table: "Sys_UserRole");

            migrationBuilder.DropIndex(
                name: "IX_Sys_UserActivity_CreatedDate",
                table: "Sys_UserActivity");

            migrationBuilder.DropIndex(
                name: "IX_Sys_RoleActivity_CreatedDate",
                table: "Sys_RoleActivity");

            migrationBuilder.DropIndex(
                name: "IX_Sys_Role_CreatedDate",
                table: "Sys_Role");

            migrationBuilder.DropIndex(
                name: "IX_Sys_RefreshToken_CreatedDate",
                table: "Sys_RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_Sys_RefreshToken_ExpiresAt",
                table: "Sys_RefreshToken");

            migrationBuilder.DropIndex(
                name: "IX_Sys_Activity_CreatedDate",
                table: "Sys_Activity");

            migrationBuilder.DropIndex(
                name: "IX_Sys_Account_CreatedDate",
                table: "Sys_Account");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_UserRole_CreatedDate",
                table: "Sys_UserRole",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_UserActivity_CreatedDate",
                table: "Sys_UserActivity",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_RoleActivity_CreatedDate",
                table: "Sys_RoleActivity",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_Role_CreatedDate",
                table: "Sys_Role",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_RefreshToken_CreatedDate",
                table: "Sys_RefreshToken",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_Activity_CreatedDate",
                table: "Sys_Activity",
                column: "CreatedDate");

            migrationBuilder.CreateIndex(
                name: "IX_Sys_Account_CreatedDate",
                table: "Sys_Account",
                column: "CreatedDate");
        }
    }
}
