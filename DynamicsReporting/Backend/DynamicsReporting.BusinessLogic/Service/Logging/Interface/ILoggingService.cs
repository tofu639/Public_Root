namespace DynamicsReporting.BusinessLogic.Service.Logging.Interface
{
    public interface ILoggingService
    { 
        Task AddLoggingFailAsync(AddLogModel model);
    }
}