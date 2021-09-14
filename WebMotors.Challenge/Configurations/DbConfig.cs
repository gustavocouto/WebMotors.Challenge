using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebMotors.Challenge.Infra.Context;

namespace WebMotors.Challenge.Configurations
{
    public static class DbConfig
    {
        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebMotorsChallengeContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("WebMotorsChallenge")));
        }
    }
}