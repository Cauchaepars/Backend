using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Repositories.ProgrammsRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProgrammsController : Controller
    {
        private readonly IProgrammsRepository _programmsRepository;

        public ProgrammsController(IProgrammsRepository programmsRepository)
        {
            _programmsRepository = programmsRepository;
        }

        [HttpGet("{ProgrammsId}")]
        public async Task<IActionResult> GetProgramms(int ProgrammsId)
        {
            IActionResult response;
            try
            {
                var programmsDto = await _programmsRepository.GetProgrammsAsync(ProgrammsId);
                response = Ok(programmsDto);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }


        [HttpPost("{ProgrammsId}/{ComputerInfoId}")]
        public async Task<IActionResult> CreateGPU(int ProgrammsId, int ComputerInfoId)
        {
            IActionResult response;

            try
            {
                await _programmsRepository.ComputersToProgramms(ProgrammsId, ComputerInfoId);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProgramms([FromBody] ProgrammsDto programms)
        {
            IActionResult response;

            try
            {
                await _programmsRepository.CreateProgrammsAsync(programms);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPut("{ProgrammsId}")]
        public async Task<IActionResult> UpdateProgramms(int ProgrammsId, [FromBody] ProgrammsDto programms)
        {
            IActionResult response;

            try
            {
                await _programmsRepository.UpdateProgrammsAsync(ProgrammsId, programms);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpDelete("{ProgrammsId}")]
        public async Task<IActionResult> DeleteProgramms(int ProgrammsId)
        {
            IActionResult response;

            try
            {
                await _programmsRepository.DeleteProgrammsAsync(ProgrammsId);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }
    }
}
