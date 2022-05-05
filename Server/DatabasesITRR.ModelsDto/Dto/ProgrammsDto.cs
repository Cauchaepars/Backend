using Newtonsoft.Json;

namespace DatabasesITRR.ModelsDto.Dto
{
	[JsonObject]
	public class ProgrammsDto
	{
		[JsonProperty("ProgramId")]
		public int ProgramId { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }

		[JsonProperty("Version")]
		public string Version { get; set; }

		[JsonProperty("FirstdownloadDate")]
		public string FirstdownloadDate { get; set; }

		[JsonProperty("Volume")]
		public string Volume { get; set; }
	}
}
