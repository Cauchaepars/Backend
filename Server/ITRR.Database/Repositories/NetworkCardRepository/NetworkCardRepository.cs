using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ITRR.Database.Repositories.NetworkCardRepository
{
	public class NetworkCardRepository : BaseRepository, INetworkCardRepository
	{
		public NetworkCardRepository(ITRRDbContext context) : base(context) { }

		public async Task<int> CreateNetworkCardAsync(NetworkCardDto NetworkCard, int ComputerInfoId)
		{
			try
			{
				var ComputerInfo = await _context.ComputerInfo
				.FirstOrDefaultAsync(c => c.ComputerId == ComputerInfoId);

				var networkCard = new NetworkCard()
				{
					MACAddress = NetworkCard.MACAddress,
					Speed = NetworkCard.Speed,
					Specification = NetworkCard.Specification,
					ComputerInfo = ComputerInfo,
					Name = NetworkCard.Name
				};

				await _context.NetworkCard.AddAsync(networkCard);
				await _context.SaveChangesAsync();

				return networkCard.Id;
			}

			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task DeleteNetworkCardAsync(int NetworkCardId)
		{
			try
			{
				var networkCard = await _context.NetworkCard
				.FirstOrDefaultAsync(c => c.Id == NetworkCardId);

				if (networkCard == null)
					throw new Exception($"No Network card with such id = {NetworkCardId}.");

				_context.NetworkCard.Remove(networkCard);
				await _context.SaveChangesAsync();
			}

			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<NetworkCard> GetNetworkCardAsync(int NetworkCardId)
		{
			try
			{
				var networkCard = await _context.NetworkCard
				.FirstOrDefaultAsync(c => c.Id == NetworkCardId);

				if (networkCard == null)
					throw new Exception($"No Network card with such id: {NetworkCardId}");

				return networkCard;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task UpdateNetworkCardAsync(int NetworkCardId, NetworkCardDto NetworkCard)
		{
			try
			{
				var networkCard = await _context.NetworkCard
				.FirstOrDefaultAsync(c => c.Id == NetworkCardId);

				if (networkCard == null)
					throw new Exception($"No Network card with such id = {NetworkCardId}.");

				if (networkCard.Speed != NetworkCard.Speed)
					networkCard.Speed = NetworkCard.Speed;

				if (networkCard.MACAddress != NetworkCard.MACAddress)
					networkCard.MACAddress = NetworkCard.MACAddress;

				if (networkCard.Specification != NetworkCard.Specification)
					networkCard.Specification = NetworkCard.Specification;


				_context.NetworkCard.Update(networkCard);
				await _context.SaveChangesAsync();
			}

			catch
			{
				throw new Exception($"Error");
			}
		}
	}
}
