using EComm.Web.API.gRPC;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace EComm.Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ECommGrpc.ECommGrpcClient(channel);
            var reply = await client.GetProductAsync(new ProductRequest { Id = 1 });
            Console.WriteLine($"{reply.Id}: {reply.Name}");
        }
    }
}
