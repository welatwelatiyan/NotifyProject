using NotifyProject.Model;

namespace NotifyProject.Hubs
{
    public class Statichub
    {
        public static List<ConnectionModel> cnctd { get; set; } = new List<ConnectionModel>();
    }
}
