using System;
using System.Collections.Generic;
using System.Text;

namespace ITRR.Database.Models
{
	public class ComputersToGPU
	{
		public int Id { get; set; }

		public virtual GPU Gpu { get; set; }
		public virtual ComputerInfo Computer { get; set; }
	}
}
