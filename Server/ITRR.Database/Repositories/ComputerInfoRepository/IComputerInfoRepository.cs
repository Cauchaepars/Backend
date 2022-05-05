using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ITRR.Database.Repositories.ComputerInfoRepository
{
	public interface IComputerInfoRepository
	{
		Task<ComputerInfo> GetComputerInfoAsync(int computerInfoId);
		Task<int> CreateComputerInfoAsync(ComputerInfoDto ComputerInfo);
		Task UpdateComputerInfoAsync(int computerInfoId, ComputerInfoDto ComputerInfo);
		Task DeleteComputerInfoAsync(int computerInfoId);
		Task<List<ComputerInfo>> GetAllComputerAsync();

		Task<List<GPU>> GetGPUs(int computerInfoId);
		Task<List<RAM>> GetRAMs(int computerInfoId);
		Task<List<HDD>> GetHDDs(int computerInfoId);
		Task<List<SSD>> GetSSDs(int computerInfoId);
		Task<List<USBDevices>> GetUSBs(int computerInfoId);
		Task<List<Programms>> GetProgramms(int computerInfoId);

		Task<CPU> GetCPU(int computerInfoId);
		Task<MotherBoard> GetMotherBoard(int computerInfoId);

		//Task CreateInfoFileforAgent(string result);
		//Task UpdateInfoFileforAgent(string result);
	}
}
