// <auto-generated />
using System;
using DatabaseImplement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatabaseImplement.Migrations
{
    [DbContext(typeof(StoDatabase))]
    partial class StoDatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DatabaseImplement.Models.Client", b =>
                {
                    b.Property<int?>("Id")
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

                    b.Property<string>("Password")
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
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeMiddlename")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeePhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("EmployeePrize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("EmployeeSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfPayment")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Remains")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RepairId")
                        .HasColumnType("int");

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("RepairId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Repair", b =>
                {
                    b.Property<int?>("Id")
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

                    b.Property<decimal>("Sum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WorkId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("DatabaseImplement.Models.RepairWork", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RepairId")
                        .HasColumnType("int");

                    b.Property<int>("WorkId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkId1")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkId");

                    b.HasIndex("WorkId1");

                    b.ToTable("RepairWorks");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EmployeesId")
                        .HasColumnType("int");

                    b.Property<int?>("StaffId")
                        .HasColumnType("int");

                    b.Property<string>("StaffName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("StaffPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeesId");

                    b.HasIndex("StaffId");

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

                    b.Property<decimal>("WorkPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Works");
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

                    b.Navigation("Client");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("DatabaseImplement.Models.RepairWork", b =>
                {
                    b.HasOne("DatabaseImplement.Models.Repair", "Repair")
                        .WithMany("RepairWorks")
                        .HasForeignKey("WorkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseImplement.Models.Work", "Work")
                        .WithMany("RepairWorks")
                        .HasForeignKey("WorkId1");

                    b.Navigation("Repair");

                    b.Navigation("Work");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Staff", b =>
                {
                    b.HasOne("DatabaseImplement.Models.Staff", "Employees")
                        .WithMany()
                        .HasForeignKey("EmployeesId");

                    b.HasOne("DatabaseImplement.Models.Employee", null)
                        .WithMany("Staffs")
                        .HasForeignKey("StaffId");

                    b.Navigation("Employees");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Client", b =>
                {
                    b.Navigation("Repairs");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Employee", b =>
                {
                    b.Navigation("Repairs");

                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Repair", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("RepairWorks");
                });

            modelBuilder.Entity("DatabaseImplement.Models.Work", b =>
                {
                    b.Navigation("RepairWorks");
                });
#pragma warning restore 612, 618
        }
    }
}
