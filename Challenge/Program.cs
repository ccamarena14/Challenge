using Challenge.Common;
using Challenge.Common.Enums;
using Challenge.Services.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge
{
    public class Program
    {
        static void Main(string[] args)
        {
           StartChallenge().Wait();
           Console.ReadLine();
        }

        /// <summary>
        /// Starts challenge
        /// </summary>
        /// <returns></returns>
        private static async Task StartChallenge()
        {
            try
            {
                Console.Write("Enter file path: ");
                var path = Console.ReadLine();

                if (!FileCommon.FileExists(ref path)) return;

                var dataFileList = await FileCommon.ReadFile(path);
                if (dataFileList == null) return;

                if (!FileCommon.ValidateFormatFile(dataFileList)) return;

                var devices = DeviceService.GetDevicesFromString(dataFileList.ToList());
                if (devices == null) return;

                var outputConfigurationList = ConfigurationServices.GetOutputStringConfiguration(devices, ConfigurationServices.GetConfiguration(EnumConfiguration.Optimal));
                if (outputConfigurationList == null) return;

                await FileCommon.SaveFile(outputConfigurationList);
                
            }
            catch (Exception ex)
            {
                Console.Write($"Error starting the challenge. {ex.Message}");
            }
        }
    }
}
