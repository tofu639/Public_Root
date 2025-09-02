namespace DynamicsReporting.ExternalService.Service.Logging.Interface
{
    public interface ILoggingService
    { 
        Task AddLoggingFailAsync(AddLogModel model);
    }
}