﻿// <auto-generated />
using System;
using API_Tutorial_ProductManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_Tutorial_ProductManager.Migrations
{
    [DbContext(typeof(DContext))]
    [Migration("20240807070020_AddTableProductType")]
    partial class AddTableProductType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API_Tutorial_ProductManager.Data.Product_data", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<byte>("Discount")
                        .HasColumnType("smallint");

                    b.Property<int?>("Id_Type")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("Id_Type");

                    b.ToTable("ProductManager");
                });

            modelBuilder.Entity("API_Tutorial_ProductManager.Data.Products_Type", b =>
                {
                    b.Property<int>("Id_Type")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id_Type"));

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id_Type");

                    b.ToTable("Products_Type");
                });

            modelBuilder.Entity("API_Tutorial_ProductManager.Data.Product_data", b =>
                {
                    b.HasOne("API_Tutorial_ProductManager.Data.Products_Type", "Products_Type")
                        .WithMany("Product_Datas")
                        .HasForeignKey("Id_Type");

                    b.Navigation("Products_Type");
                });

            modelBuilder.Entity("API_Tutorial_ProductManager.Data.Products_Type", b =>
                {
                    b.Navigation("Product_Datas");
                });
#pragma warning restore 612, 618
        }
    }
}
