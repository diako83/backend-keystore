﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using backend_keystore.Data;

#nullable disable

namespace backendkeystore.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230226194849_addUser")]
    partial class addUser
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backend_keystore.Models.EAN.EanCampaign", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<long>("CampaignEan")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("EANCampaigns");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            CampaignEan = 5000112637922L
                        },
                        new
                        {
                            Id = "2",
                            CampaignEan = 5000112637939L
                        },
                        new
                        {
                            Id = "3",
                            CampaignEan = 7310865004703L
                        },
                        new
                        {
                            Id = "4",
                            CampaignEan = 7340005404261L
                        },
                        new
                        {
                            Id = "5",
                            CampaignEan = 7310532109090L
                        },
                        new
                        {
                            Id = "6",
                            CampaignEan = 7611612222105L
                        });
                });

            modelBuilder.Entity("backend_keystore.Models.Products.Product", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<long>("Ean")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Ean = 5000112637922L,
                            Name = "Coca-cola",
                            Price = 19.949999999999999
                        },
                        new
                        {
                            Id = "2",
                            Ean = 5000112637939L,
                            Name = "Sprite",
                            Price = 19.949999999999999
                        },
                        new
                        {
                            Id = "3",
                            Ean = 7310865004703L,
                            Name = "Pepsi",
                            Price = 19.949999999999999
                        },
                        new
                        {
                            Id = "4",
                            Ean = 7340005404261L,
                            Name = "Seven-upp",
                            Price = 19.949999999999999
                        },
                        new
                        {
                            Id = "5",
                            Ean = 7310532109090L,
                            Name = "Fanta",
                            Price = 19.949999999999999
                        },
                        new
                        {
                            Id = "6",
                            Ean = 5000112555922L,
                            Name = "Glass",
                            Price = 19.75
                        },
                        new
                        {
                            Id = "7",
                            Ean = 5000112666622L,
                            Name = "Mjöl",
                            Price = 25.5
                        },
                        new
                        {
                            Id = "8",
                            Ean = 5000112337922L,
                            Name = "Champo",
                            Price = 18.59
                        });
                });

            modelBuilder.Entity("backend_keystore.Models.Receipts.CampaignReceipt", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<List<string>>("ProductIds")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.ToTable("CampaignReceipts");
                });

            modelBuilder.Entity("backend_keystore.Models.Receipts.NormalPriceReceipt", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<List<string>>("ProductIds")
                        .IsRequired()
                        .HasColumnType("text[]");

                    b.HasKey("Id");

                    b.ToTable("NormalPriceReceipts");
                });

            modelBuilder.Entity("backend_keystore.Models.Receipts.Receipt", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("CampaignReceiptId")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalPriceReceiptId")
                        .HasColumnType("text");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CampaignReceiptId");

                    b.HasIndex("NormalPriceReceiptId");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("backend_keystore.Models.User.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("backend_keystore.Models.Receipts.Receipt", b =>
                {
                    b.HasOne("backend_keystore.Models.Receipts.CampaignReceipt", "CampaignReceipt")
                        .WithMany()
                        .HasForeignKey("CampaignReceiptId");

                    b.HasOne("backend_keystore.Models.Receipts.NormalPriceReceipt", "NormalPriceReceipt")
                        .WithMany()
                        .HasForeignKey("NormalPriceReceiptId");

                    b.Navigation("CampaignReceipt");

                    b.Navigation("NormalPriceReceipt");
                });
#pragma warning restore 612, 618
        }
    }
}