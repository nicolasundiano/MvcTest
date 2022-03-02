using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MvcTest.Application;

public static class ApplicationServiceRegistration
{
    public static void ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
    }
}