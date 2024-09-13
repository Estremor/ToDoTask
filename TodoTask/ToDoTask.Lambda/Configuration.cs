using Amazon.DynamoDBv2;
using Microsoft.Extensions.DependencyInjection;
using ToDoTask.Lambda.Repository;

namespace ToDoTask.Lambda
{
    internal static class Configuration
    {
        internal static IServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<AmazonDynamoDBClient>();
            serviceCollection.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            return serviceCollection.BuildServiceProvider();
        }
    }
}
