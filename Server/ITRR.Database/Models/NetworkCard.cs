using System;
using System.Collections.Generic;
using System.Text;

namespace ITRR.Database.Models
{
	public class NetworkCard
	{
		public int Id { get; set; }
		public string MACAddress { get; set; }
		public string Speed { get; set; }
		public string Specification { get; set; }
		public string Name { get; set; }

		public virtual ComputerInfo ComputerInfo { get; set; }
	}
}
