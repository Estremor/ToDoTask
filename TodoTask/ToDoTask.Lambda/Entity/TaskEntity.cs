using Amazon.DynamoDBv2.DataModel;

namespace ToDoTask.Lambda.Entity
{
    public class EntitBase
    {
        [DynamoDBHashKey]
        [DynamoDBProperty("id")]
        public string Id { get; set; }
    }

    [DynamoDBTable("tasktodos")]
    public class TaskEntity : EntitBase
    {
        [DynamoDBProperty("taskName")]
        public string TaskName { get; set; }

        [DynamoDBProperty("taskDescription")]
        public string TaskDescription { get; set; }

        [DynamoDBProperty("creationDate")]
        public DateTime CreationDate { get; set; }
    }
}
