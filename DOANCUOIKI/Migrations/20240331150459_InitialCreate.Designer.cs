﻿// <auto-generated />
using System;
using DOANCUOIKI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DOANCUOIKI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240331150459_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DOANCUOIKI.Models.Ban", b =>
                {
                    b.Property<int>("SoBan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SoBan"));

                    b.Property<int>("SLNguoi")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("SoBan");

                    b.ToTable("Bans");
                });

            modelBuilder.Entity("DOANCUOIKI.Models.CTHoaDon", b =>
                {
                    b.Property<int>("MaHD")
                        .HasColumnType("int");

                    b.Property<int>("MaMon")
                        .HasColumnType("int");

                    b.Property<decimal>("Dongia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<int>("Soluong")
                        .HasColumnType("int");

                    b.Property<decimal>("ThanhTien")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MaHD", "MaMon");

                    b.HasIndex("MaMon");

                    b.ToTable("CTHoaDons");
                });

            modelBuilder.Entity("DOANCUOIKI.Models.HTThanhToan", b =>
                {
                    b.Property<int>("IdThanhToan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdThanhToan"));

                    b.Property<string>("HinhThuc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdThanhToan");

                    b.ToTable("HTThanhToans");
                });

            modelBuilder.Entity("DOANCUOIKI.Models.HoaDon", b =>
                {
                    b.Property<int>("MaHD")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHD"));

                    b.Property<int?>("BanSoBan")
                        .HasColumnType("int");

                    b.Property<int>("HTTToanIdThanhToan")
                        .HasColumnType("int");

                    b.Property<int>("IdThanhToan")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayRa")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayVao")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoBan")
                        .HasColumnType("int");

                    b.HasKey("MaHD");

                    b.HasIndex("BanSoBan");

                    b.HasIndex("HTTToanIdThanhToan");

                    b.ToTable("HoaDons");
                });

            modelBuilder.Entity("DOANCUOIKI.Models.LoaiThucPham", b =>
                {
                    b.Property<int>("MaLoaiTP")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLoaiTP"));

                    b.Property<string>("TenLoaiTP")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaLoaiTP");

                    b.ToTable("LoaiThucPhams");
                });

            modelBuilder.Entity("DOANCUOIKI.Models.MonAn", b =>
                {
                    b.Property<int>("MaMon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaMon"));

                    b.Property<string>("DVT")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Gia")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LoaiThucPhamId")
                        .HasColumnType("int");

                    b.Property<string>("TenMon")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaMon");

                    b.HasIndex("LoaiThucPhamId");

                    b.ToTable("MonAns");
                });

            modelBuilder.Entity("DOANCUOIKI.Models.MonAnImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MonAnId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MonAnId");

                    b.ToTable("MonAnImages");
                });

            modelBuilder.Entity("HoaDonMonAn", b =>
                {
                    b.Property<int>("HoaDonsMaHD")
                        .HasColumnType("int");

                    b.Property<int>("MonAnsMaMon")
                        .HasColumnType("int");

                    b.HasKey("HoaDonsMaHD", "MonAnsMaMon");

                    b.HasIndex("MonAnsMaMon");

                    b.ToTable("HoaDonMonAn");
                });

            modelBuilder.Entity("DOANCUOIKI.Models.CTHoaDon", b =>
                {
                    b.HasOne("DOANCUOIKI.Models.HoaDon", "HoaDon")
                        .WithMany("ct_hoadon")
                        .HasForeignKey("MaHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DOANCUOIKI.Models.MonAn", "MonAn")
                        .WithMany("ct_hoadon")
                        .HasForeignKey("MaMon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HoaDon");

                    b.Navigation("MonAn");
                });

            modelBuilder.Entity("DOANCUOIKI.Models.HoaDon", b =>
                {
                    b.HasOne("DOANCUOIKI.Models.Ban", "Ban")
                        .WithMany()
                        .HasForeignKey("BanSoBan");

                    b.HasOne("DOANCUOIKI.Models.HTThanhToan", "HTTToan")
                        .WithMany()
                        .HasForeignKey("HTTToanIdThanhToan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ban");

                    b.Navigation("HTTToan");
                });

            modelBuilder.Entity("DOANCUOIKI.Models.MonAn", b =>
                {
                    b.HasOne("DOANCUOIKI.Models.LoaiThucPham", "LoaiThucPham")
                        .WithMany("Mons")
                        .HasForeignKey("LoaiThucPhamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiThucPham");
                });

            modelBuilder.Entity("DOANCUOIKI.Models.MonAnImage", b =>
                {
                    b.HasOne("DOANCUOIKI.Models.MonAn", "MonAn")
                        .WithMany("Images")
                        .HasForeignKey("MonAnId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MonAn");
                });

            modelBuilder.Entity("HoaDonMonAn", b =>
                {
                    b.HasOne("DOANCUOIKI.Models.HoaDon", null)
                        .WithMany()
                        .HasForeignKey("HoaDonsMaHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DOANCUOIKI.Models.MonAn", null)
                        .WithMany()
                        .HasForeignKey("MonAnsMaMon")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DOANCUOIKI.Models.HoaDon", b =>
                {
                    b.Navigation("ct_hoadon");
                });

            modelBuilder.Entity("DOANCUOIKI.Models.LoaiThucPham", b =>
                {
                    b.Navigation("Mons");
                });

            modelBuilder.Entity("DOANCUOIKI.Models.MonAn", b =>
                {
                    b.Navigation("Images");

                    b.Navigation("ct_hoadon");
                });
#pragma warning restore 612, 618
        }
    }
}
