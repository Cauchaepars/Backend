using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using System.Threading.Tasks;

namespace ITRR.Database.Repositories.GPURepository
{
	public interface IGPURepository
	{
		Task<GPU> GetGPUAsync(int GPUId);
		Task<int> CreateGPUAsync(GPUDto Gpu);
		Task UpdateGPUAsync(int GPUId, GPUDto Gpu);
		Task DeleteGPUAsync(int GPUId);
		Task<int> ComputersToGpu(int GPUId, int ComputerId);
	}
}
