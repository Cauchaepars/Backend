using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using System.Threading.Tasks;

namespace ITRR.Database.Repositories.CPURepository
{
	public interface ICPURepository
	{
		Task<CPU> GetCPUAsync(int CPUId);
		Task<int> CreateCPUAsync(CPUDto Cpu, int ComputerInfoId);
		Task UpdateCPUAsync(int CPUId, CPUDto Cpu);
		Task DeleteCPUAsync(int CPUId);
	}
}
