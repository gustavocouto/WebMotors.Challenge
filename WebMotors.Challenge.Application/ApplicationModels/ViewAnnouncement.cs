using WebMotors.Challenge.Domain.Models;

namespace WebMotors.Challenge.Application.ApplicationModels
{
    public class ViewAnnouncement : Announcement
    {
        public int MakeName { get; set; }
        public int ModelName { get; set; }
        public int VersionName { get; set; }
    }
}
