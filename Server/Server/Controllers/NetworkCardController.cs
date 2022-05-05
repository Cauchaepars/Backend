using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Repositories.NetworkCardRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NetworkCardController : Controller
    {
        private readonly INetworkCardRepository _networkCardRepository;

        public NetworkCardController(INetworkCardRepository networkCardRepository)
        {
            _networkCardRepository = networkCardRepository;
        }

        [HttpGet("{NetworkCardId}")]
        public async Task<IActionResult> GetNetworkCard(int NetworkCardId)
        {
            IActionResult response;
            try
            {
                var cpuDto = await _networkCardRepository.GetNetworkCardAsync(NetworkCardId);
                response = Ok(cpuDto);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPost("{ComputerInfoId}")]
        public async Task<IActionResult> CreateNetworkCard([FromBody] NetworkCardDto networkCard, int ComputerInfoId)
        {
            IActionResult response;

            try
            {
                await _networkCardRepository.CreateNetworkCardAsync(networkCard, ComputerInfoId);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPut("{NetworkCardId}")]
        public async Task<IActionResult> UpdateCPU(int NetworkCardId, [FromBody] NetworkCardDto networkCard)
        {
            IActionResult response;

            try
            {
                await _networkCardRepository.UpdateNetworkCardAsync(NetworkCardId, networkCard);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpDelete("{NetworkCardId}")]
        public async Task<IActionResult> DeleteCPU(int NetworkCardId)
        {
            IActionResult response;

            try
            {
                await _networkCardRepository.DeleteNetworkCardAsync(NetworkCardId);
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
