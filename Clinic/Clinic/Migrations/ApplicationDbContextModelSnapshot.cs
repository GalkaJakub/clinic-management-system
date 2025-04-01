﻿// <auto-generated />
using System;
using Clinic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clinic.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Clinic.Models.Address", b =>
                {
                    b.Property<int>("AdressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdressId"));

                    b.Property<int>("ApartNumber")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HomeNumber")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdressId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Clinic.Models.Appointment", b =>
                {
                    b.Property<int>("AppointemntId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointemntId"));

                    b.Property<DateTime?>("AppointmentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<int>("ReceptionistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("AppointemntId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.HasIndex("ReceptionistId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("Clinic.Models.ExamSelection", b =>
                {
                    b.Property<int>("ExamSelectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ExamSelectionId"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("ExamSelectionId");

                    b.ToTable("ExamSelections");
                });

            modelBuilder.Entity("Clinic.Models.LabExam", b =>
                {
                    b.Property<int>("LabExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LabExamId"));

                    b.Property<DateTime?>("AcceptDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<string>("DoctorsNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ExamDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExamSelectionId")
                        .HasColumnType("int");

                    b.Property<string>("HeadLabNotes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HeadLabTechnicianId")
                        .HasColumnType("int");

                    b.Property<int>("LabTechnicianId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Result")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("LabExamId");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ExamSelectionId");

                    b.HasIndex("HeadLabTechnicianId");

                    b.HasIndex("LabTechnicianId");

                    b.ToTable("LabExams");
                });

            modelBuilder.Entity("Clinic.Models.Patient", b =>
                {
                    b.Property<int>("PatientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PatientId"));

                    b.Property<int>("AdressId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PatientId");

                    b.HasIndex("AdressId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Clinic.Models.PhysicalExam", b =>
                {
                    b.Property<int>("PhisicalExamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhisicalExamId"));

                    b.Property<int>("AppointmentId")
                        .HasColumnType("int");

                    b.Property<int>("ExamSelectionId")
                        .HasColumnType("int");

                    b.Property<string>("Result")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhisicalExamId");

                    b.HasIndex("AppointmentId");

                    b.HasIndex("ExamSelectionId");

                    b.ToTable("PhysicalExams");
                });

            modelBuilder.Entity("Clinic.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("nvarchar(21)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserType")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Clinic.Models.Admin", b =>
                {
                    b.HasBaseType("Clinic.Models.User");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            UserId = 5,
                            Name = "Michał",
                            PasswordHash = "user5",
                            Surname = "Sikora",
                            UserType = 1
                        });
                });

            modelBuilder.Entity("Clinic.Models.Doctor", b =>
                {
                    b.HasBaseType("Clinic.Models.User");

                    b.Property<int>("NPWZ")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Doctor");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Name = "Jakub",
                            PasswordHash = "user1",
                            Surname = "Gałka",
                            UserType = 0,
                            NPWZ = 32
                        });
                });

            modelBuilder.Entity("Clinic.Models.HeadLabTechnician", b =>
                {
                    b.HasBaseType("Clinic.Models.User");

                    b.HasDiscriminator().HasValue("HeadLabTechnician");

                    b.HasData(
                        new
                        {
                            UserId = 3,
                            Name = "Jakub",
                            PasswordHash = "user3",
                            Surname = "Gnela",
                            UserType = 3
                        });
                });

            modelBuilder.Entity("Clinic.Models.LabTechnician", b =>
                {
                    b.HasBaseType("Clinic.Models.User");

                    b.HasDiscriminator().HasValue("LabTechnician");

                    b.HasData(
                        new
                        {
                            UserId = 4,
                            Name = "Kacper",
                            PasswordHash = "user4",
                            Surname = "Czerniak",
                            UserType = 2
                        });
                });

            modelBuilder.Entity("Clinic.Models.Receptionist", b =>
                {
                    b.HasBaseType("Clinic.Models.User");

                    b.HasDiscriminator().HasValue("Receptionist");

                    b.HasData(
                        new
                        {
                            UserId = 2,
                            Name = "Wiktor",
                            PasswordHash = "user2",
                            Surname = "Gruszka",
                            UserType = 4
                        });
                });

            modelBuilder.Entity("Clinic.Models.Appointment", b =>
                {
                    b.HasOne("Clinic.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinic.Models.Patient", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinic.Models.Receptionist", "Receptionist")
                        .WithMany()
                        .HasForeignKey("ReceptionistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");

                    b.Navigation("Receptionist");
                });

            modelBuilder.Entity("Clinic.Models.LabExam", b =>
                {
                    b.HasOne("Clinic.Models.Appointment", "Appointment")
                        .WithMany("LabExams")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinic.Models.ExamSelection", "ExamSelection")
                        .WithMany()
                        .HasForeignKey("ExamSelectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinic.Models.HeadLabTechnician", "HeadLabTechnician")
                        .WithMany()
                        .HasForeignKey("HeadLabTechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinic.Models.LabTechnician", "LabTechnician")
                        .WithMany()
                        .HasForeignKey("LabTechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("ExamSelection");

                    b.Navigation("HeadLabTechnician");

                    b.Navigation("LabTechnician");
                });

            modelBuilder.Entity("Clinic.Models.Patient", b =>
                {
                    b.HasOne("Clinic.Models.Address", "Adress")
                        .WithMany()
                        .HasForeignKey("AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("Clinic.Models.PhysicalExam", b =>
                {
                    b.HasOne("Clinic.Models.Appointment", "Appointment")
                        .WithMany("PhysicalExams")
                        .HasForeignKey("AppointmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Clinic.Models.ExamSelection", "ExamSelection")
                        .WithMany()
                        .HasForeignKey("ExamSelectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Appointment");

                    b.Navigation("ExamSelection");
                });

            modelBuilder.Entity("Clinic.Models.Appointment", b =>
                {
                    b.Navigation("LabExams");

                    b.Navigation("PhysicalExams");
                });
#pragma warning restore 612, 618
        }
    }
}
