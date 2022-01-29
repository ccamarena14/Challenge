using System.Collections.Generic;

namespace Challenge.DTOs
{
    /// <summary>
    /// DTO with device information
    /// </summary>
    public class DeviceDto
    {
        public int Capacity { get; set; }
        public IList<TaskDto> ForegroundTasks { get; set; }
        public IList<TaskDto> BackgroundTasks { get; set; }

        public DeviceDto(int capacity, IList<TaskDto> foregroundTasks, IList<TaskDto> backgroundTasks)
        {
            Capacity = capacity;
            ForegroundTasks = foregroundTasks;
            BackgroundTasks = backgroundTasks;
        }
    }
}
