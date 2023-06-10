using System.Reflection;
using App.Shared.Uow;
using Castle.MicroKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.Contexts;
using ToDo.Infrastructure.Repositories;
using ToDo.Application.CommandHandlers;
using ToDo.Domain.ICommands;
using ToDo.Domain.Repositories;
using ToDo.Infrastructure.Repositories;
using ToDo.Domain.Entities;
using ToDo.Infrastruture.Repositories;

namespace ToDo.IOC;

public static class ToDoModule
{
    public static void Register(this IServiceCollection services)
    {
        
        services.AddScoped<IWorkRepository, WorkRepository>();
        services.AddScoped<IUserWorkRepository, UserWorkRepository>();
        services.AddScoped<IMediaTranmissionRepository, MediaTranmissionRepository>();
        services.AddScoped<IMediaWorkRepository, MediaWorkRepository>();

        services.AddScoped<IMaxUnitOfWork, UnitOfWork>();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddMediatR(typeof(CreateWorkWithNameHandler).GetTypeInfo().Assembly);
		services.AddMediatR(typeof(UpdateWorkByUserHandler).GetTypeInfo().Assembly);
		services.AddMediatR(typeof(DeleteWorkCommandHandler).GetTypeInfo().Assembly);
		services.AddMediatR(typeof(DeleteTaskOfWorkCommandHandler).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(CreateMediaCommandHandler).GetTypeInfo().Assembly);
		services.AddMediatR(typeof(UpdateMediaCommandHandler).GetTypeInfo().Assembly);
        services.AddMediatR(typeof(DeleteMediaCommandHandler).GetTypeInfo().Assembly);
	}

    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ToDoContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IImaxDbConext, ToDoContext>();
    }
}