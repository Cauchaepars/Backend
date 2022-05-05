using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ITRR.Database.Repositories.HDDRepository
{
	public class HDDRepository : BaseRepository, IHDDRepository
	{
		public HDDRepository(ITRRDbContext context) : base(context) { }

		public async Task<int> CreateHDDAsync(HDDDto Hdd)
		{
			try
			{
				var hdd = new HDD()
				{
					Amount = Hdd.Amount,
					MaxSpeedWrite = Hdd.MaxSpeedWrite,
					MaxSpeedRead = Hdd.MaxSpeedRead,
					Name = Hdd.Name
				};

				await _context.Hdd.AddAsync(hdd);
				await _context.SaveChangesAsync();

				return hdd.HDDId;
			}
			catch
			{
				throw new Exception($"Error");
			}

		}

		public async Task<HDD> GetHDDAsync(int HDDId)
		{
			try
			{
				var Hdd = await _context.Hdd
				.FirstOrDefaultAsync(c => c.HDDId == HDDId);

				if (Hdd == null)
					throw new Exception($"No HDD with such id: {HDDId}");

				return Hdd;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task UpdateHDDAsync(int HDDId, HDDDto Hdd)
		{
			try
			{
				var hdd = await _context.Hdd.FirstOrDefaultAsync(c => c.HDDId == HDDId);

				if (hdd == null)
					throw new Exception($"No HDD with such id = {HDDId}.");

				if (hdd.Amount != Hdd.Amount)
					hdd.Amount = Hdd.Amount;

				if (hdd.MaxSpeedWrite != Hdd.MaxSpeedWrite)
					hdd.MaxSpeedWrite = Hdd.MaxSpeedWrite;

				if (hdd.MaxSpeedRead != Hdd.MaxSpeedRead)
					hdd.MaxSpeedRead = Hdd.MaxSpeedRead;

				_context.Hdd.Update(hdd);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task DeleteHDDAsync(int HDDId)
		{
			try
			{
				var hdd = await _context.Hdd.FirstOrDefaultAsync(c => c.HDDId == HDDId);

				if (hdd == null)
					throw new Exception($"No GPU with such id = {HDDId}.");

				_context.Hdd.Remove(hdd);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<int> ComputersToHdd(int HDDId, int ComputerInfoId)
		{
			var computerInfo = await _context.ComputerInfo
				.FirstOrDefaultAsync(c => c.ComputerId == ComputerInfoId);

			var hdd = await _context.Hdd
				.FirstOrDefaultAsync(c => c.HDDId == HDDId);

			var ComputerToHdd = new ComputersToHDD()
			{
				Hdd = hdd,
				Computer = computerInfo
			};

			await _context.ComputersToHDD.AddAsync(ComputerToHdd);
			await _context.SaveChangesAsync();

			return ComputerToHdd.Id;
		}
	}
}
