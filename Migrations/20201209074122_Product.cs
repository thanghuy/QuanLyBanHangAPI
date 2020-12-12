using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanLyBanHangAPI.Migrations
{
    public partial class Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>("Image", "Product", "varchar(255)", 
            unicode:false, maxLength: 255, nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
