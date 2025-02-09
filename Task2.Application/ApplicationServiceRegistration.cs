using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Task1.Application.Mapper;
using Task1.Infrastructure.Services;
using Task2.Application.Repositories;
using Task2.Application.Services;

namespace Task2.Infrastructure
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddAutoMapper(typeof(MappingProfile));

        }
    }
}