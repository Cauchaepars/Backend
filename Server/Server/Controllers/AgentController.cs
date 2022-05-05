using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Repositories.AgentRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Server.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class AgentController : Controller
	{
		private readonly IAgentRepository _agentRepository;
		private readonly IWebHostEnvironment _appEnvironment;

        public AgentController(IAgentRepository agentRepository, IWebHostEnvironment appEnvironment)
		{
			_agentRepository = agentRepository;
			_appEnvironment = appEnvironment;
		}

		[HttpPost("SendInfo")]
		public async Task<int> SendInfo([FromBody] AgentDto Agent)
		{
			int response;
			try
			{
				response = await _agentRepository.CreateInfoFileforAgent(Agent);
			}
			catch (Exception ex)
			{
				throw new Exception("Error");
			}

			return response;
		}



		[HttpPost("Update/{ComputerId}")]
		public async Task<IActionResult> UpdateInfo([FromBody] AgentDto Agent, int ComputerId)
		{
			IActionResult response;
			try
			{
				await _agentRepository.UpdateInfoFileforAgent(Agent,ComputerId);
				response = StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}



		[HttpGet("GetFile/{ComputerId}")]
		public async Task<IActionResult> GetFile(int ComputerId)
		{
			IActionResult response;
			try
			{
				string file_path = Path.Combine(_appEnvironment.ContentRootPath, "AgentsInfo/Agent#" + ComputerId + ".json");

				string file_type = "application/json";

				var test = PhysicalFile(file_path, file_type);

				response = StatusCode(StatusCodes.Status204NoContent);

				return PhysicalFile(file_path, file_type);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpGet("UpdateGetFiles/{ComputerId}")]
		public async Task<IActionResult> UpdateFileGet(int ComputerId)
		{
			IActionResult response;
			try
			{
				string file_path = Path.Combine(_appEnvironment.ContentRootPath, "AgentsUpdateInfo/Agent#" + ComputerId + ".json");
				string file_type = "application/json";

				var test = PhysicalFile(file_path, file_type);

				response = StatusCode(StatusCodes.Status204NoContent);

				return PhysicalFile(file_path, file_type);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}

		[HttpPost("SendFile/{ComputerId}")]
		public async Task<IActionResult> SendFile(int ComputerId,string info)
		{
			IActionResult response;
			try 
			{
				string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Messages/User#" + ComputerId + ".txt");

				string subPath = Path.Combine(_appEnvironment.ContentRootPath, "Messages");

				DirectoryInfo dirInfo = new DirectoryInfo(subPath);


				if (!dirInfo.Exists)
				{
					dirInfo.Create();
				}


				using (StreamWriter sw = new StreamWriter(file_path, false, Encoding.Default))
				{
					sw.WriteLine(info);
				}

				response = StatusCode(StatusCodes.Status204NoContent);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}


		[HttpGet("CustomText/{ComputerId}")]
		public async Task<IActionResult> CustomText(int ComputerId)
		{
			IActionResult response;
			try
			{
				string file_path = Path.Combine(_appEnvironment.ContentRootPath, "Messages/User#" + ComputerId + ".txt");

				string subPath = Path.Combine(_appEnvironment.ContentRootPath, "Messages");

				DirectoryInfo dirInfo = new DirectoryInfo(subPath);


				 if (!dirInfo.Exists)
                 {
					dirInfo.Create();
                 }


				string file_type = "text/plain";

				var test = PhysicalFile(file_path, file_type);
				response = StatusCode(StatusCodes.Status204NoContent);
				return PhysicalFile(file_path, file_type);
			}
			catch (Exception ex)
			{
				response = StatusCode(StatusCodes.Status500InternalServerError);
			}

			return response;
		}
	}
}
