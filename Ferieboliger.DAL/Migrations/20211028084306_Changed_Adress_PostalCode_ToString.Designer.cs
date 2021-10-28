﻿// <auto-generated />
using System;
using Ferieboliger.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ferieboliger.DAL.Migrations
{
    [DbContext(typeof(FerieboligDbContext))]
    [Migration("20211028084306_Changed_Adress_PostalCode_ToString")]
    partial class Changed_Adress_PostalCode_ToString
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FacilitetFeriebolig", b =>
                {
                    b.Property<int>("FaciliteterId")
                        .HasColumnType("int");

                    b.Property<int>("FerieboligerId")
                        .HasColumnType("int");

                    b.HasKey("FaciliteterId", "FerieboligerId");

                    b.HasIndex("FerieboligerId");

                    b.ToTable("FacilitetFeriebolig");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Adresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Land")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Postnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vej")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adresse");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("AfrejseDato")
                        .HasColumnType("datetime2");

                    b.Property<int>("Beskatning")
                        .HasColumnType("int");

                    b.Property<string>("Kommentarer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NoeglerReturneret")
                        .HasColumnType("bit");

                    b.Property<bool>("NoeglerSendt")
                        .HasColumnType("bit");

                    b.Property<int>("PointPris")
                        .HasColumnType("int");

                    b.Property<int>("Pris")
                        .HasColumnType("int");

                    b.Property<DateTime>("UdlejDato")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Bookinger");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Bruger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Point")
                        .HasColumnType("int");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brugere");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Facilitet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beskrivelse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Faciliteter");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Feriebolig", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("AfgangTidspunkt")
                        .HasColumnType("time");

                    b.Property<int>("AfstandIndkoeb")
                        .HasColumnType("int");

                    b.Property<int>("AfstandRestaurant")
                        .HasColumnType("int");

                    b.Property<int>("AfstandStrand")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("AnkomstTidspunkt")
                        .HasColumnType("time");

                    b.Property<int>("AntalBadevaerelser")
                        .HasColumnType("int");

                    b.Property<int>("AntalHusdyr")
                        .HasColumnType("int");

                    b.Property<int>("AntalKvadratmeter")
                        .HasColumnType("int");

                    b.Property<int>("AntalPersoner")
                        .HasColumnType("int");

                    b.Property<int>("AntalSovepladser")
                        .HasColumnType("int");

                    b.Property<string>("Bemaerkninger")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BeskatningHoej")
                        .HasColumnType("int");

                    b.Property<int>("BeskatningLav")
                        .HasColumnType("int");

                    b.Property<string>("Beskrivelse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Grundareal")
                        .HasColumnType("int");

                    b.Property<bool>("HusdyrTilladt")
                        .HasColumnType("bit");

                    b.Property<int>("NoeglerTilgaengelig")
                        .HasColumnType("int");

                    b.Property<int>("PrisHoej")
                        .HasColumnType("int");

                    b.Property<int>("PrisLav")
                        .HasColumnType("int");

                    b.Property<bool>("SendNoegler")
                        .HasColumnType("bit");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ferieboliger");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Filoplysning", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Filoplysninger");
                });

            modelBuilder.Entity("FacilitetFeriebolig", b =>
                {
                    b.HasOne("Ferieboliger.DAL.Models.Facilitet", null)
                        .WithMany()
                        .HasForeignKey("FaciliteterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ferieboliger.DAL.Models.Feriebolig", null)
                        .WithMany()
                        .HasForeignKey("FerieboligerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Booking", b =>
                {
                    b.HasOne("Ferieboliger.DAL.Models.Bruger", "Bruger")
                        .WithOne("Booking")
                        .HasForeignKey("Ferieboliger.DAL.Models.Booking", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ferieboliger.DAL.Models.Feriebolig", "Feriebolig")
                        .WithMany("Bookinger")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bruger");

                    b.Navigation("Feriebolig");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Feriebolig", b =>
                {
                    b.HasOne("Ferieboliger.DAL.Models.Adresse", "Adresse")
                        .WithOne("Feriebolig")
                        .HasForeignKey("Ferieboliger.DAL.Models.Feriebolig", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adresse");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Filoplysning", b =>
                {
                    b.HasOne("Ferieboliger.DAL.Models.Feriebolig", "Feriebolig")
                        .WithMany("Filer")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feriebolig");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Adresse", b =>
                {
                    b.Navigation("Feriebolig");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Bruger", b =>
                {
                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Feriebolig", b =>
                {
                    b.Navigation("Bookinger");

                    b.Navigation("Filer");
                });
#pragma warning restore 612, 618
        }
    }
}
