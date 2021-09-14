using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.Challenge.Domain.Models;

namespace WebMotors.Challenge.Domain.Interfaces.Repositories
{
    public interface IAnnouncementRepository
    {
        Task<List<Announcement>> GetAll();
        Task<Announcement> Get(int id);
        Task Create(Announcement announcement);
        Task Update(Announcement announcement);
        Task Remove(int id);
    }
}