﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MilliTakim.Models;

namespace MilliTakim.Migrations
{
    [DbContext(typeof(WebContext))]
    partial class WebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MilliTakim.Models.Bilet", b =>
                {
                    b.Property<int>("biletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("biletAdet")
                        .HasColumnType("int");

                    b.Property<int>("biletFiyat")
                        .HasColumnType("int");

                    b.Property<string>("macAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("macSaati")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("macTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("macYer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("biletId");

                    b.ToTable("bilet");
                });

            modelBuilder.Entity("MilliTakim.Models.Futbolcu", b =>
                {
                    b.Property<int>("playerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("ProfilePicture")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("futbolcuAd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("futbolcuInsta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("futbolcuMarketDegeri")
                        .HasColumnType("bigint");

                    b.Property<string>("futbolcuSoyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("futbolcuTwitter")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("futbolcuYas")
                        .HasColumnType("int");

                    b.HasKey("playerId");

                    b.ToTable("futbolcu");
                });
#pragma warning restore 612, 618
        }
    }
}