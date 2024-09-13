using Amazon.Lambda.Core;
using Microsoft.Extensions.DependencyInjection;
using ToDoTask.Lambda.Entity;
using ToDoTask.Lambda.Repository;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace ToDoTask.Lambda;

public class Function
{
    #region property

    private readonly IRepository<TaskEntity> _repository;

    #endregion

    public Function()
    {
        _repository = Configuration
            .ConfigureServices()
            .GetRequiredService<IRepository<TaskEntity>>();
    }


    /// <summary>
    /// A simple function that takes a string and does a ToUpper
    /// </summary>
    /// <param name="input">The event for the Lambda function handler to process.</param>
    /// <param name="context">The ILambdaContext that provides methods for logging and describing the Lambda environment.</param>
    /// <returns></returns>
    public string CreateFunctioHandler(string input, ILambdaContext context)
    {
        return input.ToUpper();
    }
}
