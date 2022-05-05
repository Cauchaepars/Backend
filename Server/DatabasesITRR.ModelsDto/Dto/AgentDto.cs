using Newtonsoft.Json;
using System.Collections.Generic;

namespace DatabasesITRR.ModelsDto.Dto
{
	[JsonObject]
 	public class AgentDto
	{
		//Computer
		[JsonProperty("ComputerId")]
		public int ComputerId { get; set; }

		[JsonProperty("OSVersion")]
		public string OSVersion { get; set; }

		[JsonProperty("ComputerName")]
		public string ComputerName { get; set; }

		[JsonProperty("SystemFolder")]
		public string SystemFolder { get; set; }

		[JsonProperty("CreationTime")]
		public string CreationTime { get; set; }

		[JsonProperty("UpdateTime")]
		public string UpdateTime { get; set; }

		[JsonProperty("OSName")]
		public string OSName { get; set; }
		//CPU
		[JsonProperty("CPUId")]
		public int CPUId { get; set; }

		[JsonProperty("CPUFrequncy")]
		public string CPUFrequncy { get; set; }

		[JsonProperty("CPUBitness")]
		public string CPUBitness { get; set; }

		[JsonProperty("CPUCacheMemory")]
		public string CPUCacheMemory { get; set; }

		[JsonProperty("CPUName")]
		public string CPUName { get; set; }

		[JsonProperty("NumberOfCores")]
		public string NumberOfCores { get; set; }
		//GPU
		[JsonProperty("GPUId")]
		public List<int> GPUId { get; set; }

		[JsonProperty("GPUFrequency")]
		public List<string> GpuFrequency { get; set; }

		[JsonProperty("VolumeMemory")]
		public List<string> VolumeMemory { get; set; }

		[JsonProperty("GPUName")]
		public List<string> GpuName { get; set; }
		//HDD
		[JsonProperty("HDDId")]
		public List<int> HDDId { get; set; }
		
		[JsonProperty("HDDAmount")]
		public List<string> HDDAmount { get; set; }

		[JsonProperty("HDDMaxSpeedWrite")]
		public List<string> HDDMaxSpeedWrite { get; set; }

		[JsonProperty("HDDMaxSpeedRead")]
		public List<string> HDDMaxSpeedRead { get; set; }

		[JsonProperty("HDDName")]
		public List<string> HDDName { get; set; }
		//SSD
		[JsonProperty("SSDId")]
		public List<int> SSDId { get; set; }

		[JsonProperty("SSDAmount")]
		public List<string> SSDAmount { get; set; }

		[JsonProperty("SSDMaxSpeedWrite")]
		public List<string> SSDMaxSpeedWrite { get; set; }

		[JsonProperty("SSDMaxSpeedRead")]
		public List<string> SSDMaxSpeedRead { get; set; }

		[JsonProperty("SSDName")]
		public List<string> SSDName { get; set; }
		//RAM
		[JsonProperty("RAMId")]
		public List<int> RAMId { get; set; }

		[JsonProperty("RAMFrequency")]
		public List<string> RAMFrequency { get; set; }

		[JsonProperty("RAMVolume")]
		public List<string> RAMVolume { get; set; }

		[JsonProperty("RAMName")]
		public List<string> RAMName { get; set; }
		//Programms
		[JsonProperty("ProgramId")]
		public List<int> ProgramId { get; set; }

		[JsonProperty("ProgramName")]
		public List<string> ProgramName { get; set; }

		[JsonProperty("ProgramFirstdownloadDate")]
		public List<string> ProgramFirstdownloadDate { get; set; }

		[JsonProperty("ProgramVolume")]
		public List<string> ProgramVolume { get; set; }
		//NetworkCard
		[JsonProperty("NetworkCardId")]
		public int Id { get; set; }

		[JsonProperty("MACAddress")]
		public string MACAddress { get; set; }

		[JsonProperty("Speed")]
		public string Speed { get; set; }
		

		[JsonProperty("Specification")]
		public string Specification { get; set; }

		[JsonProperty("NetworkCardName")]
		public string NetworkCardName { get; set; }
		//MotherBoard
		[JsonProperty("MotherBoardId")]
		public int MotherBoardId { get; set; }

		[JsonProperty("Socket")]
		public string Socket { get; set; }

		[JsonProperty("FSBFrequncy")]
		public string FSBFrequncy { get; set; }

		[JsonProperty("RAMConnector")]
		public string RAMConnector { get; set; }

		[JsonProperty("MotherBoardName")]
		public string MotherBoardName { get; set; }
		//USB
		[JsonProperty("USBDevicesId")]
		public List<int> USBDevicesId { get; set; }

		[JsonProperty("UsbName")]
		public List<string> UsbName { get; set; }
	}
}
