using System;
using Client;
using Grpc.Core;

namespace Server
{
    class Program
    {
        const string Host = "localhost";
        const int Port = 16842;

        public static void Main(string[] args)
        {
            var grpcServer = new Grpc.Core.Server
            {
                Services = { ChatService.BindService(new ChatImplementation()) },
                Ports = { new ServerPort(Host, Port, ServerCredentials.Insecure) }
            };

            grpcServer.Start();

            Console.WriteLine("Port: " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            grpcServer.ShutdownAsync().Wait();
        }
    }

   
}
