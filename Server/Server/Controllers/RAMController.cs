using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Repositories.RAMRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RAMController : Controller
    {
        private readonly IRAMRepository _ramRepository;

        public RAMController(IRAMRepository ramRepository)
        {
            _ramRepository = ramRepository;
        }

        [HttpGet("{RAMId}")]
        public async Task<IActionResult> GetRAM(int RAMId)
        {
            IActionResult response;
            try
            {
                var ramDto = await _ramRepository.GetRAMAsync(RAMId);
                response = Ok(ramDto);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }


        [HttpPost("{RAMId}/{ComputerInfoId}")]
        public async Task<IActionResult> CreateGPU(int RAMId, int ComputerInfoId)
        {
            IActionResult response;

            try
            {
                await _ramRepository.ComputersToRam(RAMId, ComputerInfoId);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRAM([FromBody] RAMDto ram)
        {
            IActionResult response;

            try
            {
                await _ramRepository.CreateRAMAsync(ram);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPut("{RAMId}")]
        public async Task<IActionResult> UpdateRAM(int RAMId, [FromBody] RAMDto ram)
        {
            IActionResult response;

            try
            {
                await _ramRepository.UpdateRAMAsync(RAMId, ram);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpDelete("{RAMId}")]
        public async Task<IActionResult> DeleteRAM(int RAMId)
        {
            IActionResult response;

            try
            {
                await _ramRepository.DeleteRAMAsync(RAMId);
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
