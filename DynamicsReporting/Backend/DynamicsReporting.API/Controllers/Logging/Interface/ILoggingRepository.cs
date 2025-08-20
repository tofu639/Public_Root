using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 
    public interface ILoggingRepository
    {
        Task<int> CreateLoggingFailAsync(LoggingFailModel log);


    }
 