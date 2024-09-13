using ToDoTask.Lambda.Entity;

namespace ToDoTask.Lambda.RequestModel
{
    public class TaskRequest
    {
        public string taskId { get; set; }
        public string taskName { get; set; }
        public string taskDescription { get; set; }
        public bool isDone { get; set; }
        public DateTime endDate { get; set; }

        public TaskEntity ToEntity()
        {
            return new TaskEntity
            {
                Id = Guid.NewGuid().ToString(),
                TaskName = taskName,
                IsDone = isDone,
                TaskDescription = taskDescription,
                EndDate = endDate,
            };
        }
    }
}
