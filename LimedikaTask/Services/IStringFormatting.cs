using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimedikaTask.Services
{
    public interface IStringFormatting
    {
        string CreateQuery(string address, string key, string baseUrl);
    }
}
