using Generated;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{

    internal class HelloOperationService : Generated.HelloResponse.HelloResponseBase
    {
        public override Task<OperationResponse> SayHello(HelloRequest request, ServerCallContext context)
        {
            System.Console.WriteLine("Hello, " + request.Name + "!");
            var result = "";
            return Task.FromResult(new OperationResponse() { Message = result });
        }
    }

    class Server : IDisposable
    {


        public Grpc.Core.Server GrpcServer { get; private set; }

        public Action CloseServerAction { get; set; }




        public IEnumerable<Grpc.Core.ServerServiceDefinition> Services
        {
            get
            {
                yield return Generated.HelloResponse.BindService(new  HelloOperationService());

            }
        }

        public Server(string host, int port)
        {
            GrpcServer = new Grpc.Core.Server()
            {
                Ports = { new Grpc.Core.ServerPort(host, port, Grpc.Core.ServerCredentials.Insecure) }
            };

            LoadServices();
        }

        public void Start()
        {
            GrpcServer.Start();

            Console.WriteLine(string.Format("Server started ({0}:{1}).", Configuration.HOST, Configuration.PORT));
        }

        private void LoadServices()
        {
            Services.ToList().ForEach(service => GrpcServer.Services.Add(service));
        }

        public void Dispose()
        {
            CloseServerAction.Invoke();
            GrpcServer.ShutdownAsync().Wait();
            var port = GrpcServer.Ports.FirstOrDefault();
            Console.WriteLine("Server closed ({0}:{1}).", Configuration.HOST, Configuration.PORT);
        }
    }
}


