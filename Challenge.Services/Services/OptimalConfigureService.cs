using Challenge.DTOs;
using Challenge.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Challenge.Services.Services
{
    public class OptimalConfigureService : IConfigureService
    {
        /// <summary>
        /// Get Optimal configuration string for device
        /// </summary>
        /// <param name="capacity">Capacity of device</param>
        /// <param name="foregroundTasks">Resoruces in foreground tasks</param>
        /// <param name="backgroundTasks">Resoruces in background tasks</param>
        /// <returns>Configuration string</returns>
        public StringBuilder GetStringConfiguration(int capacity, IList<TaskDto> foregroundTasks, IList<TaskDto> backgroundTasks)
        {
            try
            {
                var optimalConfigurations = new List<OptimalConfigureDto>();
                foreach (var foregroundTask in foregroundTasks)
                {
                    foreach (var backgroundTask in backgroundTasks)
                    {
                        optimalConfigurations.Add(new OptimalConfigureDto(foregroundTask.Id, backgroundTask.Id, foregroundTask.Resources + backgroundTask.Resources));
                    }
                }
                var closestToCapacity = optimalConfigurations.Where(x => x.SumResources <= capacity).OrderByDescending(x => x.SumResources).First().SumResources;
                var optimalList = optimalConfigurations.Where(z => z.SumResources == closestToCapacity);
                var outputString = new StringBuilder();
                foreach (var optimal in optimalList)
                {
                    outputString.Append($"({optimal.TaskForegorundId}, {optimal.TaskBackgroundId}),");
                }
                return outputString.Remove(outputString.Length - 1, 1);
            }
            catch (Exception ex)
            {
                Console.Write($"Error getting optimal setting. {ex.Message}");
                return null;
            }

        }

        /// <summary>
        /// Get Optimal configuration list for device
        /// </summary>
        /// <param name="capacity">Capacity of device</param>
        /// <param name="foregroundTasks">Resoruces in foreground tasks</param>
        /// <param name="backgroundTasks">Resoruces in background tasks</param>
        /// <returns>Configuration list</returns>
        public IList<string> GetListConfiguration(int capacity, IList<TaskDto> foregroundTasks, IList<TaskDto> backgroundTasks)
        {
            try
            {
                var optimalConfigurations = new List<OptimalConfigureDto>();
                foreach (var foregroundTask in foregroundTasks)
                {
                    foreach (var backgroundTask in backgroundTasks)
                    {
                        optimalConfigurations.Add(new OptimalConfigureDto(foregroundTask.Id, backgroundTask.Id, foregroundTask.Resources + backgroundTask.Resources));
                    }
                }
                var closestToCapacity = optimalConfigurations.Where(x => x.SumResources <= capacity).OrderByDescending(x => x.SumResources).First().SumResources;
                var optimalList = optimalConfigurations.Where(z => z.SumResources == closestToCapacity);
                var outputList = new List<string>();
                foreach (var optimal in optimalList)
                {
                    outputList.Add($"({optimal.TaskForegorundId}, {optimal.TaskBackgroundId})");
                }
                return outputList;
            }
            catch (Exception ex)
            {
                Console.Write($"Error getting optimal setting. {ex.Message}");
                return null;
            }

        }

       
    }
}
