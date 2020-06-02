using Grpc.Core;
using System.Threading;

namespace Client
{
    public static class ChatImplementation
    { 
      const string Host = "localhost";
      const int Port = 16842;

        private static ChatService.ChatServiceClient _chatService;
            private static AsyncDuplexStreamingCall<ChatMessage, ChatMessageFromServer> _call;

            public static string ClientName;

        static ChatImplementation()
        {
            // Create a channel
            var channel = new Channel(Host + ":" + Port, ChannelCredentials.Insecure);

            // Create a client with the channel
            _chatService = new ChatService.ChatServiceClient(channel);

            openConnectionServer();
        }

        public static async void openConnectionServer()
        {
            // Open a connection to the server
            try
            {
                using (_call = _chatService.chat())
                {
                    // Read messages from the response stream
                    while (await _call.ResponseStream.MoveNext(CancellationToken.None))
                    {
                        var serverMessage = _call.ResponseStream.Current;
                        var otherClientMessage = serverMessage.Message;

                        Message.RecieveMessage(otherClientMessage.From, otherClientMessage.Message);
                    }
                }
            }
            catch (RpcException)
            {
                _call = null;
                throw;
            }
        }

        public static async void sendButton_Execute(string clientMessage)
        {
            // Create a chat message
            var message = new ChatMessage
            {
                From = ClientName,
                Message = clientMessage
            };
            // Send the message

            if (_call != null)
            {
                await _call.RequestStream.WriteAsync(message);
            }
        }

        public static void ChatClosing()
        {
            _call.RequestStream.CompleteAsync();
        }
    }

}

