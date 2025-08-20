public interface ILoggingRepository
{
    Task AddLogAsync(AddLogModel log);
}