using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Grpc.Core;

namespace Server
{
    public class ChatServiceImpl : ChatService.ChatServiceBase
    {
        private static HashSet<IServerStreamWriter<ChatMessageFromServer>> responseStreams = new HashSet<IServerStreamWriter<ChatMessageFromServer>>();

        public override async Task chat(IAsyncStreamReader<ChatMessage> requestStream,
            IServerStreamWriter<ChatMessageFromServer> responseStream,
            ServerCallContext context)
        {

            responseStreams.Add(responseStream);

            while (await requestStream.MoveNext(CancellationToken.None))
            {
                var messageFromClient = requestStream.Current;
                var message = new ChatMessageFromServer
                {
                    Message = messageFromClient
                };

                foreach (var stream in responseStreams)
                {
                    await stream.WriteAsync(message);
                }
            }
        }
    }
}
