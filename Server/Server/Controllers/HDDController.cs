using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using ITRR.Database.Repositories.HDDRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class HDDController : Controller
	{
		private readonly IHDDRepository _hddRepository;

		public HDDController(IHDDRepository hddRepository)
		{
			_hddRepository = hddRepository;
		}

		[HttpGet("{HDDId}")]
		public async Task<IActionResult> GetHDD(int HDDId)
		{
			IActionResult response;
			try
			{
				var hdd = await _hddRepository.GetHDDAsync(HDDId);
				response = Ok(hdd);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;		
		}


		[HttpPost("{HDDId}/{ComputerInfoId}")]
		public async Task<IActionResult> CreateHDD(int HDDId, int ComputerInfoId)
		{
			IActionResult response;

			try
			{
				await _hddRepository.ComputersToHdd(HDDId, ComputerInfoId);
				response = StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpPost]
		public async Task<IActionResult> CreateHDD([FromBody] HDDDto hdd)
		{
			IActionResult response;

			try
			{
				await _hddRepository.CreateHDDAsync(hdd);
				response = StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpPut("{HDDId}")]
		public async Task<IActionResult> UpdateHDD(int HDDId, [FromBody] HDDDto hdd)
		{
			IActionResult response;

			try
			{
				await _hddRepository.UpdateHDDAsync(HDDId, hdd);
				response = StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpDelete("{HDDId}")]
		public async Task<IActionResult> DeleteHDD(int HDDId)
		{
			IActionResult response;

			try
			{
				await _hddRepository.DeleteHDDAsync(HDDId);
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
