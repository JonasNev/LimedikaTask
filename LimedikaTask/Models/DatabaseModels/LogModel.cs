using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimedikaTask.Models.DatabaseModels
{
    public class LogModel
    {
        public int Id { get; set; }
        public int PharmacyId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedPostCode { get; set; }
    }
}
