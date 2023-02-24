using LimedikaTask.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimedikaTask.Services
{
    public interface IJsonReader
    {
        List<JsonPharmacyModel.Pharmacy>? ReadJson();
    }
}
