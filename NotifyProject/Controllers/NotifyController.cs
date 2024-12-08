using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotifyProject.Hubs;
using NotifyProject.Model.Delivery;

namespace NotifyProject.Controllers
{
    [Route("api/notify")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private INotify notify;

        public NotifyController(INotify notify)
        {
            this.notify = notify;
        }
        [HttpPost]
        public async Task<IActionResult> enteredDelivery(NotifyModel notifyModel)
        {
            return Ok(await notify.SetNotify(notifyModel));
        }
    }
}
