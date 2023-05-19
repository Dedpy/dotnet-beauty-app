﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(AMContext))]
    [Migration("20230518082947_FirstMigrationExam")]
    partial class FirstMigrationExam
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApplicationCore.Domain.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Tel")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Prestataire", b =>
                {
                    b.Property<int>("PrestataireId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrestataireId"));

                    b.Property<int>("Note")
                        .HasColumnType("int");

                    b.Property<string>("PageInstagram")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PrestataireNom")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("PrestataireTel")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("PrestataireId");

                    b.ToTable("Prestataires");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Prestation", b =>
                {
                    b.Property<int>("PrestationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrestationId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Intitule")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("PrestataireFK")
                        .HasColumnType("int");

                    b.Property<int>("PrestationType")
                        .HasColumnType("int");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.HasKey("PrestationId");

                    b.HasIndex("PrestataireFK");

                    b.ToTable("Prestations");
                });

            modelBuilder.Entity("ApplicationCore.Domain.RDV", b =>
                {
                    b.Property<int>("ClientFK")
                        .HasColumnType("int");

                    b.Property<int>("PrestationFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRDV")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Confirmation")
                        .HasColumnType("bit");

                    b.HasKey("ClientFK", "PrestationFK", "DateRDV");

                    b.HasIndex("PrestationFK");

                    b.ToTable("RDVs");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Prestation", b =>
                {
                    b.HasOne("ApplicationCore.Domain.Prestataire", "Prestataire")
                        .WithMany("Prestations")
                        .HasForeignKey("PrestataireFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prestataire");
                });

            modelBuilder.Entity("ApplicationCore.Domain.RDV", b =>
                {
                    b.HasOne("ApplicationCore.Domain.Client", "Client")
                        .WithMany("RDVs")
                        .HasForeignKey("ClientFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationCore.Domain.Prestation", "Prestation")
                        .WithMany("RDVs")
                        .HasForeignKey("PrestationFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Prestation");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Client", b =>
                {
                    b.Navigation("RDVs");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Prestataire", b =>
                {
                    b.Navigation("Prestations");
                });

            modelBuilder.Entity("ApplicationCore.Domain.Prestation", b =>
                {
                    b.Navigation("RDVs");
                });
#pragma warning restore 612, 618
        }
    }
}
