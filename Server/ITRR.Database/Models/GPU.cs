using System;
using System.Collections.Generic;
using System.Text;

namespace ITRR.Database.Models
{
	public class GPU
	{
		public int GPUId { get; set; }

		public string Name { get; set; }
		public string Frequency { get; set; }
		public string VolumeMemory { get; set; }
	}
}
