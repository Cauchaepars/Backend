using DatabasesITRR.ModelsDto.Dto;
using ITRR.Database.Repositories.USBDevicesRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class USBDevicesController : Controller
    {
        private readonly IUSBDevicesRepository _usbDevicesRepository;

        public USBDevicesController(IUSBDevicesRepository usbDevicesRepository)
        {
            _usbDevicesRepository = usbDevicesRepository;
        }

        [HttpGet("{USBDevicesId}")]
        public async Task<IActionResult> GetUSBDevices(int USBDevicesId)
        {
            IActionResult response;
            try
            {
                var usbDevicesDto = await _usbDevicesRepository.GetUSBDevicesAsync(USBDevicesId);
                response = Ok(usbDevicesDto);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPost("{USBId}/{ComputerInfoId}")]
        public async Task<IActionResult> CreateGPU(int USBId, int ComputerInfoId)
        {
            IActionResult response;

            try
            {
                await _usbDevicesRepository.ComputersToUSBDevices(USBId, ComputerInfoId);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUSBDevices([FromBody] USBDevicesDto usbDevices)
        {
            IActionResult response;

            try
            {
                await _usbDevicesRepository.CreateUSBDevicesAsync(usbDevices);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpPut("{USBDevicesId}")]
        public async Task<IActionResult> UpdateUSBDevices(int USBDevicesId, [FromBody] USBDevicesDto usbDevices)
        {
            IActionResult response;

            try
            {
                await _usbDevicesRepository.UpdateUSBDevicesAsync(USBDevicesId, usbDevices);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }

        [HttpDelete("{USBDevicesId}")]
        public async Task<IActionResult> DeleteUSBDevices(int USBDevicesId)
        {
            IActionResult response;

            try
            {
                await _usbDevicesRepository.DeleteUSBDevicesAsync(USBDevicesId);
                response = StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                response = StatusCode(StatusCodes.Status500InternalServerError);
            }

            return response;
        }
    }
}