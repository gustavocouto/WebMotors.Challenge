using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebMotors.Challenge.Domain.Interfaces.Repositories;
using WebMotors.Challenge.Domain.Models;

namespace WebMotors.Challenge.Infra.OnlineChallenge
{
    public class OnlineChallengeRepository : IOnlineChallengeRepository
    {
        private readonly HttpClient _httpClient;
        private readonly string _onlineChallengeAddress;

        public OnlineChallengeRepository(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _onlineChallengeAddress = configuration.GetConnectionString("OnlineChallengeApi");
        }

        private Task<string> GetStringAsync(string path)
        {
            return _httpClient.GetStringAsync($"{_onlineChallengeAddress}{path}");
        }

        public async Task<List<Make>> GetAllMakeAsync()
        {
            var response = await GetStringAsync("/Make");
            return JsonConvert.DeserializeObject<List<Make>>(response);
        }

        public async Task<List<Model>> GetAllModelAsync(int makeId)
        {
            var response = await GetStringAsync($"/Model?MakeID={makeId}");
            return JsonConvert.DeserializeObject<List<Model>>(response);
        }

        public async Task<List<Version>> GetAllVersionAsync(int modelId)
        {
            var response = await GetStringAsync($"/Version?ModelID={modelId}");
            return JsonConvert.DeserializeObject<List<Version>>(response);
        }
    }
}