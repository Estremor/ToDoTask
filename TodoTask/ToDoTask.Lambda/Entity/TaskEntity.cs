namespace ToDoTask.Lambda.Entity
{
    public class EntitBase
    {
        public string Id { get; set; }
    }
    public class TaskEntity : EntitBase
    {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool IsDone { get; set; }
        public DateTime EndDate { get; set; }
    }
}
