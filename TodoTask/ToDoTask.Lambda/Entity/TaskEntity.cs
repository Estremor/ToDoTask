namespace ToDoTask.Lambda.Entity
{
    public class TaskEntity
    {
        public string TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool IsDone { get; set; }
        public DateTime EndDate { get; set; }
    }
}
