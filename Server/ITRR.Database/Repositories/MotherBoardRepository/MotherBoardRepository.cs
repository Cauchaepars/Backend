using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ITRR.Database.Repositories.MotherBoardRepository
{
	public class MotherBoardRepository : BaseRepository, IMotherBoardRepository
	{
		public MotherBoardRepository(ITRRDbContext context) : base(context) { }

		public async Task<int> CreateMotherBoardAsync(MotherBoardDto MotherBoard, int ComputerInfoId)
		{
			try
			{
				var computerInfo = await _context.ComputerInfo
				.FirstOrDefaultAsync(c => c.ComputerId == ComputerInfoId);

				var motherBoard = new MotherBoard()
				{
					Socket = MotherBoard.Socket,
					FSBFrequency = MotherBoard.FSBFrequency,
					RAMConnector = MotherBoard.RAMConnector,
					Name = MotherBoard.Name,
					ComputerInfo = computerInfo
				};

				await _context.MotherBoard.AddAsync(motherBoard);
				await _context.SaveChangesAsync();

				return motherBoard.MotherBoardId;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<MotherBoard> GetMotherBoardAsync(int MotherBoardId)
		{
			try
			{
				var motherBoard = await _context.MotherBoard
				.FirstOrDefaultAsync(c => c.MotherBoardId == MotherBoardId);

				if (motherBoard == null)
					throw new Exception($"No motherboard with such id: {MotherBoardId}");

				return motherBoard;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task UpdateMotherBoardAsync(int MotherBoardId, MotherBoardDto motherBoard)
		{
			try
			{
				var motherboard = await _context.MotherBoard.FirstOrDefaultAsync(c => c.MotherBoardId == MotherBoardId);

				if (motherboard == null)
					throw new Exception($"No motherboard with such id = {MotherBoardId}.");

				if(motherboard.Socket != motherBoard.Socket)
					motherboard.Socket = motherBoard.Socket;


				if (motherboard.FSBFrequency != motherBoard.FSBFrequency)
					motherboard.FSBFrequency = motherBoard.FSBFrequency;

				if (motherboard.RAMConnector != motherBoard.RAMConnector)
					motherboard.RAMConnector = motherBoard.RAMConnector;

				_context.MotherBoard.Update(motherboard);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task DeleteMotherBoardAsync(int MotherBoardId)
		{
			try
			{
				var motherboard = await _context.MotherBoard.FirstOrDefaultAsync(c => c.MotherBoardId == MotherBoardId);

				if (motherboard == null)
					throw new Exception($"No motherboard with such id = {MotherBoardId}.");

				_context.MotherBoard.Remove(motherboard);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception($"Error");
			}
		}
	}
}
