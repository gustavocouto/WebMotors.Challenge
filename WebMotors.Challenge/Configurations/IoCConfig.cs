using Microsoft.Extensions.DependencyInjection;
using WebMotors.Challenge.Application.AppServices;
using WebMotors.Challenge.Application.Interfaces;
using WebMotors.Challenge.Domain.Interfaces.Repositories;
using WebMotors.Challenge.Infra;
using WebMotors.Challenge.Infra.OnlineChallenge;

namespace WebMotors.Challenge.Configurations
{
    public static class IoCConfig
    {
        public static void ConfigureIoC(this IServiceCollection services)
        {
            services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            services.AddScoped<IOnlineChallengeRepository, OnlineChallengeRepository>();

            services.AddScoped<IAnnouncementAppService, AnnouncementAppService>();
            services.AddScoped<IOnlineChallengeAppService, OnlineChallengeAppService>();
        }
    }
}