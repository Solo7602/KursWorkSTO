﻿// <auto-generated />
using System;
using DatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseImplement.Migrations
{
    [DbContext(typeof(StoDatabase))]
    [Migration("20220402220446_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatabaseImplement.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Middlename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeMiddlename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeNSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePrize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StaffId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Remains")
                        .HasColumnType("int");

                    b.Property<int>("RepairId")
                        .HasColumnType("int");

                    b.Property<int>("Sum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RepairId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Repair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Sum")
                        .HasColumnType("int");

                    b.Property<int?>("WorkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("WorkId");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StaffPrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Work", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("WorkName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WorkPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Works");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Employee", b =>
                {
                    b.HasOne("DatabaseImplement.Models.Staff", "Staffs")
                        .WithMany("Employee")
                        .HasForeignKey("StaffId");

                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Payment", b =>
                {
                    b.HasOne("DatabaseImplement.Models.Repair", "Repair")
                        .WithMany("Payments")
                        .HasForeignKey("RepairId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Repair");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Repair", b =>
                {
                    b.HasOne("DatabaseImplement.Models.Client", "Client")
                        .WithMany("Repairs")
                        .HasForeignKey("ClientId");

                    b.HasOne("DatabaseImplement.Models.Employee", "Employee")
                        .WithMany("Repairs")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("DatabaseImplement.Models.Work", "Work")
                        .WithMany("Repairs")
                        .HasForeignKey("WorkId");

                    b.Navigation("Client");

                    b.Navigation("Employee");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Client", b =>
                {
                    b.Navigation("Repairs");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Employee", b =>
                {
                    b.Navigation("Repairs");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Repair", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Staff", b =>
                {
                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Work", b =>
                {
                    b.Navigation("Repairs");
                });
#pragma warning restore 612, 618
        }
    }
}
