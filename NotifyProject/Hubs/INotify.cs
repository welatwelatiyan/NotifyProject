using NotifyProject.Model.Delivery;

namespace NotifyProject.Hubs
{
    public interface INotify
    {
        Task<bool> SetNotify(NotifyModel notifyreg);
    }
}
