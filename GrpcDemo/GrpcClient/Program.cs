using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var greetClient = new Greeter.GreeterClient(channel);

            var input = new HelloRequest { Name = "Nayan" };
            var reply = await greetClient.SayHelloAsync(input);

            Console.WriteLine(reply.Message);

            Console.ReadKey();
        }
    }
}
