using ITRR.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace ITRR.Database
{
	public class ITRRDbContext : DbContext
	{
		public ITRRDbContext(DbContextOptions<ITRRDbContext> options) : base(options) { }

		public DbSet<ComputerInfo> ComputerInfo { get; set; }
		public DbSet<CPU> CPU { get; set; }
		public DbSet<GPU> Gpu { get; set; }
		public DbSet<NetworkCard> NetworkCard { get; set; }
		public DbSet<HDD> Hdd { get; set; }
		public DbSet<MotherBoard> MotherBoard { get; set; }
		public DbSet<Programms> Programs { get; set; }
		public DbSet<RAM> Ram { get; set; }
		public DbSet<SSD> Ssd { get; set; }
		public DbSet<USBDevices> UsbDevices { get; set; }
		public DbSet<ComputersToRAM> ComputersToRAM { get; set; }
		public DbSet<ComputersToGPU> ComputersToGPU { get; set; }
		public DbSet<ComputersToSSD> ComputersToSSD { get; set; }
		public DbSet<ComputersToHDD> ComputersToHDD { get; set; }
		public DbSet<ComputersToUSBDevices> ComputersToUSBDevices { get; set; }
		public DbSet<ComputersToProgramms> ComputersToProgramms { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			
		}
	}
}
