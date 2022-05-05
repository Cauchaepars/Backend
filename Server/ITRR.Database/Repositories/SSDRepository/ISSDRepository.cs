using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using System.Threading.Tasks;

namespace ITRR.Database.Repositories.SSDRepository
{
	public interface ISSDRepository
	{
		Task<SSD> GetSSDAsync(int SSDId);
		Task<int> CreateSSDAsync(SSDDto Ssd);
		Task UpdateSSDAsync(int SSDId, SSDDto Ssd);
		Task DeleteSSDAsync(int SSDId);
		Task<int> ComputersToSsd(int SSDId, int ComputerId);
	}
}
