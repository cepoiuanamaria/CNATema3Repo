using Grpc.Core;
using Grpc.Net.Client;
using Server;
using Server.Protos;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title="Client";
            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new MessageReply.MessageReplyClient(channel);

            Console.Write("Name: ");

            var response = client.SayHello(new MessageRequest
            {
                Name = Console.ReadLine(),
            });
            Console.WriteLine(response.Message);

            // Shutdown
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
