using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using System.Threading.Tasks;

namespace ITRR.Database.Repositories.USBDevicesRepository
{
	public interface IUSBDevicesRepository
	{
		Task<USBDevices> GetUSBDevicesAsync(int USBDevicesId);
		Task<int> CreateUSBDevicesAsync(USBDevicesDto UsbDevices);
		Task UpdateUSBDevicesAsync(int USBDevicesId, USBDevicesDto UsbDevices);
		Task DeleteUSBDevicesAsync(int USBDevicesId);
		Task<int> ComputersToUSBDevices(int USBDevicesId, int ComputerId);
	}
}
