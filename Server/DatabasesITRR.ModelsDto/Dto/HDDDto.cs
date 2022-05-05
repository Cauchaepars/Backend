using Newtonsoft.Json;

namespace DatabasesITRR.ModelsDto.Dto
{
	[JsonObject]
	public class HDDDto
	{
		[JsonProperty("HDDId")]
		public int HDDId { get; set; }

		[JsonProperty("Amount")]
		public string Amount { get; set; }

		[JsonProperty("MaxSpeedWrite")]
		public string MaxSpeedWrite { get; set; }

		[JsonProperty("MaxSpeedRead")]
		public string MaxSpeedRead { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
