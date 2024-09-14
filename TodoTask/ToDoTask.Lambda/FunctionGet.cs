using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using ToDoTask.Lambda.Entity;
using ToDoTask.Lambda.Repository;

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

    public async Task<APIGatewayProxyResponse> GetTaskHandler(string Id, ILambdaContext context)
    {
        var task = await _repository.GetById(Id);
        if (task == null)
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = 404,
                Body = "Task not found"
            };
        }

        return new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Body = JsonSerializer.Serialize(task),
            Headers = new Dictionary<string, string> { { "Content-Type", "application/json" } }
        };
    }
}
