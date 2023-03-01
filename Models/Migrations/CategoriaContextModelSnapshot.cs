﻿// <auto-generated />
using EcommerceAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EcommerceAPI.Migrations
{
    [DbContext(typeof(CategoriaContext))]
    partial class CategoriaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("EcommerceAPI.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NomeCategoria")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("StatusCategoria")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });
#pragma warning restore 612, 618
        }
    }
}