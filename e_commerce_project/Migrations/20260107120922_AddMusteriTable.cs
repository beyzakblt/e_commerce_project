using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_commerce_project.Migrations
{
    /// <inheritdoc />
    public partial class AddMusteriTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Iletisimler",
                table: "Iletisimler");

            migrationBuilder.RenameTable(
                name: "Iletisimler",
                newName: "Iletisim");

            migrationBuilder.RenameColumn(
                name: "users",
                table: "Yonetici",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "statu",
                table: "Yonetici",
                newName: "Statu");

            migrationBuilder.RenameColumn(
                name: "pass",
                table: "Yonetici",
                newName: "Pass");

            migrationBuilder.RenameColumn(
                name: "durum",
                table: "Yonetici",
                newName: "Durum");

            migrationBuilder.RenameColumn(
                name: "Tarih",
                table: "Iletisim",
                newName: "tarih");

            migrationBuilder.RenameColumn(
                name: "Mesaj",
                table: "Iletisim",
                newName: "mesaj");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Iletisim",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "AdSoyad",
                table: "Iletisim",
                newName: "adSoyad");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Iletisim",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "Users",
                table: "Yonetici",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Pass",
                table: "Yonetici",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "users",
                table: "Kullanıcılar",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "pass",
                table: "Kullanıcılar",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "tarih",
                table: "Iletisim",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "mesaj",
                table: "Iletisim",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Iletisim",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "adSoyad",
                table: "Iletisim",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Okundu",
                table: "Iletisim",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Iletisim",
                table: "Iletisim",
                column: "id");

            migrationBuilder.CreateTable(
                name: "IletisimDurumLog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IletisimId = table.Column<int>(type: "int", nullable: false),
                    AdminId = table.Column<int>(type: "int", nullable: false),
                    Okundu = table.Column<bool>(type: "bit", nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Iletisim__3214EC070345F39E", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musteriler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KayitTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musteriler", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IletisimDurumLog");

            migrationBuilder.DropTable(
                name: "Musteriler");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Iletisim",
                table: "Iletisim");

            migrationBuilder.DropColumn(
                name: "Okundu",
                table: "Iletisim");

            migrationBuilder.RenameTable(
                name: "Iletisim",
                newName: "Iletisimler");

            migrationBuilder.RenameColumn(
                name: "Users",
                table: "Yonetici",
                newName: "users");

            migrationBuilder.RenameColumn(
                name: "Statu",
                table: "Yonetici",
                newName: "statu");

            migrationBuilder.RenameColumn(
                name: "Pass",
                table: "Yonetici",
                newName: "pass");

            migrationBuilder.RenameColumn(
                name: "Durum",
                table: "Yonetici",
                newName: "durum");

            migrationBuilder.RenameColumn(
                name: "tarih",
                table: "Iletisimler",
                newName: "Tarih");

            migrationBuilder.RenameColumn(
                name: "mesaj",
                table: "Iletisimler",
                newName: "Mesaj");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Iletisimler",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "adSoyad",
                table: "Iletisimler",
                newName: "AdSoyad");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Iletisimler",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "users",
                table: "Yonetici",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "pass",
                table: "Yonetici",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "users",
                table: "Kullanıcılar",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "pass",
                table: "Kullanıcılar",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Tarih",
                table: "Iletisimler",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Mesaj",
                table: "Iletisimler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Iletisimler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AdSoyad",
                table: "Iletisimler",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Iletisimler",
                table: "Iletisimler",
                column: "Id");
        }
    }
}
