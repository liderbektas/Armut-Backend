using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;
using Test_Case.Models;

namespace Test_Case.Hubs
{
    public class ChatHub : Hub
    {
        private readonly LZ_Context _lzContext;

        public ChatHub(LZ_Context lzContext)
        {
            _lzContext = lzContext;
        }
        
        public static Dictionary<int, string> Users = new();

        public async Task Connect(int userId)
        {
            Users.Add(userId, Context.ConnectionId);
            var user = await _lzContext.Users.FindAsync(userId);
            
            await Clients.All.SendAsync("ReceiveMessage", user);
        }
    }
}
