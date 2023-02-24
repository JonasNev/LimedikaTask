using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimedikaTask.Models.JsonModels
{
    public class JsonPharmacyModel
    {
        public class RootObject
        {
            public Pharmacy[]? PharmacyList { get; set; }
        }

        public class Pharmacy
        {
            public string? Name { get; set; }
            public string? Address { get; set; }
            public string? PostCode { get; set; }
        }

    }
}
