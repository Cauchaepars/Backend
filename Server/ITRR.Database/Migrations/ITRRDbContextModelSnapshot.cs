// <auto-generated />
using System;
using ITRR.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ITRR.Database.Migrations
{
    [DbContext(typeof(ITRRDbContext))]
    partial class ITRRDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ITRR.Database.Models.CPU", b =>
                {
                    b.Property<int>("CPUId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Bitness")
                        .HasColumnType("text");

                    b.Property<string>("CacheMemory")
                        .HasColumnType("text");

                    b.Property<int?>("ComputerInfoComputerId")
                        .HasColumnType("integer");

                    b.Property<string>("Frequency")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("NumberOfCores")
                        .HasColumnType("text");

                    b.HasKey("CPUId");

                    b.HasIndex("ComputerInfoComputerId");

                    b.ToTable("CPU");
                });

            modelBuilder.Entity("ITRR.Database.Models.ComputerInfo", b =>
                {
                    b.Property<int>("ComputerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("ComputerName")
                        .HasColumnType("text");

                    b.Property<string>("CreationTime")
                        .HasColumnType("text");

                    b.Property<string>("OSName")
                        .HasColumnType("text");

                    b.Property<string>("OSVersion")
                        .HasColumnType("text");

                    b.Property<string>("SystemFolder")
                        .HasColumnType("text");

                    b.Property<string>("UpdateTime")
                        .HasColumnType("text");

                    b.HasKey("ComputerId");

                    b.ToTable("ComputerInfo");
                });

            modelBuilder.Entity("ITRR.Database.Models.ComputersToGPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ComputerId")
                        .HasColumnType("integer");

                    b.Property<int?>("GPUId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.HasIndex("GPUId");

                    b.ToTable("ComputersToGPU");
                });

            modelBuilder.Entity("ITRR.Database.Models.ComputersToHDD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ComputerId")
                        .HasColumnType("integer");

                    b.Property<int?>("HDDId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.HasIndex("HDDId");

                    b.ToTable("ComputersToHDD");
                });

            modelBuilder.Entity("ITRR.Database.Models.ComputersToProgramms", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ComputerId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProgrammsProgramId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.HasIndex("ProgrammsProgramId");

                    b.ToTable("ComputersToProgramms");
                });

            modelBuilder.Entity("ITRR.Database.Models.ComputersToRAM", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ComputerId")
                        .HasColumnType("integer");

                    b.Property<int?>("RAMId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.HasIndex("RAMId");

                    b.ToTable("ComputersToRAM");
                });

            modelBuilder.Entity("ITRR.Database.Models.ComputersToSSD", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ComputerId")
                        .HasColumnType("integer");

                    b.Property<int?>("SSDId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.HasIndex("SSDId");

                    b.ToTable("ComputersToSSD");
                });

            modelBuilder.Entity("ITRR.Database.Models.ComputersToUSBDevices", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ComputerId")
                        .HasColumnType("integer");

                    b.Property<int?>("USBDevicesId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ComputerId");

                    b.HasIndex("USBDevicesId");

                    b.ToTable("ComputersToUSBDevices");
                });

            modelBuilder.Entity("ITRR.Database.Models.GPU", b =>
                {
                    b.Property<int>("GPUId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Frequency")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("VolumeMemory")
                        .HasColumnType("text");

                    b.HasKey("GPUId");

                    b.ToTable("Gpu");
                });

            modelBuilder.Entity("ITRR.Database.Models.HDD", b =>
                {
                    b.Property<int>("HDDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Amount")
                        .HasColumnType("text");

                    b.Property<string>("MaxSpeedRead")
                        .HasColumnType("text");

                    b.Property<string>("MaxSpeedWrite")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("HDDId");

                    b.ToTable("Hdd");
                });

            modelBuilder.Entity("ITRR.Database.Models.MotherBoard", b =>
                {
                    b.Property<int>("MotherBoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ComputerInfoComputerId")
                        .HasColumnType("integer");

                    b.Property<string>("FSBFrequency")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("RAMConnector")
                        .HasColumnType("text");

                    b.Property<string>("Socket")
                        .HasColumnType("text");

                    b.HasKey("MotherBoardId");

                    b.HasIndex("ComputerInfoComputerId");

                    b.ToTable("MotherBoard");
                });

            modelBuilder.Entity("ITRR.Database.Models.NetworkCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ComputerInfoComputerId")
                        .HasColumnType("integer");

                    b.Property<string>("MACAddress")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Specification")
                        .HasColumnType("text");

                    b.Property<string>("Speed")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ComputerInfoComputerId");

                    b.ToTable("NetworkCard");
                });

            modelBuilder.Entity("ITRR.Database.Models.Programms", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstdownloadDate")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Volume")
                        .HasColumnType("text");

                    b.HasKey("ProgramId");

                    b.ToTable("Programs");
                });

            modelBuilder.Entity("ITRR.Database.Models.RAM", b =>
                {
                    b.Property<int>("RAMId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Frequency")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Volume")
                        .HasColumnType("text");

                    b.HasKey("RAMId");

                    b.ToTable("Ram");
                });

            modelBuilder.Entity("ITRR.Database.Models.SSD", b =>
                {
                    b.Property<int>("SSDId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Amount")
                        .HasColumnType("text");

                    b.Property<string>("MaxSpeedRead")
                        .HasColumnType("text");

                    b.Property<string>("MaxSpeedWrite")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("SSDId");

                    b.ToTable("Ssd");
                });

            modelBuilder.Entity("ITRR.Database.Models.USBDevices", b =>
                {
                    b.Property<int>("USBDevicesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("USBDevicesId");

                    b.ToTable("UsbDevices");
                });

            modelBuilder.Entity("ITRR.Database.Models.CPU", b =>
                {
                    b.HasOne("ITRR.Database.Models.ComputerInfo", "ComputerInfo")
                        .WithMany()
                        .HasForeignKey("ComputerInfoComputerId");

                    b.Navigation("ComputerInfo");
                });

            modelBuilder.Entity("ITRR.Database.Models.ComputersToGPU", b =>
                {
                    b.HasOne("ITRR.Database.Models.ComputerInfo", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId");

                    b.HasOne("ITRR.Database.Models.GPU", "Gpu")
                        .WithMany()
                        .HasForeignKey("GPUId");

                    b.Navigation("Computer");

                    b.Navigation("Gpu");
                });

            modelBuilder.Entity("ITRR.Database.Models.ComputersToHDD", b =>
                {
                    b.HasOne("ITRR.Database.Models.ComputerInfo", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId");

                    b.HasOne("ITRR.Database.Models.HDD", "Hdd")
                        .WithMany()
                        .HasForeignKey("HDDId");

                    b.Navigation("Computer");

                    b.Navigation("Hdd");
                });

            modelBuilder.Entity("ITRR.Database.Models.ComputersToProgramms", b =>
                {
                    b.HasOne("ITRR.Database.Models.ComputerInfo", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId");

                    b.HasOne("ITRR.Database.Models.Programms", "Programms")
                        .WithMany()
                        .HasForeignKey("ProgrammsProgramId");

                    b.Navigation("Computer");

                    b.Navigation("Programms");
                });

            modelBuilder.Entity("ITRR.Database.Models.ComputersToRAM", b =>
                {
                    b.HasOne("ITRR.Database.Models.ComputerInfo", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId");

                    b.HasOne("ITRR.Database.Models.RAM", "Ram")
                        .WithMany()
                        .HasForeignKey("RAMId");

                    b.Navigation("Computer");

                    b.Navigation("Ram");
                });

            modelBuilder.Entity("ITRR.Database.Models.ComputersToSSD", b =>
                {
                    b.HasOne("ITRR.Database.Models.ComputerInfo", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId");

                    b.HasOne("ITRR.Database.Models.SSD", "Ssd")
                        .WithMany()
                        .HasForeignKey("SSDId");

                    b.Navigation("Computer");

                    b.Navigation("Ssd");
                });

            modelBuilder.Entity("ITRR.Database.Models.ComputersToUSBDevices", b =>
                {
                    b.HasOne("ITRR.Database.Models.ComputerInfo", "Computer")
                        .WithMany()
                        .HasForeignKey("ComputerId");

                    b.HasOne("ITRR.Database.Models.USBDevices", "USBDevices")
                        .WithMany()
                        .HasForeignKey("USBDevicesId");

                    b.Navigation("Computer");

                    b.Navigation("USBDevices");
                });

            modelBuilder.Entity("ITRR.Database.Models.MotherBoard", b =>
                {
                    b.HasOne("ITRR.Database.Models.ComputerInfo", "ComputerInfo")
                        .WithMany()
                        .HasForeignKey("ComputerInfoComputerId");

                    b.Navigation("ComputerInfo");
                });

            modelBuilder.Entity("ITRR.Database.Models.NetworkCard", b =>
                {
                    b.HasOne("ITRR.Database.Models.ComputerInfo", "ComputerInfo")
                        .WithMany()
                        .HasForeignKey("ComputerInfoComputerId");

                    b.Navigation("ComputerInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
