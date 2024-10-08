﻿using ToDoTask.Lambda.Entity;

namespace ToDoTask.Lambda.RequestModel
{
    public class TaskResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }

        public static List<TaskResponse> GetResponse(IEnumerable<TaskEntity> entity)
        {
            var response = new List<TaskResponse>();
            foreach (var item in entity)
                response.Add(new TaskResponse
                {
                    id = item.Id,
                    name = item.TaskName,
                    description = item.TaskDescription,
                });
            return response;
        }

        public static TaskResponse GetResponse(TaskEntity entity)
        {
            return new TaskResponse
            {
                id = entity.Id,
                name = entity.TaskName,
                description = entity.TaskDescription,
            };
        }
    }
}
