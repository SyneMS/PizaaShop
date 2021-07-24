﻿// <auto-generated />
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entities.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Models.Ingradients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IngradientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Prize")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Ingradients");
                });

            modelBuilder.Entity("Entities.Models.PizzaDetails", b =>
                {
                    b.Property<int>("PizzaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PizzaName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PizzaPic")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<decimal>("PizzaPrize")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("PizzaId");

                    b.ToTable("PizzaDetails");
                });

            modelBuilder.Entity("Entities.Models.PizzaIngradientOrderDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Prize")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("PizzaIngradientOrderDetails");
                });

            modelBuilder.Entity("Entities.Models.PizzaIngradients", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IngradientId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Prize")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaIngradients");
                });

            modelBuilder.Entity("Entities.Models.PizzaOrderDetails", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("FinalPrize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("OrderId");

                    b.ToTable("PizzaOrderDetails");
                });

            modelBuilder.Entity("Entities.Models.PizzaIngradientOrderDetails", b =>
                {
                    b.HasOne("Entities.Models.PizzaOrderDetails", "PizzaOrderDetails")
                        .WithMany("Ingradients")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PizzaOrderDetails");
                });

            modelBuilder.Entity("Entities.Models.PizzaIngradients", b =>
                {
                    b.HasOne("Entities.Models.PizzaDetails", "PizzaDetails")
                        .WithMany("PizzaIngradients")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PizzaDetails");
                });

            modelBuilder.Entity("Entities.Models.PizzaDetails", b =>
                {
                    b.Navigation("PizzaIngradients");
                });

            modelBuilder.Entity("Entities.Models.PizzaOrderDetails", b =>
                {
                    b.Navigation("Ingradients");
                });
#pragma warning restore 612, 618
        }
    }
}