using System;
using System.Collections.Generic;
using System.Text;

namespace ITRR.Database.Models
{
	public class ComputersToSSD
	{
		public int Id { get; set; }

		public virtual SSD Ssd { get; set; }
		public virtual ComputerInfo Computer { get; set; }
	}
}
