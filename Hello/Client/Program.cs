using Grpc.Core;
using Grpc.Net.Client;
using Server;
using Server.Protos;
using System;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace Client
{
    class Program
    {
        //static void Main(string[] args)
        //{
        //    Console.Title = "Client";
        //    var channel = GrpcChannel.ForAddress("https://localhost:5001");

        //    var client1 = new MessageReply.MessageReplyClient(channel);

        //    Console.Write("Name1: ");

        //    var response1 = client1.SayHello(new MessageRequest
        //    {
        //        Name = Console.ReadLine(),
        //    });
        //    Console.WriteLine(response1.Message);

        //    var client2 = new MessageReply.MessageReplyClient(channel);

        //    Console.Write("Name2: ");

        //    var response2 = client2.SayHello(new MessageRequest
        //    {
        //        Name = Console.ReadLine(),
        //    });
        //    Console.WriteLine(response2.Message);

        //    // Shutdown
        //    channel.ShutdownAsync().Wait();
        //    Console.WriteLine("Press any key to exit...");
        //    Console.ReadKey();
        //}
        static async Task Main(string[] args)
        {
            Console.Title = "Client";
            Console.Write("Username: ");
            var userName = Console.ReadLine();
            //Include portul serverului grpc ca si argument al aplicatiei
            var port = args.Length > 0 ? args[0] : "5001";

            var channel = GrpcChannel.ForAddress("https://localhost:" + port);
            var client = new ChatRooms.ChatRoomsClient(channel);

            using (var chat = client.join())
            {
                _ = Task.Run(async () =>
                {
                    while (await chat.ResponseStream.MoveNext(cancellationToken: CancellationToken.None))
                    {
                        var response = chat.ResponseStream.Current;
                        Console.WriteLine($"{response.User}: {response.Text}");
                    }
                });

                await chat.RequestStream.WriteAsync(new Message { User = userName, Text = $"{userName} has joined the room" });

                //string line;
                while (true)
                {
                    var line = Console.ReadLine();
                    if (line.ToLower() == "bye")
                    {
                        break;
                    }
                    await chat.RequestStream.WriteAsync(new Message { User = userName, Text = line });
                }
                await chat.RequestStream.CompleteAsync();
            }
            Console.WriteLine("Disconnecting");
            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

    }
}
