using DatabasesITRR.ModelsDto.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ITRR.Database.Repositories.AgentRepository
{
	public interface IAgentRepository
	{
		Task<int> CreateInfoFileforAgent(AgentDto AgentInfo);

		Task UpdateInfoFileforAgent(AgentDto AgentInfo, int ComputerId);
	}
}
