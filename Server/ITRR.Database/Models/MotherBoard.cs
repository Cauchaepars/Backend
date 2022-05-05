
namespace ITRR.Database.Models
{
	public class MotherBoard
	{
		public int MotherBoardId { get; set; }

		public string Name { get; set; }
		public string Socket { get; set; }
		public string FSBFrequency { get; set; }
		public string RAMConnector { get; set; }
		
		public virtual ComputerInfo ComputerInfo { get; set; }
	}
}
