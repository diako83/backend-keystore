﻿// <auto-generated />
using System;
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
    [Migration("20230222134238_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backend_keystore.Models.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CampaignReceiptId")
                        .HasColumnType("integer");

                    b.Property<long>("EAN")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("NormalPriceReceiptId")
                        .HasColumnType("integer");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CampaignReceiptId");

                    b.HasIndex("NormalPriceReceiptId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("backend_keystore.Models.Receipts.CampaignReceipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("CampaignReceipt");
                });

            modelBuilder.Entity("backend_keystore.Models.Receipts.NormalPriceReceipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("NormalPriceReceipt");
                });

            modelBuilder.Entity("backend_keystore.Models.Receipts.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CampaignReceiptId")
                        .HasColumnType("integer");

                    b.Property<int?>("NormalPriceReceiptId")
                        .HasColumnType("integer");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("date")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("CampaignReceiptId");

                    b.HasIndex("NormalPriceReceiptId");

                    b.ToTable("Receipt");
                });

            modelBuilder.Entity("backend_keystore.Models.Products.Product", b =>
                {
                    b.HasOne("backend_keystore.Models.Receipts.CampaignReceipt", null)
                        .WithMany("shoppingCart")
                        .HasForeignKey("CampaignReceiptId");

                    b.HasOne("backend_keystore.Models.Receipts.NormalPriceReceipt", null)
                        .WithMany("shoppingCart")
                        .HasForeignKey("NormalPriceReceiptId");
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

            modelBuilder.Entity("backend_keystore.Models.Receipts.CampaignReceipt", b =>
                {
                    b.Navigation("shoppingCart");
                });

            modelBuilder.Entity("backend_keystore.Models.Receipts.NormalPriceReceipt", b =>
                {
                    b.Navigation("shoppingCart");
                });
#pragma warning restore 612, 618
        }
    }
}