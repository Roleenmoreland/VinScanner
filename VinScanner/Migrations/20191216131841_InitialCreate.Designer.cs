﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VinScanner.Data;

namespace VinScanner.Migrations
{
    [DbContext(typeof(VinScannerContext))]
    [Migration("20191216131841_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VinScanner.Models.Repository.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress");

                    b.Property<int>("MobileNumber");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.HasKey("ClientId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("VinScanner.Models.Repository.Dealer", b =>
                {
                    b.Property<int>("DealerId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("UserNmae")
                        .IsRequired();

                    b.HasKey("DealerId");

                    b.ToTable("Dealers");
                });

            modelBuilder.Entity("VinScanner.Models.Repository.VechileDetails", b =>
                {
                    b.Property<int>("VechileDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId");

                    b.Property<string>("Colour");

                    b.Property<string>("Description");

                    b.Property<string>("Engine");

                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<string>("Plate");

                    b.Property<string>("Vin");

                    b.HasKey("VechileDetailsId");

                    b.HasIndex("ClientId");

                    b.ToTable("VechileDetails");
                });

            modelBuilder.Entity("VinScanner.Models.Repository.VechileDetails", b =>
                {
                    b.HasOne("VinScanner.Models.Repository.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");
                });
#pragma warning restore 612, 618
        }
    }
}
