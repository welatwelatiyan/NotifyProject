using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using NotifyProject.Model;
using System.Security.Claims;

namespace NotifyProject.Hubs
{
    [Authorize]
    public class NotifyHub : Hub
    {
     
        public override async Task OnConnectedAsync()
        {
            ClaimsPrincipal claims = Context.User;
            string id = claims.FindFirstValue("id");
            
            
            await base.OnConnectedAsync();
            await Clients.Client(Context.ConnectionId).SendAsync("receivemessage", "bağlandı");


            if (Statichub.cnctd.Any(x => x.uuid == id))
            {
                int indx = Statichub.cnctd.FindIndex(x => x.uuid == id);
                Statichub.cnctd[indx].conid = Context.ConnectionId;
            }
            else
                Statichub.cnctd.Add(new ConnectionModel
                {
                    conid = Context.ConnectionId,
                    uuid = id
                });
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            ClaimsPrincipal claims = Context.User;
            string id = claims.FindFirstValue("id");

            await base.OnDisconnectedAsync(exception);

            if(Statichub.cnctd.Any(y => y.uuid == id))
                Statichub.cnctd.Remove(Statichub.cnctd.FirstOrDefault(x => x.uuid == id));
        }

    }
}
