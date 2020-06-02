using Grpc.Core;
using Server.Protos;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public class ChatRoom
    {
        private ConcurrentDictionary<String, IServerStreamWriter<Message>> users = new ConcurrentDictionary<string, IServerStreamWriter<Message>>();
        //adauga useri 
        public void Join(string name, IServerStreamWriter<Message> response) => users.TryAdd(name, response);
        //scoate useri
        public void Remove(string name) => users.TryRemove(name, out var s);
        //trimite mesajele pe rand
        public async Task BroadcastMessageAsync(Message message) => await BroadcastMessages(message);

        //trimite mesajele de la fiecare user asteptand ca unul sa trimita primul, inainte sa trimita celalalt
        private async Task BroadcastMessages(Message message)
        {
            foreach (var user in users.Where(x => x.Key != message.User))
            {
                var item = await SendMessageToSubscriber(user, message);
                if (item != null)
                {
                    Remove(item?.Key);
                };
            }
        }
        //trimite mesajul catre subscriber
        private async Task<Nullable<KeyValuePair<string, IServerStreamWriter<Message>>>> SendMessageToSubscriber(KeyValuePair<string, IServerStreamWriter<Message>> user, Message message)
        {
            try
            {
                await user.Value.WriteAsync(message);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return user;
            }
        }
    }
}
