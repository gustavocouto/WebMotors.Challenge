using System.Collections.Generic;
using System.Threading.Tasks;
using WebMotors.Challenge.Domain.Models;

namespace WebMotors.Challenge.Domain.Interfaces.Repositories
{
    public interface IOnlineChallengeRepository
    {
        Task<List<Make>> GetAllMakeAsync();
        Task<List<Model>> GetAllModelAsync(int makeId);
        Task<List<Version>> GetAllVersionAsync(int modelId);
    }
}