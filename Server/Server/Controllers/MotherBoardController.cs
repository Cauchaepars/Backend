using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Repositories.MotherBoardRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MotherBoardController : Controller
	{
		private readonly IMotherBoardRepository _motherBoardRepository;

		public MotherBoardController(IMotherBoardRepository motherBoardRepository)
		{
			_motherBoardRepository = motherBoardRepository;
		}

		[HttpGet("{MotherBoardId}")]
		public async Task<IActionResult> GetMotherBoard(int MotherBoardId)
		{
			IActionResult response;
			try
			{
				var motherBoard = await _motherBoardRepository.GetMotherBoardAsync(MotherBoardId);
				response = Ok(motherBoard);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpPost("{ComputerInfoId}")]
		public async Task<IActionResult> CreateMotherBoard([FromBody] MotherBoardDto motherBoard, int ComputerInfoId)
		{
			IActionResult response;

			try
			{
				await _motherBoardRepository.CreateMotherBoardAsync(motherBoard, ComputerInfoId);
				response = StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpPut("{MotherBoardId}")]
		public async Task<IActionResult> UpdateMotherBoard(int MotherBoardId, [FromBody] MotherBoardDto motherBoard)
		{
			IActionResult response;

			try
			{
				await _motherBoardRepository.UpdateMotherBoardAsync(MotherBoardId, motherBoard);
				response = StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpDelete("{MotherBoardId}")]
		public async Task<IActionResult> DeleteMotherBoard(int MotherBoardId)
		{
			IActionResult response;

			try
			{
				await _motherBoardRepository.DeleteMotherBoardAsync(MotherBoardId);
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
