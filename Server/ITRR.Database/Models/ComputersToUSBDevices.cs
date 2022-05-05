using System;
using System.Collections.Generic;
using System.Text;

namespace ITRR.Database.Models
{
	public class ComputersToUSBDevices
	{
		public int Id { get; set; }

		public virtual USBDevices USBDevices { get; set; }
		public virtual ComputerInfo Computer { get; set; }
	}
}
