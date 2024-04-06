using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DOANCUOIKI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bans",
                columns: table => new
                {
                    SoBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SLNguoi = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bans", x => x.SoBan);
                });

            migrationBuilder.CreateTable(
                name: "HTThanhToans",
                columns: table => new
                {
                    IdThanhToan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhThuc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HTThanhToans", x => x.IdThanhToan);
                });

            migrationBuilder.CreateTable(
                name: "LoaiThucPhams",
                columns: table => new
                {
                    MaLoaiTP = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenLoaiTP = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiThucPhams", x => x.MaLoaiTP);
                });

            migrationBuilder.CreateTable(
                name: "HoaDons",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BanSoBan = table.Column<int>(type: "int", nullable: true),
                    SoBan = table.Column<int>(type: "int", nullable: false),
                    NgayVao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NgayRa = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HTTToanIdThanhToan = table.Column<int>(type: "int", nullable: false),
                    IdThanhToan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDons", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HoaDons_Bans_BanSoBan",
                        column: x => x.BanSoBan,
                        principalTable: "Bans",
                        principalColumn: "SoBan");
                    table.ForeignKey(
                        name: "FK_HoaDons_HTThanhToans_HTTToanIdThanhToan",
                        column: x => x.HTTToanIdThanhToan,
                        principalTable: "HTThanhToans",
                        principalColumn: "IdThanhToan",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonAns",
                columns: table => new
                {
                    MaMon = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenMon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DVT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    LoaiThucPhamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonAns", x => x.MaMon);
                    table.ForeignKey(
                        name: "FK_MonAns_LoaiThucPhams_LoaiThucPhamId",
                        column: x => x.LoaiThucPhamId,
                        principalTable: "LoaiThucPhams",
                        principalColumn: "MaLoaiTP",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CTHoaDons",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false),
                    MaMon = table.Column<int>(type: "int", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Dongia = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ThanhTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CTHoaDons", x => new { x.MaHD, x.MaMon });
                    table.ForeignKey(
                        name: "FK_CTHoaDons_HoaDons_MaHD",
                        column: x => x.MaHD,
                        principalTable: "HoaDons",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CTHoaDons_MonAns_MaMon",
                        column: x => x.MaMon,
                        principalTable: "MonAns",
                        principalColumn: "MaMon",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDonMonAn",
                columns: table => new
                {
                    HoaDonsMaHD = table.Column<int>(type: "int", nullable: false),
                    MonAnsMaMon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDonMonAn", x => new { x.HoaDonsMaHD, x.MonAnsMaMon });
                    table.ForeignKey(
                        name: "FK_HoaDonMonAn_HoaDons_HoaDonsMaHD",
                        column: x => x.HoaDonsMaHD,
                        principalTable: "HoaDons",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDonMonAn_MonAns_MonAnsMaMon",
                        column: x => x.MonAnsMaMon,
                        principalTable: "MonAns",
                        principalColumn: "MaMon",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonAnImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonAnId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonAnImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonAnImages_MonAns_MonAnId",
                        column: x => x.MonAnId,
                        principalTable: "MonAns",
                        principalColumn: "MaMon",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CTHoaDons_MaMon",
                table: "CTHoaDons",
                column: "MaMon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDonMonAn_MonAnsMaMon",
                table: "HoaDonMonAn",
                column: "MonAnsMaMon");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_BanSoBan",
                table: "HoaDons",
                column: "BanSoBan");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDons_HTTToanIdThanhToan",
                table: "HoaDons",
                column: "HTTToanIdThanhToan");

            migrationBuilder.CreateIndex(
                name: "IX_MonAnImages_MonAnId",
                table: "MonAnImages",
                column: "MonAnId");

            migrationBuilder.CreateIndex(
                name: "IX_MonAns_LoaiThucPhamId",
                table: "MonAns",
                column: "LoaiThucPhamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CTHoaDons");

            migrationBuilder.DropTable(
                name: "HoaDonMonAn");

            migrationBuilder.DropTable(
                name: "MonAnImages");

            migrationBuilder.DropTable(
                name: "HoaDons");

            migrationBuilder.DropTable(
                name: "MonAns");

            migrationBuilder.DropTable(
                name: "Bans");

            migrationBuilder.DropTable(
                name: "HTThanhToans");

            migrationBuilder.DropTable(
                name: "LoaiThucPhams");
        }
    }
}
