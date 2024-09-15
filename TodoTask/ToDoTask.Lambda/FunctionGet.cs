using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using ToDoTask.Lambda.Entity;
using ToDoTask.Lambda.Repository;
using ToDoTask.Lambda.RequestModel;

namespace ToDoTask.Lambda;

public class FunctionGet
{
    #region property

    private readonly IRepository<TaskEntity> _repository;

    #endregion

    #region C'tor
    public FunctionGet()
    {
        _repository = Configuration
            .ConfigureServices()
            .GetRequiredService<IRepository<TaskEntity>>();
    }
    #endregion

    public async Task<APIGatewayProxyResponse> GetTaskHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        var id = request.QueryStringParameters?["Id"];
        if (string.IsNullOrWhiteSpace(id))
        {
            var taskListResult = await _repository.ListAsync();

            return new APIGatewayProxyResponse
            {
                StatusCode = 200,
                Body = JsonSerializer.Serialize(TaskResponse
                .GetResponse(taskListResult)),
                Headers = Options.GetHeaders()
            };
        }

        var task = await _repository.GetById(id);
        if (task == null)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = 404,
                Body = "Task not found",
                Headers = Options.GetHeaders()
            };
        }
        var response = TaskResponse.GetResponse(task);
        return new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Body = JsonSerializer.Serialize(response),
            Headers = Options.GetHeaders()
        };
    }
}
