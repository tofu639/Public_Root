
using DynamicsReporting.DataAccess.Repository.Authentication;
using DynamicsReporting.DataAccess.Repository.Authentication.Interface;
using DynamicsReporting.DataAccess.Repository.Group;
using DynamicsReporting.DataAccess.Repository.Group.Interface;
using DynamicsReporting.DataAccess.Repository.Logging;
using DynamicsReporting.DataAccess.Repository.Report;
using DynamicsReporting.DataAccess.Repository.Report.Interface;
using DynamicsReporting.DataAccess.Repository.User;
using DynamicsReporting.DataAccess.Repository.User.Interface;
using DynamicsReporting.ExternalService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


public static class ServiceRegistrationExtension
{


    public static IServiceCollection AddCustomDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        //services.AddTransient<IDynamicsReportingRepository, DynamicsReportingRepository>();
        //try
        //{
        //    services.AddTransient<IDatabaseConnection>(sp =>
        //        new DatabaseConnection(sp.GetRequiredService<IConfiguration>().GetConnectionString("APPConnection")));
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine("Error registering DB connection: " + ex);
        //    throw;
        //}


       // services.AddSingleton<Utility>();
        services.AddSingleton<IConfiguration>(configuration);
        services.AddTransient<ILoggingRepository, LoggingRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<IGroupRepository, GroupRepository>();
        services.AddTransient<IReportRepository, ReportRepository>();
        services.AddTransient<IAuthenRepository, AuthenRepository>();


        return services;
    }



}
