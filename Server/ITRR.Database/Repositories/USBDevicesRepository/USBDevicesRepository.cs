using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ITRR.Database.Repositories.USBDevicesRepository
{
	public class USBDevicesRepository : BaseRepository, IUSBDevicesRepository
	{
		public USBDevicesRepository(ITRRDbContext context) : base(context) { }

		public async Task<int> CreateUSBDevicesAsync(USBDevicesDto UsbDevices)
		{
			try
			{
				var usbDevices = new USBDevices()
				{
					Name = UsbDevices.Name
				};

				await _context.UsbDevices.AddAsync(usbDevices);
				await _context.SaveChangesAsync();

				return usbDevices.USBDevicesId;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<USBDevices> GetUSBDevicesAsync(int USBDevicesId)
		{
			try
			{
				var usbDevices = await _context.UsbDevices
				.FirstOrDefaultAsync(c => c.USBDevicesId == USBDevicesId);

				if (usbDevices == null)
					throw new Exception($"No USB with such id: {USBDevicesId}");

				return usbDevices;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task UpdateUSBDevicesAsync(int USBDevicesId, USBDevicesDto UsbDevices)
		{
			try
			{
				var usbDevices = await _context.UsbDevices.FirstOrDefaultAsync(c => c.USBDevicesId == USBDevicesId);

				if (usbDevices == null)
					throw new Exception($"No USB with such id = {USBDevicesId}.");

				if(usbDevices.Name != UsbDevices.Name)
					usbDevices.Name = UsbDevices.Name;
				
				_context.UsbDevices.Update(usbDevices);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task DeleteUSBDevicesAsync(int USBDevicesId)
		{
			try
			{
				var usbDevices = await _context.UsbDevices.FirstOrDefaultAsync(c => c.USBDevicesId == USBDevicesId);

				if (usbDevices == null)
					throw new Exception($"No USB with such id = {USBDevicesId}.");

				_context.UsbDevices.Remove(usbDevices);
				await _context.SaveChangesAsync();
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task<int> ComputersToUSBDevices(int USBDevicesId, int ComputerInfoId)
		{
			var computerInfo = await _context.ComputerInfo
			   .FirstOrDefaultAsync(c => c.ComputerId == ComputerInfoId);

			var usb = await _context.UsbDevices
				.FirstOrDefaultAsync(c => c.USBDevicesId == USBDevicesId);

			var ComputerToUsb = new ComputersToUSBDevices()
			{
				USBDevices = usb,
				Computer = computerInfo
			};

			await _context.ComputersToUSBDevices.AddAsync(ComputerToUsb);
			await _context.SaveChangesAsync();

			return ComputerToUsb.Id;
		}
	}
}
