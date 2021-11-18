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
    [Migration("20211118092111_NyModelSpaerring_OmdoebIBookinger_FjernetStatusFeltFeriebolig")]
    partial class NyModelSpaerring_OmdoebIBookinger_FjernetStatusFeltFeriebolig
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

                    b.Property<int>("FerieboligId")
                        .HasColumnType("int");

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

                    b.HasIndex("FerieboligId")
                        .IsUnique();

                    b.ToTable("Adresser");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Beskatning")
                        .HasColumnType("int");

                    b.Property<int>("BrugerId")
                        .HasColumnType("int");

                    b.Property<int>("FerieboligId")
                        .HasColumnType("int");

                    b.Property<string>("Kommentarer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NoeglerReturneret")
                        .HasColumnType("bit");

                    b.Property<bool>("NoeglerSendt")
                        .HasColumnType("bit");

                    b.Property<string>("PensionistEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PensionistNavn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PensionistTelefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PointPris")
                        .HasColumnType("int");

                    b.Property<int>("Pris")
                        .HasColumnType("int");

                    b.Property<DateTime>("SlutDato")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDato")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BrugerId");

                    b.HasIndex("FerieboligId");

                    b.ToTable("Bookinger");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Bruger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Navn")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.Property<byte[]>("Bemaerkninger")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("BeskatningHoejUge")
                        .HasColumnType("int");

                    b.Property<int>("BeskatningHoejWeekend")
                        .HasColumnType("int");

                    b.Property<int>("BeskatningLavUge")
                        .HasColumnType("int");

                    b.Property<int>("BeskatningLavWeekend")
                        .HasColumnType("int");

                    b.Property<byte[]>("Beskrivelse")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Grundareal")
                        .HasColumnType("int");

                    b.Property<bool>("HusdyrTilladt")
                        .HasColumnType("bit");

                    b.Property<int>("NoeglerTilgaengelig")
                        .HasColumnType("int");

                    b.Property<int>("PrisHoejUge")
                        .HasColumnType("int");

                    b.Property<int>("PrisHoejWeekend")
                        .HasColumnType("int");

                    b.Property<int>("PrisLavUge")
                        .HasColumnType("int");

                    b.Property<int>("PrisLavWeekend")
                        .HasColumnType("int");

                    b.Property<bool>("SendNoegler")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Ferieboliger");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Filoplysning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Data")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("FerieboligId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FerieboligId");

                    b.ToTable("Filoplysninger");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Leveringsadresse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Afdeling")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BookingId")
                        .HasColumnType("int");

                    b.Property<string>("By")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Firmaadresse")
                        .HasColumnType("bit");

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

                    b.HasIndex("BookingId")
                        .IsUnique();

                    b.ToTable("Leveringsadresser");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.RedigerbarSide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RedigerbarSider");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Spaerring", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beskrivelse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FerieboligId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SlutDato")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDato")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FerieboligId");

                    b.ToTable("Spaerringer");
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

            modelBuilder.Entity("Ferieboliger.DAL.Models.Adresse", b =>
                {
                    b.HasOne("Ferieboliger.DAL.Models.Feriebolig", "Feriebolig")
                        .WithOne("Adresse")
                        .HasForeignKey("Ferieboliger.DAL.Models.Adresse", "FerieboligId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feriebolig");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Booking", b =>
                {
                    b.HasOne("Ferieboliger.DAL.Models.Bruger", "Bruger")
                        .WithMany("Bookinger")
                        .HasForeignKey("BrugerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ferieboliger.DAL.Models.Feriebolig", "Feriebolig")
                        .WithMany("Bookinger")
                        .HasForeignKey("FerieboligId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bruger");

                    b.Navigation("Feriebolig");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Filoplysning", b =>
                {
                    b.HasOne("Ferieboliger.DAL.Models.Feriebolig", "Feriebolig")
                        .WithMany("Filer")
                        .HasForeignKey("FerieboligId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feriebolig");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Leveringsadresse", b =>
                {
                    b.HasOne("Ferieboliger.DAL.Models.Booking", "Booking")
                        .WithOne("Leveringsadresse")
                        .HasForeignKey("Ferieboliger.DAL.Models.Leveringsadresse", "BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Spaerring", b =>
                {
                    b.HasOne("Ferieboliger.DAL.Models.Feriebolig", "Feriebolig")
                        .WithMany("Spaerringer")
                        .HasForeignKey("FerieboligId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feriebolig");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Booking", b =>
                {
                    b.Navigation("Leveringsadresse");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Bruger", b =>
                {
                    b.Navigation("Bookinger");
                });

            modelBuilder.Entity("Ferieboliger.DAL.Models.Feriebolig", b =>
                {
                    b.Navigation("Adresse")
                        .IsRequired();

                    b.Navigation("Bookinger");

                    b.Navigation("Filer");

                    b.Navigation("Spaerringer");
                });
#pragma warning restore 612, 618
        }
    }
}
