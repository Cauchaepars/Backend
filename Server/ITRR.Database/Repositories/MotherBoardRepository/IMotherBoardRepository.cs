using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using System.Threading.Tasks;

namespace ITRR.Database.Repositories.MotherBoardRepository
{
	public interface IMotherBoardRepository
	{
		Task<MotherBoard> GetMotherBoardAsync(int MotherBoardId);
		Task<int> CreateMotherBoardAsync(MotherBoardDto MotherBoard, int ComputerInfoId);
		Task UpdateMotherBoardAsync(int MotherBoardId, MotherBoardDto motherBoard);
		Task DeleteMotherBoardAsync(int MotherBoardId);
	}
}
