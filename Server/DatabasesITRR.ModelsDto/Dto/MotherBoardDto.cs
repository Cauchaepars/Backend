using Newtonsoft.Json;

namespace DatabasesITRR.ModelsDto.Dto
{
	[JsonObject]
	public class MotherBoardDto
	{
		[JsonProperty("MotherBoardId")]
		public int MotherBoardId { get; set; }

		[JsonProperty("Socket")]
		public string Socket { get; set; }

		[JsonProperty("FSBFrequency")]
		public string FSBFrequency { get; set; }

		[JsonProperty("RAMConnector")]
		public string RAMConnector { get; set; }

		[JsonProperty("ComputerId")]
		public int ComputerId { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
