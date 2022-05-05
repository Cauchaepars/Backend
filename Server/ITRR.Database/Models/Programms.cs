using System.ComponentModel.DataAnnotations;

namespace ITRR.Database.Models
{
	public class Programms
	{
		[Key]
		public int ProgramId { get; set; }

		public string Name { get; set; }
		public string FirstdownloadDate { get; set; }
		public string Volume { get; set; }
	}
}
