using Newtonsoft.Json;

namespace DatabasesITRR.ModelsDto.Dto
{
	[JsonObject]
	public class GPUDto
	{
		[JsonProperty("GPUId")]
		public int GPUId { get; set; }

		[JsonProperty("Frequency")]
		public string Frequency { get; set; }

		[JsonProperty("VolumeMemory")]
		public string VolumeMemory { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
