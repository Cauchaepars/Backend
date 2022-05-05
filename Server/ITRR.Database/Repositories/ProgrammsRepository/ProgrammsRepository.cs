using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ITRR.Database.Repositories.ProgrammsRepository
{
    public class ProgrammsRepository : BaseRepository, IProgrammsRepository
    {
        public ProgrammsRepository(ITRRDbContext context) : base(context) { }

        public async Task<int> CreateProgrammsAsync(ProgrammsDto Programms)
        {
            try
            {
                var programm = new Programms()
                {
                    Name = Programms.Name,
                    FirstdownloadDate = Programms.FirstdownloadDate,
                    Volume = Programms.Volume
                };

                await _context.Programs.AddAsync(programm);
                await _context.SaveChangesAsync();

                return programm.ProgramId;
            }
            catch
            {
                throw new Exception($"Error");
            }
        }

        public async Task<Programms> GetProgrammsAsync(int ProgrammsId)
        {
			try
			{
                var programms = await _context.Programs
                .FirstOrDefaultAsync(c => c.ProgramId == ProgrammsId);

                if (programms == null)
                    throw new Exception($"No programms with such id: {ProgrammsId}");

                return programms;
            }
			catch
			{
                throw new Exception($"Error");
            }
        }

        public async Task UpdateProgrammsAsync(int ProgrammsId, ProgrammsDto Programms)
        {
			try
			{
                var programms = await _context.Programs.FirstOrDefaultAsync(c => c.ProgramId == ProgrammsId);

                if (programms == null)
                    throw new Exception($"No programms with such id = {ProgrammsId}.");

                if (programms.Name != Programms.Name)
                    programms.Name = Programms.Name;

                if (programms.FirstdownloadDate != Programms.FirstdownloadDate)
                    programms.FirstdownloadDate = Programms.FirstdownloadDate;

                if (programms.Volume != Programms.Volume)
                    programms.Volume = Programms.Volume;

   
                _context.Programs.Update(programms);
                await _context.SaveChangesAsync();
            }
			catch
			{
                throw new Exception($"Error");
            }
        }

        public async Task DeleteProgrammsAsync(int ProgrammsId)
        {
			try
			{
                var programms = await _context.Programs.FirstOrDefaultAsync(c => c.ProgramId == ProgrammsId);

                if (programms == null)
                    throw new Exception($"No programms with such id = {ProgrammsId}.");

                _context.Programs.Remove(programms);
                await _context.SaveChangesAsync();
            }
			catch
			{
                throw new Exception($"Error");
            }
        }

		public async Task<int> ComputersToProgramms(int ProgrammsId, int ComputerInfoId)
		{
            var computerInfo = await _context.ComputerInfo
               .FirstOrDefaultAsync(c => c.ComputerId == ComputerInfoId);

            var programs = await _context.Programs
                .FirstOrDefaultAsync(c => c.ProgramId == ProgrammsId);

            var ComputerToProgramms = new ComputersToProgramms()
            {
                Programms = programs,
                Computer = computerInfo
            };

            await _context.ComputersToProgramms.AddAsync(ComputerToProgramms);
            await _context.SaveChangesAsync();

            return ComputerToProgramms.Id;
        }
	}
}
