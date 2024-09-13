namespace ToDoTask.Lambda.RequestModel
{
    public class TaskRequest
    {
        public string TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool IsDone { get; set; }
        public DateTime EndDate { get; set; }
    }
}
