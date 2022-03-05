using DatingApp.API.Database.Repositories;
using DatingApp.API.Profiles;
using DatingApp.API.Services;
using DatingApp.DatingApp.API.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration){
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserLikeRepository, UserLikeRepository>();
            services.AddAutoMapper(typeof(UserMapperProfile).Assembly);

            return services;
        }
    }
}