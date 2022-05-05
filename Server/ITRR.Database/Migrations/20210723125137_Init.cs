using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ITRR.Database.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComputerInfo",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OSVersion = table.Column<string>(type: "text", nullable: true),
                    ComputerName = table.Column<string>(type: "text", nullable: true),
                    SystemFolder = table.Column<string>(type: "text", nullable: true),
                    CreationTime = table.Column<string>(type: "text", nullable: true),
                    UpdateTime = table.Column<string>(type: "text", nullable: true),
                    OSName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerInfo", x => x.ComputerId);
                });

            migrationBuilder.CreateTable(
                name: "Gpu",
                columns: table => new
                {
                    GPUId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Frequency = table.Column<string>(type: "text", nullable: true),
                    VolumeMemory = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gpu", x => x.GPUId);
                });

            migrationBuilder.CreateTable(
                name: "Hdd",
                columns: table => new
                {
                    HDDId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<string>(type: "text", nullable: true),
                    MaxSpeedWrite = table.Column<string>(type: "text", nullable: true),
                    MaxSpeedRead = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hdd", x => x.HDDId);
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    ProgramId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    FirstdownloadDate = table.Column<string>(type: "text", nullable: true),
                    Volume = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.ProgramId);
                });

            migrationBuilder.CreateTable(
                name: "Ram",
                columns: table => new
                {
                    RAMId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Frequency = table.Column<string>(type: "text", nullable: true),
                    Volume = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ram", x => x.RAMId);
                });

            migrationBuilder.CreateTable(
                name: "Ssd",
                columns: table => new
                {
                    SSDId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<string>(type: "text", nullable: true),
                    MaxSpeedWrite = table.Column<string>(type: "text", nullable: true),
                    MaxSpeedRead = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ssd", x => x.SSDId);
                });

            migrationBuilder.CreateTable(
                name: "UsbDevices",
                columns: table => new
                {
                    USBDevicesId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsbDevices", x => x.USBDevicesId);
                });

            migrationBuilder.CreateTable(
                name: "CPU",
                columns: table => new
                {
                    CPUId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Frequency = table.Column<string>(type: "text", nullable: true),
                    Bitness = table.Column<string>(type: "text", nullable: true),
                    CacheMemory = table.Column<string>(type: "text", nullable: true),
                    NumberOfCores = table.Column<string>(type: "text", nullable: true),
                    ComputerInfoComputerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPU", x => x.CPUId);
                    table.ForeignKey(
                        name: "FK_CPU_ComputerInfo_ComputerInfoComputerId",
                        column: x => x.ComputerInfoComputerId,
                        principalTable: "ComputerInfo",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MotherBoard",
                columns: table => new
                {
                    MotherBoardId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Socket = table.Column<string>(type: "text", nullable: true),
                    FSBFrequency = table.Column<string>(type: "text", nullable: true),
                    RAMConnector = table.Column<string>(type: "text", nullable: true),
                    ComputerInfoComputerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherBoard", x => x.MotherBoardId);
                    table.ForeignKey(
                        name: "FK_MotherBoard_ComputerInfo_ComputerInfoComputerId",
                        column: x => x.ComputerInfoComputerId,
                        principalTable: "ComputerInfo",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NetworkCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MACAddress = table.Column<string>(type: "text", nullable: true),
                    Speed = table.Column<string>(type: "text", nullable: true),
                    Specification = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ComputerInfoComputerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NetworkCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NetworkCard_ComputerInfo_ComputerInfoComputerId",
                        column: x => x.ComputerInfoComputerId,
                        principalTable: "ComputerInfo",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComputersToGPU",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GPUId = table.Column<int>(type: "integer", nullable: true),
                    ComputerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputersToGPU", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputersToGPU_ComputerInfo_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "ComputerInfo",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComputersToGPU_Gpu_GPUId",
                        column: x => x.GPUId,
                        principalTable: "Gpu",
                        principalColumn: "GPUId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComputersToHDD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HDDId = table.Column<int>(type: "integer", nullable: true),
                    ComputerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputersToHDD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputersToHDD_ComputerInfo_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "ComputerInfo",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComputersToHDD_Hdd_HDDId",
                        column: x => x.HDDId,
                        principalTable: "Hdd",
                        principalColumn: "HDDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComputersToProgramms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProgrammsProgramId = table.Column<int>(type: "integer", nullable: true),
                    ComputerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputersToProgramms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputersToProgramms_ComputerInfo_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "ComputerInfo",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComputersToProgramms_Programs_ProgrammsProgramId",
                        column: x => x.ProgrammsProgramId,
                        principalTable: "Programs",
                        principalColumn: "ProgramId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComputersToRAM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RAMId = table.Column<int>(type: "integer", nullable: true),
                    ComputerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputersToRAM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputersToRAM_ComputerInfo_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "ComputerInfo",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComputersToRAM_Ram_RAMId",
                        column: x => x.RAMId,
                        principalTable: "Ram",
                        principalColumn: "RAMId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComputersToSSD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SSDId = table.Column<int>(type: "integer", nullable: true),
                    ComputerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputersToSSD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputersToSSD_ComputerInfo_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "ComputerInfo",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComputersToSSD_Ssd_SSDId",
                        column: x => x.SSDId,
                        principalTable: "Ssd",
                        principalColumn: "SSDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComputersToUSBDevices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    USBDevicesId = table.Column<int>(type: "integer", nullable: true),
                    ComputerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputersToUSBDevices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputersToUSBDevices_ComputerInfo_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "ComputerInfo",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComputersToUSBDevices_UsbDevices_USBDevicesId",
                        column: x => x.USBDevicesId,
                        principalTable: "UsbDevices",
                        principalColumn: "USBDevicesId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToGPU_ComputerId",
                table: "ComputersToGPU",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToGPU_GPUId",
                table: "ComputersToGPU",
                column: "GPUId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToHDD_ComputerId",
                table: "ComputersToHDD",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToHDD_HDDId",
                table: "ComputersToHDD",
                column: "HDDId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToProgramms_ComputerId",
                table: "ComputersToProgramms",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToProgramms_ProgrammsProgramId",
                table: "ComputersToProgramms",
                column: "ProgrammsProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToRAM_ComputerId",
                table: "ComputersToRAM",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToRAM_RAMId",
                table: "ComputersToRAM",
                column: "RAMId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToSSD_ComputerId",
                table: "ComputersToSSD",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToSSD_SSDId",
                table: "ComputersToSSD",
                column: "SSDId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToUSBDevices_ComputerId",
                table: "ComputersToUSBDevices",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToUSBDevices_USBDevicesId",
                table: "ComputersToUSBDevices",
                column: "USBDevicesId");

            migrationBuilder.CreateIndex(
                name: "IX_CPU_ComputerInfoComputerId",
                table: "CPU",
                column: "ComputerInfoComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_MotherBoard_ComputerInfoComputerId",
                table: "MotherBoard",
                column: "ComputerInfoComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_NetworkCard_ComputerInfoComputerId",
                table: "NetworkCard",
                column: "ComputerInfoComputerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputersToGPU");

            migrationBuilder.DropTable(
                name: "ComputersToHDD");

            migrationBuilder.DropTable(
                name: "ComputersToProgramms");

            migrationBuilder.DropTable(
                name: "ComputersToRAM");

            migrationBuilder.DropTable(
                name: "ComputersToSSD");

            migrationBuilder.DropTable(
                name: "ComputersToUSBDevices");

            migrationBuilder.DropTable(
                name: "CPU");

            migrationBuilder.DropTable(
                name: "MotherBoard");

            migrationBuilder.DropTable(
                name: "NetworkCard");

            migrationBuilder.DropTable(
                name: "Gpu");

            migrationBuilder.DropTable(
                name: "Hdd");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Ram");

            migrationBuilder.DropTable(
                name: "Ssd");

            migrationBuilder.DropTable(
                name: "UsbDevices");

            migrationBuilder.DropTable(
                name: "ComputerInfo");
        }
    }
}
