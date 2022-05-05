using DatabasesITRR.ModelsDto.Dto;
using ITRR.Services;
using Newtonsoft.Json;
using System;
using ITRR.Database.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ITRR.Database.Repositories.AgentRepository
{
	public class AgentRepository : BaseRepository, IAgentRepository
	{
		public AgentRepository(ITRRDbContext context) : base(context) { }

		public async Task<int> CreateInfoFileforAgent(AgentDto AgentInfo)
		{
			try
			{
				var info = JsonConvert.SerializeObject(AgentInfo);

				var result = info;

				//var AgentInfo = JsonConvert.DeserializeObject<AgentDto>(info);

				var ComputerInfo = new ComputerInfo()
				{
					OSVersion = AgentInfo.OSVersion,
					ComputerName = AgentInfo.ComputerName,
					SystemFolder = AgentInfo.SystemFolder,
					CreationTime = AgentInfo.CreationTime,
					UpdateTime = AgentInfo.UpdateTime,
					OSName = AgentInfo.OSName
				};

				await _context.ComputerInfo.AddAsync(ComputerInfo);
				await _context.SaveChangesAsync();

				

				if (AgentInfo.CPUName != null)
				{
					var Cpu = new CPU()
					{
						Frequency = AgentInfo.CPUFrequncy,
						Bitness = AgentInfo.CPUBitness,
						CacheMemory = AgentInfo.CPUCacheMemory,
						Name = AgentInfo.CPUName,
						NumberOfCores = AgentInfo.NumberOfCores,
						ComputerInfo = ComputerInfo
					};

					await _context.CPU.AddAsync(Cpu);
					await _context.SaveChangesAsync();

				
				}


				if(AgentInfo.GpuName != null)
				{
					for (int i = 0; i < AgentInfo.GpuName.Count; i++)
					{
						var Gpu = new GPU()
						{
							Frequency = AgentInfo.GpuFrequency[i],
							VolumeMemory = AgentInfo.VolumeMemory[i],
							Name = AgentInfo.GpuName[i]
						};

						await _context.Gpu.AddAsync(Gpu);
						await _context.SaveChangesAsync();

						var ComputerToGpu = new ComputersToGPU()
						{
							Gpu = Gpu,
							Computer = ComputerInfo
						};

						await _context.ComputersToGPU.AddAsync(ComputerToGpu);
						await _context.SaveChangesAsync();

						
					}
				}

				if(AgentInfo.MotherBoardName != null)
				{
					var MotherBoard = new MotherBoard()
					{
						Socket = AgentInfo.Socket,
						FSBFrequency = AgentInfo.FSBFrequncy,
						RAMConnector = AgentInfo.RAMConnector,
						Name = AgentInfo.MotherBoardName,
						ComputerInfo = ComputerInfo
					};

					await _context.MotherBoard.AddAsync(MotherBoard);
					await _context.SaveChangesAsync();

					
				}


				if (AgentInfo.NetworkCardName != null)
				{
					var NetworkCard = new NetworkCard()
					{
						MACAddress = AgentInfo.MACAddress,
						Speed = AgentInfo.Speed,
						Specification = AgentInfo.Specification,
						Name = AgentInfo.NetworkCardName,
						ComputerInfo = ComputerInfo
					};

					await _context.NetworkCard.AddAsync(NetworkCard);
					await _context.SaveChangesAsync();

					
				}

				if (AgentInfo.HDDName != null)
				{
					for (int i = 0; i < AgentInfo.HDDName.Count; i++)
					{
						var Hdd = new HDD()
						{
							Amount = AgentInfo.HDDAmount[i],
							MaxSpeedWrite = AgentInfo.HDDMaxSpeedWrite[i],
							MaxSpeedRead = AgentInfo.HDDMaxSpeedRead[i],
							Name = AgentInfo.HDDName[i]
						};

						await _context.Hdd.AddAsync(Hdd);
						await _context.SaveChangesAsync();

						var ComputerToHdd = new ComputersToHDD()
						{
							Hdd = Hdd,
							Computer = ComputerInfo
						};

						await _context.ComputersToHDD.AddAsync(ComputerToHdd);
						await _context.SaveChangesAsync();

						
					}
				}
				if (AgentInfo.SSDName != null)
				{

					for (int i = 0; i < AgentInfo.SSDName.Count; i++)
					{
						var Ssd = new SSD()
						{
							Amount = AgentInfo.SSDAmount[i],
							Name = AgentInfo.SSDName[i]
						};

						//if (AgentInfo.SSDMaxSpeedRead[i] != null)
						//{
						//	Ssd.MaxSpeedRead = AgentInfo.SSDMaxSpeedRead[i];

						//}

						//if (AgentInfo.SSDMaxSpeedWrite[i] != null)
						//{
						//	Ssd.MaxSpeedWrite = AgentInfo.SSDMaxSpeedWrite[i];
						//}

						await _context.Ssd.AddAsync(Ssd);
						await _context.SaveChangesAsync();

						var ComputerToSsd = new ComputersToSSD()
						{
							Ssd = Ssd,
							Computer = ComputerInfo
						};

						await _context.ComputersToSSD.AddAsync(ComputerToSsd);
						await _context.SaveChangesAsync();

						
					}
				}
				if (AgentInfo.RAMName != null)
				{
					for (int i = 0; i < AgentInfo.RAMName.Count; i++)
					{
						var Ram = new RAM()
						{
							Frequency = AgentInfo.RAMFrequency[i],
							Volume = AgentInfo.RAMVolume[i],
							Name = AgentInfo.RAMName[i]
						};

						await _context.Ram.AddAsync(Ram);
						await _context.SaveChangesAsync();

						var ComputerToRam = new ComputersToRAM()
						{
							Ram = Ram,
							Computer = ComputerInfo
						};

						await _context.ComputersToRAM.AddAsync(ComputerToRam);
						await _context.SaveChangesAsync();

						
					}
				}

				if (AgentInfo.ProgramName != null)
				{
					for (int i = 0; i < AgentInfo.ProgramVolume.Count; i++)
					{
						var Programm = new Programms()
						{
							Name = AgentInfo.ProgramName[i],
							FirstdownloadDate = AgentInfo.ProgramFirstdownloadDate[i],
							Volume = AgentInfo.ProgramVolume[i]
						};

						await _context.Programs.AddAsync(Programm);
						await _context.SaveChangesAsync();

						var ComputerToProgramms = new ComputersToProgramms()
						{
							Programms = Programm,
							Computer = ComputerInfo
						};

						await _context.ComputersToProgramms.AddAsync(ComputerToProgramms);
						await _context.SaveChangesAsync();

					
					}
				}
				if (AgentInfo.UsbName != null)
				{
					for (int i = 0; i < AgentInfo.UsbName.Count; i++)
					{
						var UsbDevices = new USBDevices()
						{
							Name = AgentInfo.UsbName[i]
						};

						await _context.UsbDevices.AddAsync(UsbDevices);
						await _context.SaveChangesAsync();

						var ComputerToUsb = new ComputersToUSBDevices()
						{
							USBDevices = UsbDevices,
							Computer = ComputerInfo
						};

						await _context.ComputersToUSBDevices.AddAsync(ComputerToUsb);
						await _context.SaveChangesAsync();

						
					}
				}
				MainService main = new MainService();
				main.writeTofile(result, ComputerInfo.ComputerId);
			
				return ComputerInfo.ComputerId;
			}
			catch
			{
				throw new Exception($"Error");
			}
		}

		public async Task UpdateInfoFileforAgent(AgentDto AgentInfo, int ComputerId)
		{
			UpdateService update = new UpdateService();

			string path = Directory.GetCurrentDirectory();
			path += @"\\AgentsInfo\\Agent#" + ComputerId + ".json";

			StreamReader reader = new StreamReader(path);

			string file = reader.ReadToEnd();

			var computer = JsonConvert.DeserializeObject<AgentDto>(file);
			var info = JsonConvert.SerializeObject(AgentInfo);


			if (computer.OSVersion != AgentInfo.OSVersion)
			{
				update = new UpdateService();
				computer.OSVersion = AgentInfo.OSVersion;
				update.writeTofile($"Update ComputerInfo OSVersion: {computer.OSVersion}", ComputerId);
			}

			if (computer.ComputerName != AgentInfo.ComputerName)
			{
				update = new UpdateService();
				computer.ComputerName = AgentInfo.ComputerName;
				update.writeTofile($"Update ComputerInfo ComputerName: {computer.ComputerName}", ComputerId);
			}

			if (computer.SystemFolder != AgentInfo.SystemFolder)
			{
				update = new UpdateService();
				computer.SystemFolder = AgentInfo.SystemFolder;
				update.writeTofile($"Update ComputerInfo SystemFolder: {computer.SystemFolder}", ComputerId);
			}

			if (computer.CreationTime != AgentInfo.CreationTime)
			{
				update = new UpdateService();
				computer.CreationTime = AgentInfo.CreationTime;
				update.writeTofile($"Update ComputerInfo CreationTime: {computer.CreationTime}", ComputerId);
			}

			if (computer.UpdateTime != AgentInfo.UpdateTime)
			{
				update = new UpdateService();
				computer.UpdateTime = AgentInfo.UpdateTime;
				update.writeTofile($"Update ComputerInfo OSVersion: {computer.UpdateTime}", ComputerId);
			}

			if (computer.OSName != AgentInfo.OSName)
			{
				update = new UpdateService();
				computer.OSName = AgentInfo.OSName;
				update.writeTofile($"Update ComputerInfo OSName: {computer.OSName}", ComputerId);
			}

			var ComputerInfo = new ComputerInfo()
			{
				OSVersion = AgentInfo.OSVersion,
				ComputerName = AgentInfo.ComputerName,
				SystemFolder = AgentInfo.SystemFolder,
				CreationTime = AgentInfo.CreationTime,
				UpdateTime = AgentInfo.UpdateTime,
				OSName = AgentInfo.OSName
			};

			_context.ComputerInfo.Update(ComputerInfo);
			await _context.SaveChangesAsync();


			if (AgentInfo.RAMName != null)
			{
				if (computer.RAMName.Count < AgentInfo.RAMName.Count)
				{
					for (int i = AgentInfo.RAMName.Count; i > computer.RAMName.Count; i--)
					{
						var Ram = new RAM()
						{
							Frequency = AgentInfo.RAMFrequency[i],
							Volume = AgentInfo.RAMVolume[i],
							Name = AgentInfo.RAMName[i]
						};

						await _context.Ram.AddAsync(Ram);
						await _context.SaveChangesAsync();

						var ComputerToRam = new ComputersToRAM()
						{
							Ram = Ram,
							Computer = ComputerInfo
						};

						await _context.ComputersToRAM.AddAsync(ComputerToRam);
						await _context.SaveChangesAsync();
						update = new UpdateService();
						update.writeTofile($"Ram add: {Ram.RAMId}", ComputerId);
					}
				}
				for (int i = 0; i < AgentInfo.RAMName.Count; i++)
				{

					if (computer.RAMName[i] != AgentInfo.RAMName[i])
					{
						update = new UpdateService();
						computer.RAMName[i] = AgentInfo.RAMName[i];
						update.writeTofile($"Update RAM Name: {computer.RAMName[i]}", ComputerId);
					}

					if (computer.RAMFrequency[i] != AgentInfo.RAMFrequency[i])
					{
						update = new UpdateService();
						computer.RAMFrequency[i] = AgentInfo.RAMFrequency[i];
						update.writeTofile($"Update RAM Frequency: {computer.RAMFrequency[i]}", ComputerId);
					}

					if (computer.RAMVolume[i] != AgentInfo.RAMVolume[i])
					{
						update = new UpdateService();
						computer.RAMVolume[i] = AgentInfo.RAMVolume[i];
						update.writeTofile($"Update RAM Volume: {computer.RAMVolume[i]}", ComputerId);
					}

					var Ram = new RAM()
					{
						Frequency = AgentInfo.RAMFrequency[i],
						Volume = AgentInfo.RAMVolume[i],
						Name = AgentInfo.RAMName[i]
					};

					_context.Ram.Update(Ram);
					await _context.SaveChangesAsync();
				}
			}


			if (AgentInfo.HDDName != null)
			{
				if (computer.HDDName.Count < AgentInfo.HDDName.Count)
				{
					for (int i = AgentInfo.HDDName.Count; i > computer.HDDName.Count; i--)
					{
						var Hdd = new HDD()
						{
							Amount = AgentInfo.HDDAmount[i],
							MaxSpeedWrite = AgentInfo.HDDMaxSpeedWrite[i],
							MaxSpeedRead = AgentInfo.HDDMaxSpeedRead[i],
							Name = AgentInfo.HDDName[i]
						};

						await _context.Hdd.AddAsync(Hdd);
						await _context.SaveChangesAsync();

						var ComputerToHdd = new ComputersToHDD()
						{
							Hdd = Hdd,
							Computer = ComputerInfo
						};

						await _context.ComputersToHDD.AddAsync(ComputerToHdd);
						await _context.SaveChangesAsync();

						update = new UpdateService();
						update.writeTofile($"HDD add: {Hdd.HDDId}", ComputerId);
					}
				}
				for (int i = 0; i < AgentInfo.HDDName.Count; i++)
				{

					if (computer.HDDAmount[i] != AgentInfo.HDDAmount[i])
					{
						update = new UpdateService();
						computer.HDDAmount[i] = AgentInfo.HDDAmount[i];
						update.writeTofile($"Update HDD Amount: {computer.HDDAmount[i]}", ComputerId);
					}

					if (computer.HDDMaxSpeedWrite[i] != AgentInfo.HDDMaxSpeedWrite[i])
					{
						update = new UpdateService();
						computer.HDDMaxSpeedWrite[i] = AgentInfo.HDDMaxSpeedWrite[i];
						update.writeTofile($"Update HDD MaxSpeedWrite: {computer.HDDMaxSpeedWrite[i]}", ComputerId);
					}

					if (computer.HDDMaxSpeedRead[i] != AgentInfo.HDDMaxSpeedRead[i])
					{
						update = new UpdateService();
						computer.HDDMaxSpeedRead[i] = AgentInfo.HDDMaxSpeedRead[i];
						update.writeTofile($"Update HDD MaxSpeedRead: {computer.HDDMaxSpeedRead[i]}", ComputerId);
					}

					if (computer.HDDName[i] != AgentInfo.HDDName[i])
					{
						update = new UpdateService();
						computer.HDDName[i] = AgentInfo.HDDName[i];
						update.writeTofile($"Update HDD Name: {computer.HDDName[i]}", ComputerId);
					}

					var Hdd = new HDD()
					{
						Amount = AgentInfo.HDDAmount[i],
						MaxSpeedWrite = AgentInfo.HDDMaxSpeedWrite[i],
						MaxSpeedRead = AgentInfo.HDDMaxSpeedRead[i],
						Name = AgentInfo.HDDName[i]
					};

					_context.Hdd.Update(Hdd);
					await _context.SaveChangesAsync();
				}
			}


			
			
				if (computer.SSDName.Count < AgentInfo.SSDName.Count)
				{
					for (int i = AgentInfo.SSDName.Count; i > computer.SSDName.Count; i--)
					{


							var Ssd = new SSD()
						{
							Amount = AgentInfo.SSDAmount[i],

							Name = AgentInfo.SSDName[i]
						};

						//if (AgentInfo.SSDMaxSpeedRead[i] != null)
      //                  {
						//	Ssd.MaxSpeedRead = AgentInfo.SSDMaxSpeedRead[i];
							
      //                  }

						//if (AgentInfo.SSDMaxSpeedWrite[i] != null)
      //                  {
						//	Ssd.MaxSpeedWrite = AgentInfo.SSDMaxSpeedWrite[i];
						//}

						await _context.Ssd.AddAsync(Ssd);
						await _context.SaveChangesAsync();


						var ComputerToSsd = new ComputersToSSD()
						{
							Ssd = Ssd,
							Computer = ComputerInfo
						};

						await _context.ComputersToSSD.AddAsync(ComputerToSsd);
						await _context.SaveChangesAsync();

						update = new UpdateService();
						update.writeTofile($"SSD add: {Ssd.SSDId}", ComputerId);
					}
				}
				for (int i = 0; i < AgentInfo.SSDName.Count; i++)
				{
					
					if (computer.SSDAmount[i] != AgentInfo.SSDAmount[i])
					{
						update = new UpdateService();
						computer.SSDAmount[i] = AgentInfo.SSDAmount[i];
						update.writeTofile($"Update SSD Amount: {computer.SSDAmount[i]}", ComputerId);
					}

					//if (computer.SSDMaxSpeedWrite[i] != AgentInfo.SSDMaxSpeedWrite[i])
					//{
					//	update = new UpdateService();
					//	computer.SSDMaxSpeedWrite[i] = AgentInfo.SSDMaxSpeedWrite[i];
					//	update.writeTofile($"Update SSD MaxSpeedWrite: {computer.SSDMaxSpeedWrite[i]}", ComputerId);
					//}

					//if (computer.SSDMaxSpeedRead[i] != AgentInfo.SSDMaxSpeedRead[i])
					//{
					//	update = new UpdateService();
					//	computer.SSDMaxSpeedRead[i] = AgentInfo.SSDMaxSpeedRead[i];
					//	update.writeTofile($"Update SSD MaxSpeedRead: {computer.SSDMaxSpeedRead[i]}", ComputerId);
					//}

					if (computer.SSDName[i] != AgentInfo.SSDName[i])
					{
						update = new UpdateService();
						computer.SSDName[i] = AgentInfo.SSDName[i];
						update.writeTofile($"Update SSD Name: {computer.SSDName[i]}", ComputerId);
					}

					var Ssd = new SSD()
					{
						Amount = AgentInfo.SSDAmount[i],
						//MaxSpeedWrite = AgentInfo.SSDMaxSpeedWrite[i],
						//MaxSpeedRead = AgentInfo.SSDMaxSpeedRead[i],
						Name = AgentInfo.SSDName[i]
					};

					_context.Ssd.Update(Ssd);
					await _context.SaveChangesAsync();
				}



			

			if (AgentInfo.UsbName != null)
			{
				if (computer.UsbName.Count < AgentInfo.UsbName.Count)
				{
					for (int i = AgentInfo.UsbName.Count; i > computer.UsbName.Count; i--)
					{
						var UsbDevices = new USBDevices()
						{
							Name = AgentInfo.UsbName[i]
						};

						await _context.UsbDevices.AddAsync(UsbDevices);
						await _context.SaveChangesAsync();

						update = new UpdateService();
						update.writeTofile($"UsbDevices add: {UsbDevices.USBDevicesId}", ComputerId);

						var ComputerToUsb = new ComputersToUSBDevices()
						{
							USBDevices = UsbDevices,
							Computer = ComputerInfo
						};

						await _context.ComputersToUSBDevices.AddAsync(ComputerToUsb);
						await _context.SaveChangesAsync();
					}
				}
				for (int i = 0; i < AgentInfo.UsbName.Count; i++)
				{
			
					if (computer.UsbName[i] != AgentInfo.UsbName[i])
					{
						update = new UpdateService();
						computer.UsbName[i] = AgentInfo.UsbName[i];
						update.writeTofile($"Update USB Name: {computer.UsbName[i]}", ComputerId);
					}

					var UsbDevices = new USBDevices()
					{
						Name = AgentInfo.UsbName[i]
					};

					_context.UsbDevices.Update(UsbDevices);
					await _context.SaveChangesAsync();
				}
			}

	
			if (AgentInfo.ProgramName != null)
			{
				if (computer.ProgramName.Count < AgentInfo.ProgramName.Count)
				{
					for (int i = AgentInfo.ProgramName.Count; i > computer.ProgramName.Count; i--)
					{
						var Programm = new Programms()
						{
							Name = AgentInfo.ProgramName[i],
							FirstdownloadDate = AgentInfo.ProgramFirstdownloadDate[i],
							Volume = AgentInfo.ProgramVolume[i]
						};

						await _context.Programs.AddAsync(Programm);
						await _context.SaveChangesAsync();
						update = new UpdateService();
						update.writeTofile($"Programm add: {Programm.ProgramId}", ComputerId);
						var ComputerToProgramms = new ComputersToProgramms()
						{
							Programms = Programm,
							Computer = ComputerInfo
						};

						await _context.ComputersToProgramms.AddAsync(ComputerToProgramms);
						await _context.SaveChangesAsync();
					}
				}
				for (int i = 0; i < computer.ProgramVolume.Count; i++)
				{
		
					if (computer.ProgramName[i] != AgentInfo.ProgramName[i])
					{
						update = new UpdateService();
						computer.ProgramName[i] = AgentInfo.ProgramName[i];
						update.writeTofile($"Update Programms Name: {computer.ProgramName[i]}", ComputerId);
					}

					if (computer.ProgramFirstdownloadDate[i] != AgentInfo.ProgramFirstdownloadDate[i])
					{
						update = new UpdateService();
						computer.ProgramFirstdownloadDate[i] = AgentInfo.ProgramFirstdownloadDate[i];
						update.writeTofile($"Update Programms FirstdownloadDate: {computer.ProgramFirstdownloadDate[i]}", ComputerId);
					}

					if (computer.ProgramVolume[i] != AgentInfo.ProgramVolume[i])
					{
						update = new UpdateService();
						computer.ProgramVolume[i] = AgentInfo.ProgramVolume[i];
						update.writeTofile($"Update Programms Name: {computer.ProgramVolume[i]}", ComputerId);
					}

					var Programm = new Programms()
					{
						Name = AgentInfo.ProgramName[i],
						FirstdownloadDate = AgentInfo.ProgramFirstdownloadDate[i],
						Volume = AgentInfo.ProgramVolume[i]
					};


					_context.Programs.Update(Programm);
					await _context.SaveChangesAsync();
				}
			}

			if (AgentInfo.NetworkCardName != null)
			{

				if (computer.Speed != AgentInfo.Speed)
				{
					update = new UpdateService();
					computer.Speed = AgentInfo.Speed;
					update.writeTofile($"Update NetworkCard Speed: {AgentInfo.Speed}", ComputerId);
				}

				if (computer.MACAddress != AgentInfo.MACAddress)
				{
					update = new UpdateService();
					computer.MACAddress = AgentInfo.MACAddress;
					update.writeTofile($"Update NetworkCard MACAddress: {AgentInfo.MACAddress}", ComputerId);
				}

				if (computer.Specification != AgentInfo.Specification )
				{
					update = new UpdateService();
					computer.Specification = AgentInfo.Specification;
					update.writeTofile($"Update NetworkCard Specification: {AgentInfo.Specification}", ComputerId);
				}

				if (computer.NetworkCardName != AgentInfo.NetworkCardName)
				{
					update = new UpdateService();
					computer.NetworkCardName = AgentInfo.NetworkCardName;
					update.writeTofile($"Update NetworkCard Name: {computer.NetworkCardName}", ComputerId);
				}

				var NetworkCard = new NetworkCard()
				{
					MACAddress = AgentInfo.MACAddress,
					Speed = AgentInfo.Speed,
					Specification = AgentInfo.Specification,
					Name = AgentInfo.NetworkCardName,
					ComputerInfo = ComputerInfo
				};

				_context.NetworkCard.Update(NetworkCard);
				await _context.SaveChangesAsync();
			}

			if (AgentInfo.MotherBoardName != null)
			{

				if (computer.Socket != AgentInfo.Socket)
				{
					update = new UpdateService();
					computer.Socket = AgentInfo.Socket;
					update.writeTofile($"Update MotherBoard Socket: {computer.Socket}", ComputerId);
				}

				if (computer.FSBFrequncy != AgentInfo.FSBFrequncy)
				{
					update = new UpdateService();
					computer.FSBFrequncy = AgentInfo.FSBFrequncy;
					update.writeTofile($"Update MotherBoard FSBFrequency: {AgentInfo.FSBFrequncy}", ComputerId);
				}

				if (computer.RAMConnector != AgentInfo.RAMConnector)
				{
					update = new UpdateService();
					computer.RAMConnector = AgentInfo.RAMConnector;
					update.writeTofile($"Update MotherBoard RAMConnector: {AgentInfo.RAMConnector}", ComputerId);
				}


				var MotherBoard = new MotherBoard()
				{
					Socket = AgentInfo.Socket,
					FSBFrequency = AgentInfo.FSBFrequncy,
					RAMConnector = AgentInfo.RAMConnector,
					Name = AgentInfo.MotherBoardName,
					ComputerInfo = ComputerInfo
				};

				_context.MotherBoard.Update(MotherBoard);
				await _context.SaveChangesAsync();
			}

			if (AgentInfo.CPUName != null)
			{

				if (computer.CPUFrequncy != AgentInfo.CPUFrequncy)
				{
					update = new UpdateService();
					computer.CPUFrequncy= AgentInfo.CPUFrequncy;
					update.writeTofile($"Update CPU Frequency: {AgentInfo.CPUFrequncy}", ComputerId);
				}

				if (computer.CPUBitness != AgentInfo.CPUBitness)
				{
					update = new UpdateService();
					computer.CPUBitness = AgentInfo.CPUBitness;
					update.writeTofile($"Update CPU Bitness: {AgentInfo.CPUBitness}", ComputerId);
				}

				if (computer.CPUCacheMemory != AgentInfo.CPUCacheMemory)
				{
					update = new UpdateService();
					computer.CPUCacheMemory = AgentInfo.CPUCacheMemory;
					update.writeTofile($"Update CPU CacheMemory: {AgentInfo.CPUCacheMemory}", ComputerId);
				}

				if (computer.CPUName != AgentInfo.CPUName)
				{
					update = new UpdateService();
					computer.CPUName = AgentInfo.CPUName;
					update.writeTofile($"Update CPU Name: {computer.CPUName}", ComputerId);
				}

				if (computer.NumberOfCores != AgentInfo.NumberOfCores)
				{
					update = new UpdateService();
					computer.NumberOfCores = AgentInfo.NumberOfCores;
					update.writeTofile($"Update CPU NumberOfCores: {computer.NumberOfCores}",ComputerId);
				}
				var Cpu = new CPU()
				{
					Frequency = AgentInfo.CPUFrequncy,
					Bitness = AgentInfo.CPUBitness,
					CacheMemory = AgentInfo.CPUCacheMemory,
					Name = AgentInfo.CPUName,
					NumberOfCores = AgentInfo.NumberOfCores,
					ComputerInfo = ComputerInfo
				};
				_context.CPU.Update(Cpu);
				await _context.SaveChangesAsync();
			}

			if(AgentInfo.GpuName != null)
			{
				if (computer.GpuName.Count < AgentInfo.GpuName.Count)
				{
					for (int i = AgentInfo.GpuName.Count; i > computer.GpuName.Count; i--)
					{
						var Gpu = new GPU()
						{
							Frequency = AgentInfo.GpuFrequency[i],
							VolumeMemory = AgentInfo.VolumeMemory[i],
							Name = AgentInfo.GpuName[i]
						};

						await _context.Gpu.AddAsync(Gpu);
						await _context.SaveChangesAsync();

						var ComputerToGpu = new ComputersToGPU()
						{
							Gpu = Gpu,
							Computer = ComputerInfo
						};

						await _context.ComputersToGPU.AddAsync(ComputerToGpu);
						await _context.SaveChangesAsync();
						update = new UpdateService();
						update.writeTofile($"Add gpu: {Gpu.GPUId}", ComputerId);
					}
				}
				for (int i = 0; i < computer.GpuName.Count; i++)
				{

					if (computer.GpuFrequency[i] != AgentInfo.GpuFrequency[i])
					{
						update = new UpdateService();
						computer.GpuFrequency[i] = AgentInfo.GpuFrequency[i];
						update.writeTofile($"Update GPU Frequency: {computer.GpuFrequency[i]}", ComputerId);
					}

					if (computer.VolumeMemory[i] != AgentInfo.VolumeMemory[i])
					{
						update = new UpdateService();
						computer.VolumeMemory[i] = AgentInfo.VolumeMemory[i];
						update.writeTofile($"Update GPU VolumeMemory: {computer.VolumeMemory[i]}", ComputerId);
					}

					if (computer.GpuName[i]!= AgentInfo.GpuName[i])
					{
						update = new UpdateService();
						computer.GpuName[i] = AgentInfo.GpuName[i];
						update.writeTofile($"Update GPU VolumeMemory: {computer.GpuName[i]}", ComputerId);
					}

					var Gpu = new GPU()
					{
						Frequency = AgentInfo.GpuFrequency[i],
						VolumeMemory = AgentInfo.VolumeMemory[i],
						Name = AgentInfo.GpuName[i]
					};

					_context.Gpu.Update(Gpu);
					await _context.SaveChangesAsync();
				}
			}

		}
	}
}
