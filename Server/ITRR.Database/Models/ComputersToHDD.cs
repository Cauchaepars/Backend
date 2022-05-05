using System;
using System.Collections.Generic;
using System.Text;

namespace ITRR.Database.Models
{
	public class ComputersToHDD
	{
		public int Id { get; set; }

		public virtual HDD Hdd { get; set; }
		public virtual ComputerInfo Computer { get; set; }
	}
}
