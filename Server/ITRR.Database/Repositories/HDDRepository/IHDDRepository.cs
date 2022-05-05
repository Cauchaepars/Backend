using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using System.Threading.Tasks;

namespace ITRR.Database.Repositories.HDDRepository
{
	public interface IHDDRepository
	{
		Task<HDD> GetHDDAsync(int HDDId);
		Task<int> CreateHDDAsync(HDDDto Hdd);
		Task UpdateHDDAsync(int HDDId, HDDDto Hdd);
		Task DeleteHDDAsync(int HDDId);
		Task<int> ComputersToHdd(int HDDId, int ComputerId);
	}
}
