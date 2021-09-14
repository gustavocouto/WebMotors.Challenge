using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.Challenge.Domain.Models;

namespace WebMotors.Challenge.Application.Interfaces
{
    public interface IAnnouncementAppService
    {
        Task<List<Announcement>> GetAllAnnouncement();
        Task<Announcement> GetAnnouncement(int id);
        Task CreateAnnouncement(Announcement announcement);
        Task UpdateAnnonucement(Announcement announcement);
        Task RemoveAnnouncement(int id);
    }
}