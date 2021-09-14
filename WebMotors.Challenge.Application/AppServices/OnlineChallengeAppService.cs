using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.Challenge.Application.Interfaces;
using WebMotors.Challenge.Domain.Interfaces.Repositories;
using WebMotors.Challenge.Domain.Models;

namespace WebMotors.Challenge.Application.AppServices
{
    public class OnlineChallengeAppService : IOnlineChallengeAppService
    {
        private readonly IOnlineChallengeRepository _onlineChallengeRepository;

        public OnlineChallengeAppService(IOnlineChallengeRepository onlineChallengeRepository)
        {
            _onlineChallengeRepository = onlineChallengeRepository;
        }

        public Task<List<Make>> GetAllMakeAsync()
        {
            return _onlineChallengeRepository.GetAllMakeAsync();
        }

        public Task<List<Model>> GetAllModelAsync(int makeId)
        {
            return _onlineChallengeRepository.GetAllModelAsync(makeId);
        }

        public Task<List<Version>> GetAllVersionAsync(int modelId)
        {
            return _onlineChallengeRepository.GetAllVersionAsync(modelId);
        }
    }
}