using Amazon.DynamoDBv2;
using Microsoft.Extensions.DependencyInjection;
using ToDoTask.Lambda.Repository;

namespace ToDoTask.Lambda
{
    public static class Options
    {
        public static Dictionary<string, string> GetHeaders()
        {
            return new Dictionary<string, string> {
                { "Content-Type", "application/json" },
                { "Access-Control-Allow-Origin","http://localhost:4200"},
                { "Access-Control-Allow-Headers","Content-Type"},
                { "Access-Control-Allow-Methods","GET, POST, DELETE, OPTIONS"}
            };
        }
    }
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
