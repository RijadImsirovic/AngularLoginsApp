﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZenturyLoginsApp.DataServices.Migrations
{
    /// <inheritdoc />
    public partial class FK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Logins_UserId",
                table: "Logins",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logins_AspNetUsers_UserId",
                table: "Logins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logins_AspNetUsers_UserId",
                table: "Logins");

            migrationBuilder.DropIndex(
                name: "IX_Logins_UserId",
                table: "Logins");
        }
    }
}
