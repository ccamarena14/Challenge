using Challenge.DTOs;
using System;
using System.Collections.Generic;

namespace Challenge.Services.Services
{
    public class TaskService
    {
        /// <summary>
        /// Get taks from array
        /// </summary>
        /// <param name="arrData">Array with data</param>
        /// <returns></returns>
        public static IList<TaskDto> GetTasks(string[] arrData)
        {
            try
            {
                var listado = new List<TaskDto>();
                foreach (var item in arrData)
                {
                    string[] items = item.Split(',');
                    listado.Add(new TaskDto(int.Parse(items[0]), int.Parse(items[1])));
                }
                return listado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get taks. {ex.Message}");
                return null;
            }
           
        }
    }
}
