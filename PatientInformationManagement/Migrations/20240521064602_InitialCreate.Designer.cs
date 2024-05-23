﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PatientInformationManagement.Data;

#nullable disable

namespace PatientInformationManagement.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240521064602_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PatientInformationManagement.Models.Allergies", b =>
                {
                    b.Property<int>("AllergiesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AllergiesID"));

                    b.Property<string>("AllergyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AllergiesID");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("PatientInformationManagement.Models.Allergies_Details", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("AllergiesID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AllergiesID");

                    b.HasIndex("PatientID");

                    b.ToTable("Allergies_Details");
                });

            modelBuilder.Entity("PatientInformationManagement.Models.DiseaseInfo", b =>
                {
                    b.Property<int>("DiseaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiseaseID"));

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiseaseID");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("PatientInformationManagement.Models.NCD", b =>
                {
                    b.Property<int>("NCDID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NCDID"));

                    b.Property<string>("NCDName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NCDID");

                    b.ToTable("NCDs");
                });

            modelBuilder.Entity("PatientInformationManagement.Models.NCD_Details", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("NCDID")
                        .HasColumnType("int");

                    b.Property<int>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("NCDID");

                    b.HasIndex("PatientID");

                    b.ToTable("NCD_Details");
                });

            modelBuilder.Entity("PatientInformationManagement.Models.PatientInfo", b =>
                {
                    b.Property<int>("PatientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientID");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("PatientInformationManagement.Models.Allergies_Details", b =>
                {
                    b.HasOne("PatientInformationManagement.Models.Allergies", "Allergies")
                        .WithMany("Allergies_Details")
                        .HasForeignKey("AllergiesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PatientInformationManagement.Models.PatientInfo", "Patient")
                        .WithMany("Allergies_Details")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergies");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PatientInformationManagement.Models.NCD_Details", b =>
                {
                    b.HasOne("PatientInformationManagement.Models.NCD", "NCD")
                        .WithMany("NCD_Details")
                        .HasForeignKey("NCDID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PatientInformationManagement.Models.PatientInfo", "Patient")
                        .WithMany("NCD_Details")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NCD");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("PatientInformationManagement.Models.Allergies", b =>
                {
                    b.Navigation("Allergies_Details");
                });

            modelBuilder.Entity("PatientInformationManagement.Models.NCD", b =>
                {
                    b.Navigation("NCD_Details");
                });

            modelBuilder.Entity("PatientInformationManagement.Models.PatientInfo", b =>
                {
                    b.Navigation("Allergies_Details");

                    b.Navigation("NCD_Details");
                });
#pragma warning restore 612, 618
        }
    }
}
