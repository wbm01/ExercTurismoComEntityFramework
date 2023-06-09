﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Turismo_EntityF.Data;

#nullable disable

namespace Turismo_EntityF.Migrations
{
    [DbContext(typeof(Turismo_EntityFContext))]
    partial class Turismo_EntityFContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Turismo_EntityF.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Complement")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtRegisterAddress")
                        .HasColumnType("datetime2");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Turismo_EntityF.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtRegisterCity")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("Turismo_EntityF.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtRegisterClient")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameClient")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressClientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("Turismo_EntityF.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressHotelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtRegisterHotel")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameHotel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ValueHotel")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AddressHotelId");

                    b.ToTable("Hotel");
                });

            modelBuilder.Entity("Turismo_EntityF.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientPackageId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DtRegisterPackage")
                        .HasColumnType("datetime2");

                    b.Property<int>("HotelPackageId")
                        .HasColumnType("int");

                    b.Property<int>("TicketPackageId")
                        .HasColumnType("int");

                    b.Property<double>("ValuePackage")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ClientPackageId");

                    b.HasIndex("HotelPackageId");

                    b.HasIndex("TicketPackageId");

                    b.ToTable("Package");
                });

            modelBuilder.Entity("Turismo_EntityF.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClientTicketId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTicket")
                        .HasColumnType("datetime2");

                    b.Property<int>("DestinyId")
                        .HasColumnType("int");

                    b.Property<int>("OriginId")
                        .HasColumnType("int");

                    b.Property<decimal>("ValueTicket")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ClientTicketId");

                    b.HasIndex("DestinyId");

                    b.HasIndex("OriginId");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Turismo_EntityF.Models.Address", b =>
                {
                    b.HasOne("Turismo_EntityF.Models.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Turismo_EntityF.Models.Client", b =>
                {
                    b.HasOne("Turismo_EntityF.Models.Address", "AddressClient")
                        .WithMany()
                        .HasForeignKey("AddressClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressClient");
                });

            modelBuilder.Entity("Turismo_EntityF.Models.Hotel", b =>
                {
                    b.HasOne("Turismo_EntityF.Models.Address", "AddressHotel")
                        .WithMany()
                        .HasForeignKey("AddressHotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddressHotel");
                });

            modelBuilder.Entity("Turismo_EntityF.Models.Package", b =>
                {
                    b.HasOne("Turismo_EntityF.Models.Client", "ClientPackage")
                        .WithMany()
                        .HasForeignKey("ClientPackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Turismo_EntityF.Models.Hotel", "HotelPackage")
                        .WithMany()
                        .HasForeignKey("HotelPackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Turismo_EntityF.Models.Ticket", "TicketPackage")
                        .WithMany()
                        .HasForeignKey("TicketPackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientPackage");

                    b.Navigation("HotelPackage");

                    b.Navigation("TicketPackage");
                });

            modelBuilder.Entity("Turismo_EntityF.Models.Ticket", b =>
                {
                    b.HasOne("Turismo_EntityF.Models.Client", "ClientTicket")
                        .WithMany()
                        .HasForeignKey("ClientTicketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Turismo_EntityF.Models.Address", "Destiny")
                        .WithMany()
                        .HasForeignKey("DestinyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Turismo_EntityF.Models.Address", "Origin")
                        .WithMany()
                        .HasForeignKey("OriginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientTicket");

                    b.Navigation("Destiny");

                    b.Navigation("Origin");
                });
#pragma warning restore 612, 618
        }
    }
}
