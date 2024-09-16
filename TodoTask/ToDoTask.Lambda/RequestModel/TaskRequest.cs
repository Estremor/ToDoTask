using ToDoTask.Lambda.Entity;

namespace ToDoTask.Lambda.RequestModel
{
    public class TaskRequest
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public DateTime endDate { get; set; }

        public TaskEntity ToEntity()
        {
            return new TaskEntity
            {
                Id = Guid.NewGuid().ToString(),
                TaskName = name,
                TaskDescription = description,
                CreationDate = DateTime.Now,
            };
        }
    }
}
