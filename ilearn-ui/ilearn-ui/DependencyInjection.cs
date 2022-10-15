using ilearn_ui.domain.Models;
using ilearn_ui.services;
using ilearn_ui.services.Utils;
using Microsoft.AspNetCore.HttpOverrides;

namespace ilearn_ui
{
    public static class DependencyInjection
    {

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IUserService, UserService>();
        }
    }
}