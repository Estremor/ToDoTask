using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using ToDoTask.Lambda.Entity;
using ToDoTask.Lambda.Repository;
using ToDoTask.Lambda.RequestModel;

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
        var taskId =  request.PathParameters?["id"];
        if (string.IsNullOrWhiteSpace(taskId))
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = 404,
                Body = JsonSerializer.Serialize(request),
                Headers = Options.GetHeaders()
            };
        }
        await _repository.DeleteAsync<TaskEntity>(taskId);

        return new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Body = JsonSerializer.Serialize(new { ok = "Ok"}),
            Headers = Options.GetHeaders()
        };
    }
}
