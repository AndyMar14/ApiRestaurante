using ApiRestaurante.Core.Application.Interfaces.Services;
using ApiRestaurante.Core.Application.Services;
using Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestaurante.Infrastructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            #region Services
            services.AddTransient(typeof(IGenericService<,,>), typeof(GenericService<,,>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IIngredientesService, IngredientesService>();
            services.AddTransient<IPlatosService, PlatosService>();
            services.AddTransient<IMesasService, MesasService>();
            #endregion
        }
    }
}
