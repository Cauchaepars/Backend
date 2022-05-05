using Newtonsoft.Json;


namespace DatabasesITRR.ModelsDto.Dto
{
	[JsonObject]
	public class USBDevicesDto
	{
		[JsonProperty("USBDevicesId")]
		public int USBDevicesId { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}
