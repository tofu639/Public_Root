
using DynamicsReporting.BusinessLogic.Service.Group;
using DynamicsReporting.BusinessLogic.Service.Group.Interface;
using DynamicsReporting.BusinessLogic.Service.User;
using DynamicsReporting.BusinessLogic.Service.User.Interface;
using DynamicsReporting.DataAccess.Repository.DatabaseConnection;
using DynamicsReporting.DataAccess.Repository.Logging;
using DynamicsReporting.ExternalService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DynamicsReporting.BusinessLogic.Service.Report.Interface;
using DynamicsReporting.BusinessLogic.Service.Report;
using DynamicsReporting.BusinessLogic.Service.Authentication.Interface;
using DynamicsReporting.BusinessLogic.Service.Authentication;


public static class ServiceRegistrationExtension
{
    public static IServiceCollection AddCustomBusinessLogicServices(this IServiceCollection services)
    {
        //services.AddTransient<IDynamicsReportingService, DynamicsReportingService>();
        //services.AddTransient<IDynamicsReportingRepository, DynamicsReportingRepository>();
        //services.AddTransient<ILoggingRepository, LoggingRepository>();
        //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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



        services.AddSingleton<Utility>();

        services.AddTransient<ILoggingRepository, LoggingRepository>();
        services.AddTransient<IReportService, ReportService>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IGroupService, GroupService>();
        services.AddTransient<IAuthenService, AuthenService>();


        return services;


    }

}
