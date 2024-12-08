using Microsoft.AspNetCore.SignalR;
using NotifyProject.Model.Delivery;
using System.Linq;

namespace NotifyProject.Hubs
{
    public class Notify : INotify
    {
        private readonly IHubContext<NotifyHub> notify;

        public Notify(IHubContext<NotifyHub> notify)
        {
            this.notify = notify;
        }



        public async Task<bool> SetNotify(NotifyModel notifyreg)        
        {
            if(Statichub.cnctd.Any(x=>x.uuid == notifyreg.userid))
            {
               await notify.Clients
                   .Client(Statichub.cnctd.FirstOrDefault(x => x.uuid == notifyreg.userid).conid)
                  .SendAsync(notifyreg.metodname , notifyreg.content);
                return true;
            }
            return false;


        }

}

}

