using API_DSCS2_WEBBANGIAY.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Threading.Tasks;
namespace API_DSCS2_WEBBANGIAY.Hubs
{
    public class RoomMessageHub:Hub
    {
        private readonly ShoesEcommereContext _context;
        public RoomMessageHub(ShoesEcommereContext context)
        {
            _context = context;
        }

        public async Task SendMessage(string user, string message)
        {
            try
            {
                var data =  await _context.Messages.Include(x=>x.Messages).ToListAsync();
                var response =  JsonConvert.SerializeObject(data);
                await Clients.All.SendAsync("ReceiveMessage", response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //public async Task AddToGroup(RoomMessage room)
        //{
            
        //    await Groups.AddToGroupAsync(Context.ConnectionId, room.MaSP);

        //    await Clients.Group(room.MaSP).SendAsync("Send", $"{Context.ConnectionId} has joined the group {room.MaSP}.");
        //}
        //public async Task RemoveFromGroup(RoomMessage room)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, room.MaSP);

        //    await Clients.Group(room.MaSP).SendAsync("Send", $"{Context.ConnectionId} has left the group {room.MaSP}.");
        //}
        //public async Task SendMessageToGroup(RoomMessage room)
        //{
            
        //}
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
