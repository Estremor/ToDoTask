using ToDoTask.Lambda.Entity;

namespace ToDoTask.Lambda.RequestModel
{
    public class TaskResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isDone { get; set; }
        public DateTime endDate { get; set; }
        public TaskResponse GetResponse(TaskEntity entity)
        {
            return new TaskResponse
            {
                Id = entity.Id,
                Name = entity.TaskName,
                Description = entity.TaskDescription,
                isDone = entity.IsDone,
                endDate = entity.EndDate,
            };
        }
    }
}
