using Challenge.Common.Enums;
using Challenge.DTOs;
using Challenge.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Services.Services
{
    public class ConfigurationServices
    {
        /// <summary>
        /// Gets ouput string configuration
        /// </summary>
        /// <param name="devices">Devices with tasks</param>
        /// <param name="configuration">Configuration type</param>
        /// <returns></returns>
        public static List<Tuple<int, StringBuilder>> GetOutputStringConfiguration(IEnumerable<DeviceDto> devices, IConfigureService configuration)
        {
            try
            {
                var outputConfigurationList = new List<Tuple<int, StringBuilder>>();
                foreach (var item in devices)
                {
                    var optimalConfiguration = configuration.GetStringConfiguration(item.Capacity, item.ForegroundTasks, item.BackgroundTasks);
                    if (optimalConfiguration == null) return null;
                    outputConfigurationList.Add(new Tuple<int, StringBuilder>(item.Capacity, optimalConfiguration));
                }
                return outputConfigurationList;
            }
            catch (Exception ex)
            {
                Console.Write($"Failed to get output configuration. {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Gets ouput List configuration
        /// </summary>
        /// <param name="devices">Devices with tasks</param>
        /// <param name="configuration">Configuration type</param>
        /// <returns></returns>
        public static List<Tuple<int, IList<string>>> GetOutputListConfiguration(IEnumerable<DeviceDto> devices, IConfigureService configuration)
        {
            try
            {
                var outputConfigurationList = new List<Tuple<int, IList<string>>>();
                foreach (var item in devices)
                {
                    var optimalConfiguration = configuration.GetListConfiguration(item.Capacity, item.ForegroundTasks, item.BackgroundTasks);
                    if (optimalConfiguration == null) return null;
                    outputConfigurationList.Add(new Tuple<int, IList<string>>(item.Capacity, optimalConfiguration));
                }
                return outputConfigurationList;
            }
            catch (Exception ex)
            {
                Console.Write($"Failed to get output configuration. {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Factory method to configuration
        /// </summary>
        /// <param name="configuration">Enum Configuration</param>
        /// <returns></returns>
        public static IConfigureService GetConfiguration(EnumConfiguration configuration)
        {
            IConfigureService configurationSelected;
            switch (configuration)
            {
                case EnumConfiguration.Optimal:
                    configurationSelected = new OptimalConfigureService();
                    break;
                case EnumConfiguration.NotOptimal:
                    configurationSelected = new NotOptimalConfigureService();
                    break;
                default:
                    configurationSelected = new OptimalConfigureService();
                    break;
            }
            return configurationSelected;
        }
    }
}
