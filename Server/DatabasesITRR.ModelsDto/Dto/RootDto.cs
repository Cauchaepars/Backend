using System;
using System.Collections.Generic;
using System.Text;

namespace DatabasesITRR.ModelsDto.Dto
{
	class RootDto
	{

		public class Rootobject
		{
			public string OSVersion { get; set; }
			public string ComputerName { get; set; }
			public string SystemFolder { get; set; }
			public string CreationTime { get; set; }
			public string UpdateTime { get; set; }
			public string OSName { get; set; }
			public int CPUId { get; set; }
			public string CPUFrequncy { get; set; }
			public string CPUBitness { get; set; }
			public string CPUCacheMemory { get; set; }
			public string CPUName { get; set; }
			public string NumberOfCores { get; set; }
			public int GPUId { get; set; }
			public string[] GPUName { get; set; }
			public string[] GPUFrequency { get; set; }
			public string[] VolumeMemory { get; set; }
			public int HDDId { get; set; }
			public object HDDName { get; set; }
			public object HDDAmount { get; set; }
			public object HDDMaxSpeedWrite { get; set; }
			public object HDDMaxSpeedRead { get; set; }
			public int MotherBoardId { get; set; }
			public string Socket { get; set; }
			public string MotherBoardName { get; set; }
			public string Provider { get; set; }
			public object FSBType { get; set; }
			public string FSBFrequncy { get; set; }
			public string RAMConnector { get; set; }
			public int NetWorkCardId { get; set; }
			public string NetWorkCardName { get; set; }
			public string MACAdress { get; set; }
			public string Speed { get; set; }
			public int ProgramId { get; set; }
			public string[] ProgramName { get; set; }
			public object ProgramVersion { get; set; }
			public string[] ProgramFirstDownloadDate { get; set; }
			public string[] ProgramVolume { get; set; }
			public int RAMId { get; set; }
			public object RAMName { get; set; }
			public object RAMFrequency { get; set; }
			public object RAMVolume { get; set; }
			public int SSDId { get; set; }
			public string[] SSDName { get; set; }
			public string[] SSDAmount { get; set; }
			public object SSDMaxSpeedWrite { get; set; }
			public object SSDMaxSpeedRead { get; set; }
			public int USBDevicesId { get; set; }
			public object UsbName { get; set; }
		}

	}
}
