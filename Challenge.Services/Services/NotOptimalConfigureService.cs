using Challenge.DTOs;
using Challenge.Services.Contracts;
using System.Collections.Generic;
using System.Text;

namespace Challenge.Services.Services
{
    public class NotOptimalConfigureService : IConfigureService
    {
        public IList<string> GetListConfiguration(int total, IList<TaskDto> foregroundTasks, IList<TaskDto> backgroundTasks)
        {
            return null;
        }

        public StringBuilder GetStringConfiguration(int total, IList<TaskDto> foregroundTasks, IList<TaskDto> backgroundTasks)
        {
            return new StringBuilder("");
        }
    }
}
