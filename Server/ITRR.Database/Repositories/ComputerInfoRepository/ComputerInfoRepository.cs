using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using ITRR.Services;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITRR.Database.Repositories.ComputerInfoRepository
{
	public class ComputerInfoRepository : BaseRepository, IComputerInfoRepository
	{
		public ComputerInfoRepository(ITRRDbContext context) : base(context) { }
		

		public async Task<int> CreateComputerInfoAsync(ComputerInfoDto ComputerInfo)
		{
			try
			{
				var computerInfo = new ComputerInfo()
				{
					OSVersion = ComputerInfo.OSVersion,
					ComputerName = ComputerInfo.ComputerName,
					SystemFolder = ComputerInfo.SystemFolder,
					CreationTime = ComputerInfo.CreationTime,
					UpdateTime = ComputerInfo.UpdateTime,
					OSName = ComputerInfo.OSName
				};

				await _context.ComputerInfo.AddAsync(computerInfo);
				await _context.SaveChangesAsync();

				return computerInfo.ComputerId;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}


		public async Task<ComputerInfo> GetComputerInfoAsync(int computerInfoId)
		{
			try
			{
				var computerInfo = await _context.ComputerInfo
				.FirstOrDefaultAsync(c => c.ComputerId == computerInfoId);

				if (computerInfo == null)
					throw new Exception($"No computer with such id: {computerInfoId}");

				return computerInfo;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<List<ComputerInfo>> GetAllComputerAsync()
		{
			try
			{
				var collectionComputer = await _context.ComputerInfo
				.ToListAsync();

				if (collectionComputer.Count == 0)
					throw new Exception($"No computer");

				return collectionComputer;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task UpdateComputerInfoAsync(int computerInfoId, ComputerInfoDto ComputerInfo)
		{
			try
			{
				var computer = await _context.ComputerInfo.FirstOrDefaultAsync(c => c.ComputerId == computerInfoId);

				if (computer == null)
					throw new Exception($"No computer with such id = {computerInfoId}.");


				if (computer.OSVersion != ComputerInfo.OSVersion)
					computer.OSVersion = ComputerInfo.OSVersion;

				if (computer.ComputerName != ComputerInfo.ComputerName)
					computer.ComputerName = ComputerInfo.ComputerName;

				if (computer.SystemFolder != ComputerInfo.SystemFolder)
					computer.SystemFolder = ComputerInfo.SystemFolder;

				if (computer.CreationTime != ComputerInfo.CreationTime)
					computer.CreationTime = ComputerInfo.CreationTime;

				if (computer.UpdateTime != ComputerInfo.UpdateTime)
					computer.UpdateTime = ComputerInfo.UpdateTime;

				if (computer.OSName != ComputerInfo.OSName)
					computer.OSName = ComputerInfo.OSName;

				 _context.ComputerInfo.Update(computer);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task DeleteComputerInfoAsync(int computerInfoId)
		{
			try
			{
				var computer = await _context.ComputerInfo.FirstOrDefaultAsync(c => c.ComputerId == computerInfoId);

				if (computer == null)
					throw new Exception($"No computer with such id = {computerInfoId}.");

				_context.ComputerInfo.Remove(computer);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<List<GPU>> GetGPUs(int computerInfoId)
		{
			try
			{
				var computerToGpu = await _context.ComputersToGPU
				.Include(q => q.Gpu)
				.Where(c => c.Computer.ComputerId == computerInfoId)
				.ToListAsync();

				List<GPU> gpus = new List<GPU>();

				foreach (var gpu in computerToGpu)
				{
					gpus.Add(gpu.Gpu);
				}

				return gpus;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<List<HDD>> GetHDDs(int computerInfoId)
		{
			try
			{
				var computerToHdd = await _context.ComputersToHDD
				.Include(q => q.Hdd)
				.Where(c => c.Computer.ComputerId == computerInfoId)
				.ToListAsync();

				List<HDD> hdds = new List<HDD>();

				foreach (var hdd in computerToHdd)
				{
					hdds.Add(hdd.Hdd);
				}

				return hdds;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<List<SSD>> GetSSDs(int computerInfoId)
		{
			try
			{
				var computerToSsd = await _context.ComputersToSSD
				.Include(q => q.Ssd)
				.Where(c => c.Computer.ComputerId == computerInfoId)
				.ToListAsync();

				List<SSD> ssds = new List<SSD>();

				foreach (var ssd in computerToSsd)
				{
					ssds.Add(ssd.Ssd);
				}

				return ssds;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<List<Programms>> GetProgramms(int computerInfoId)
		{
			try
			{
				var computerToProgramms = await _context.ComputersToProgramms
				.Include(q => q.Programms)
				.Where(c => c.Computer.ComputerId == computerInfoId)
				.ToListAsync();

				List<Programms> programms = new List<Programms>();

				foreach (var program in computerToProgramms)
				{
					programms.Add(program.Programms);
				}

				return programms;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<List<USBDevices>> GetUSBs(int computerInfoId)
		{
			try
			{
				var computerToUsb = await _context.ComputersToUSBDevices
				.Include(q => q.USBDevices)
				.Where(c => c.Computer.ComputerId == computerInfoId)
				.ToListAsync();

				List<USBDevices> usbDevices = new List<USBDevices>();

				foreach (var usb in computerToUsb)
				{
					usbDevices.Add(usb.USBDevices);
				}

				return usbDevices;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<List<RAM>> GetRAMs(int computerInfoId)
		{
			try
			{
				var computerToRam = await _context.ComputersToRAM
				.Include(q => q.Ram)
				.Where(c => c.Computer.ComputerId == computerInfoId)
				.ToListAsync();

				List<RAM> rams = new List<RAM>();

				foreach (var gpu in computerToRam)
				{
					rams.Add(gpu.Ram);
				}

				return rams;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		//public async Task CreateInfoFileforAgent(string result)
		//{
		//	try
		//	{
		//		var computerInfo = JsonConvert.DeserializeObject<ComputerInfoDto>(result);
		//		var ram = JsonConvert.DeserializeObject<RAMDto>(result);
		//		var ssd = JsonConvert.DeserializeObject<SSDDto>(result);
		//		var hdd = JsonConvert.DeserializeObject<HDDDto>(result);
		//		var usb = JsonConvert.DeserializeObject<USBDevicesDto>(result);
		//		var networkCard = JsonConvert.DeserializeObject<NetworkCardDto>(result);
		//		var gpu = JsonConvert.DeserializeObject<GPUDto>(result);
		//		var cpu = JsonConvert.DeserializeObject<CPUDto>(result);
		//		var programms = JsonConvert.DeserializeObject<ProgrammsDto>(result);
		//		var motherBoard = JsonConvert.DeserializeObject<MotherBoardDto>(result);



		//		int id = await CreateComputerInfoAsync(computerInfo);


		//		MainService main = new MainService();
		//		main.writeTofile(result, id);
		//	}
		//	catch
		//	{
		//		throw new Exception($"Error");
		//	}
		//}

		//public async Task UpdateInfoFileforAgent(string result)
		//{
		//	try
		//	{
		//		UpdateService update = new UpdateService();

		//		var newInfo = JsonConvert.DeserializeObject<ComputerInfoDto>(result);

		//		var checkInfo = await _context.ComputerInfo
		//			.FirstOrDefaultAsync(c => c.ComputerId == newInfo.ComputerId);


		//		if(newInfo.ComputerName != checkInfo.ComputerName)
		//		update.writeTofile($"ComputerName: {newInfo.ComputerName}", newInfo.ComputerId);

		//		update = new UpdateService();
		//		if (newInfo.CreationTime != checkInfo.CreationTime)
		//			update.writeTofile($"CreationTime: {newInfo.CreationTime}", newInfo.ComputerId);

		//		update = new UpdateService();
		//		if (newInfo.OSName != checkInfo.OSName)
		//			update.writeTofile($"OSName: {newInfo.OSName}", newInfo.ComputerId);

		//		update = new UpdateService();
		//		if (newInfo.OSVersion != checkInfo.OSVersion)
		//			update.writeTofile($"OSVersion: {newInfo.OSVersion}", newInfo.ComputerId);

		//		update = new UpdateService();
		//		if (newInfo.SystemFolder != checkInfo.SystemFolder)
		//			update.writeTofile($"SystemFolder: {newInfo.SystemFolder}", newInfo.ComputerId);

		//		update = new UpdateService();
		//		if (newInfo.UpdateTime != checkInfo.UpdateTime)
		//			update.writeTofile($"UpdateTime: {newInfo.UpdateTime}", newInfo.ComputerId);


		//		await UpdateComputerInfoAsync(newInfo.ComputerId, newInfo);
		//	}
		//	catch
		//	{
		//		throw new Exception($"Error");
		//	}
		//}

		public async Task<CPU> GetCPU(int computerInfoId)
		{
			try
			{
				var cpu = await _context.CPU
					.FirstOrDefaultAsync(c => c.ComputerInfo.ComputerId == computerInfoId);
					
				return cpu;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<MotherBoard> GetMotherBoard(int computerInfoId)
		{
			var motherBoard = await _context.MotherBoard
					.FirstOrDefaultAsync(c => c.ComputerInfo.ComputerId == computerInfoId);

			return motherBoard;
		}
	}
}
