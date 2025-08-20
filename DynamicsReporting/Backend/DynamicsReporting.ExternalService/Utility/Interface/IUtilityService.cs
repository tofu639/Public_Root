using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsReporting.ExternalService.Utility.Interface
{

    interface IUtilityService
    {
        string GetLocalIPAddress();
        string GetSection(string sectionName);
    }
}
