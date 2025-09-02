using DynamicsReporting.ExternalService.Service.Logging.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsReporting.ExternalService.Service.Logging
{
    public class LoggingService : ILoggingService
    {
        private readonly ILoggingRepository _loggingRepository;
        public LoggingService(ILoggingRepository loggingRepository)
        {
            _loggingRepository = loggingRepository;
        }
        public async Task AddLoggingFailAsync(AddLogModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Logging fail model cannot be null");
            }
            await _loggingRepository.AddLogAsync(model);
        }   

    }
}
