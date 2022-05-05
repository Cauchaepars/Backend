using System;
using System.Collections.Generic;
using System.Text;

namespace ITRR.Database.Models
{
	public class ComputersToProgramms
	{
		public int Id { get; set; }

		public virtual Programms Programms { get; set; }
		public virtual ComputerInfo Computer { get; set; }
	}
}
