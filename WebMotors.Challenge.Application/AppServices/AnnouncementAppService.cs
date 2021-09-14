using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.Challenge.Application.ApplicationModels;
using WebMotors.Challenge.Application.Interfaces;
using WebMotors.Challenge.Domain.Interfaces.Repositories;
using WebMotors.Challenge.Domain.Models;

namespace WebMotors.Challenge.Application.AppServices
{
    public class AnnouncementAppService : IAnnouncementAppService
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IOnlineChallengeRepository _onlineChallengeRepository;

        public AnnouncementAppService(IAnnouncementRepository announcementRepository, IOnlineChallengeRepository onlineChallengeRepository)
        {
            _announcementRepository = announcementRepository;
            _onlineChallengeRepository = onlineChallengeRepository;
        }

        public Task CreateAnnouncement(Announcement announcement)
        {
            return _announcementRepository.Create(announcement);
        }

        public Task<List<Announcement>> GetAllAnnouncement()
        {
            return _announcementRepository.GetAll();
        }

        public Task<Announcement> GetAnnouncement(int id)
        {
            return _announcementRepository.Get(id);
        }

        public Task RemoveAnnouncement(int id)
        {
            return _announcementRepository.Remove(id);
        }

        public Task UpdateAnnonucement(Announcement announcement)
        {
            return _announcementRepository.Update(announcement);
        }
    }
}