using Grpc.Net.Client;
using Server;
using System;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Name: ");
            var name = Console.ReadLine();
            var input = new HelloRequest { Name = name };
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(input);
            Console.WriteLine(reply.Message);
            Console.ReadLine();
        }
    }
}
