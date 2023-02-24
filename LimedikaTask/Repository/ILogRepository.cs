using LimedikaTask.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimedikaTask.Repository
{
    public interface ILogRepository
    {
        void UpdateLogs(PharmacyDetails pharmacy);
    }
}
