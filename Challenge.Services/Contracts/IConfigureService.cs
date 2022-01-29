using Challenge.DTOs;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Services.Contracts
{
    /// <summary>
    /// Interface for all configuration types
    /// </summary>
    public interface IConfigureService
    {
        IList<string> GetListConfiguration(int total, IList<TaskDto> foregroundTasks, IList<TaskDto> backgroundTasks);
        StringBuilder GetStringConfiguration(int total, IList<TaskDto> foregroundTasks, IList<TaskDto> backgroundTasks);
    }
}
