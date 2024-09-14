using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using ToDoTask.Lambda.Entity;
using ToDoTask.Lambda.Repository;

namespace ToDoTask.Lambda;
public class FunctionDelete
{
    #region property

    private readonly IRepository<TaskEntity> _repository;

    #endregion

    #region C'tor

    public FunctionDelete()
    {
        _repository = Configuration
            .ConfigureServices()
            .GetRequiredService<IRepository<TaskEntity>>();
    }

    #endregion

    public async Task<APIGatewayProxyResponse> DeleteTaskHandler(APIGatewayProxyRequest request, ILambdaContext context)
    {
        var taskId = request.QueryStringParameters["id"];
        if (string.IsNullOrWhiteSpace(taskId))
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = 404,
                Body = "Task not found"
            };
        }
        await _repository.DeleteAsync(new TaskEntity { Id = taskId });

        return new APIGatewayProxyResponse
        {
            StatusCode = 204
        };
    }
}
