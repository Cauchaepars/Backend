using System;
using System.Collections.Generic;
using System.Text;

namespace ITRR.Database.Models
{
	public class SSD
	{
		public int SSDId { get; set; }

		public string Amount { get; set; }
		public string MaxSpeedWrite { get; set; }
		public string MaxSpeedRead { get; set; }
		public string Name { get; set; }
	}
}
