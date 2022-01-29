using Challenge.Common;
using Challenge.DTOs;
using System;
using System.Collections.Generic;

namespace Challenge.Services.Services
{
    public class DeviceService
    {
        /// <summary>
        /// Get the devices and their configuration
        /// </summary>
        /// <param name="data">List of data</param>
        /// <returns></returns>
        public static IEnumerable<DeviceDto> GetDevicesFromString(IList<string> data)
        {
            try
            {
                var devices = new List<DeviceDto>();
                for (int i = 0; i < data.Count; i += 3)
                {
                    var capacity = int.Parse(data[i]);
                    var foregroundTasks = TaskService.GetTasks(data[i + 1].Split(StringCommon.Instance.arrayDelimiter, StringSplitOptions.RemoveEmptyEntries));
                    if (foregroundTasks == null) return null;
                    var backgroundTasks = TaskService.GetTasks(data[i + 2].Split(StringCommon.Instance.arrayDelimiter, StringSplitOptions.RemoveEmptyEntries));
                    if (backgroundTasks == null) return null;
                    devices.Add(new DeviceDto(capacity, foregroundTasks, backgroundTasks));
                }
                return devices;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get devices. {ex.Message}");
                return null;
            }
        }
    }
}
