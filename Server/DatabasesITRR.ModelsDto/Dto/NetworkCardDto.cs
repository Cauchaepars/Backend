using Newtonsoft.Json;

namespace DatabasesITRR.ModelsDto.Dto
{
	[JsonObject]
	public class NetworkCardDto
	{
		[JsonProperty("NetworkCardId")]
		public int Id { get; set; }

		[JsonProperty("MACAddress")]
		public string MACAddress { get; set; }

		[JsonProperty("Speed")]
		public string Speed { get; set; }

		[JsonProperty("Specification")]
		public string Specification { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("ComputerId")]
		public int ComputerId { get; set; }
	}
}
