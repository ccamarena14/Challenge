namespace Challenge.DTOs
{
    /// <summary>
    /// Dto with task information
    /// </summary>
    public class TaskDto
    {
        public int Id { get; set; }
        public int Resources { get; set; }

        public TaskDto(int taskId, int resources)
        {
            Id = taskId;
            Resources = resources;
        }
    }
}
