using LimedikaTask.Data;
using LimedikaTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimedikaTask.Repository
{
    public class ClientRepository
    {
        private readonly DataContext _context;
        private readonly LogRepository _logRepository;

        public ClientRepository(DataContext context,LogRepository logRepository)
        {
            _context = context;
            _logRepository = logRepository;
        }

        public List<PharmacyDetails> GetAll()
        {
            return _context.PharmacyDetails.ToList();
        }

        public void UpdateList(List<JsonPharmacyModel.Pharmacy> clientList)
        {
            var allClients = _context.PharmacyDetails.Select(x => x.Address).ToList();
            foreach (var client in clientList)
            {
                if (!allClients.Contains(client.Address))
                {
                    _context.PharmacyDetails.Add(new PharmacyDetails()
                    {
                        Address = client.Address,
                        PostCode = client.PostCode,
                        Name = client.Name,
                    });
                    _context.SaveChanges();
                    _logRepository.UpdateLogs(_context.PharmacyDetails.FirstOrDefault(x => x.Address == client.Address));

                }
            }
        }

        public PharmacyDetails GetByAdress(string adress)
        {
            return _context.PharmacyDetails.ToList().FirstOrDefault(x => x.Address == adress);
        }

        public void Update(PharmacyDetails pharmacy)
        {
            var pharmacyToUpdate = _context.PharmacyDetails.FirstOrDefault(x => x.Id == pharmacy.Id);
            if (pharmacyToUpdate != null)
            {
                _context.Entry(pharmacyToUpdate).State = EntityState.Modified;
                _logRepository.UpdateLogs(pharmacyToUpdate);
            }
            _context.SaveChanges();
        }
    }
}
