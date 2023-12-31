﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Fiorello2.Migrations
{
    public partial class ChangeCategoryId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodcuts_Categories_CategoryId",
                table: "Prodcuts");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Prodcuts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Prodcuts_Categories_CategoryId",
                table: "Prodcuts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodcuts_Categories_CategoryId",
                table: "Prodcuts");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Prodcuts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodcuts_Categories_CategoryId",
                table: "Prodcuts",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
