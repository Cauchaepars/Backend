using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using System.Threading.Tasks;

namespace ITRR.Database.Repositories.NetworkCardRepository
{
	public interface INetworkCardRepository
	{
		Task<NetworkCard> GetNetworkCardAsync(int NetworkCardId);
		Task<int> CreateNetworkCardAsync(NetworkCardDto NetworkCard, int ComputerInfoId);
		Task UpdateNetworkCardAsync(int NetworkCardId, NetworkCardDto NetworkCard);
		Task DeleteNetworkCardAsync(int NetworkCardId);
	}
}
