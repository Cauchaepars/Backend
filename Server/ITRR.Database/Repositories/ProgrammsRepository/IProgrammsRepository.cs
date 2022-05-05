using ITRR.Database.Models;
using System.Threading.Tasks;
using DatabasesITRR.ModelsDto.Dto;

namespace ITRR.Database.Repositories.ProgrammsRepository
{
    public interface IProgrammsRepository
    {
        Task<Programms> GetProgrammsAsync(int ProgrammsId);
        Task<int> CreateProgrammsAsync(ProgrammsDto Programms);
        Task UpdateProgrammsAsync(int ProgrammsId, ProgrammsDto Programms);
        Task DeleteProgrammsAsync(int ProgrammsId);
        Task<int> ComputersToProgramms(int ProgrammsId, int ComputerId);
    }
}
