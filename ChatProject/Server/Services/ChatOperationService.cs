using Grpc.Core;
using Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    internal class ChatOperationService: MessageReply.MessageReplyBase
    {
        public override Task<OperationResponse> SayHello(MessageRequest request, ServerCallContext context)
        {
            System.Console.WriteLine("wazzup my nigga " + request.Name);

            var message = "";

            return Task.FromResult(new OperationResponse() { Message = message });
        }
    }
}
