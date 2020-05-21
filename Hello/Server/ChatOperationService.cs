using Generated;
using Grpc.Core;
using System.Threading.Tasks;

namespace Server
{
    internal class GreetOperationService : Generated.MessageReply.MessageReplyBase
    {
        public override Task<OperationResponse> SayHello(MessageRequest request, ServerCallContext context)
        {
            System.Console.WriteLine("wazzup my nigga " + request.Name);

            var message = "";

            return Task.FromResult(new OperationResponse() { Message = message });
        }
    }
}
