using LimedikaTask.Models.DatabaseModels;
using LimedikaTask.Models.JsonModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimedikaTask.Repository
{
    public interface IClientRepository
    {
        List<PharmacyDetails> GetAll();
        PharmacyDetails GetByAdress(string adress);
        void UpdateList(List<JsonPharmacyModel.Pharmacy> clientList);
        void Update(PharmacyDetails pharmacy);
    }
}
