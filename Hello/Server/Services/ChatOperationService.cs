using Grpc.Core;
using Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    //internal class ChatOperationService : MessageReply.MessageReplyBase
    //{
    public class ChatOperationService : ChatRooms.ChatRoomsBase
    {
        private readonly ChatRoom _chatroomService;

        public ChatOperationService(ChatRoom chatRoomService)
        {
            _chatroomService = chatRoomService;
        }

        //override la rpc-ul join din chat.proto
        public override async Task join(IAsyncStreamReader<Message> requestStream, IServerStreamWriter<Message> responseStream, ServerCallContext context)
        {
            if (!await requestStream.MoveNext())
                return;
            do
            {
                _chatroomService.Join(requestStream.Current.User, responseStream);
                await _chatroomService.BroadcastMessageAsync(requestStream.Current);
            } while (await requestStream.MoveNext());
            _chatroomService.Remove(context.Peer);
        }
        //public override Task<OperationResponse> SayHello(MessageRequest request, ServerCallContext context)
        //{
        //    System.Console.WriteLine("wazzup my nigga " + request.Name);

        //    var message = "";

        //    return Task.FromResult(new OperationResponse() { Message = message });
        //}
    }
}
