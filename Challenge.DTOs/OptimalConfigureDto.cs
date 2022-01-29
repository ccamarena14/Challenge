namespace Challenge.DTOs
{
    /// <summary>
    /// Dto with optimal configuration 
    /// </summary>
    public class OptimalConfigureDto
    {
        public int TaskForegorundId { get; set; }
        public int TaskBackgroundId { get; set; }
        public int SumResources { get; set; }

        public OptimalConfigureDto(int taskForegorundId, int taskBackgroundId, int sumResources)
        {
            TaskForegorundId = taskForegorundId;
            TaskBackgroundId = taskBackgroundId;
            SumResources = sumResources;
        }
    }
}
