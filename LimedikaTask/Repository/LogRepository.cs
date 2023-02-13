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
    public class LogRepository
    {
        private readonly DataContext _context;

        public LogRepository(DataContext context)
        {
            _context = context;
        }

        public void UpdateLogs(PharmacyDetails pharmacy)
        {
            if (_context.Log.ToList().Select(x=> x.PharmacyId).Contains(pharmacy.Id))
            {
                var logToUpdate = _context.Log.FirstOrDefault(x => x.PharmacyId == pharmacy.Id);
                logToUpdate.UpdatedPostCode = DateTime.Now;
                _context.Entry(logToUpdate).State = EntityState.Modified;
            }
            else
            {
                _context.Log.Add(new LogModel
                {
                    PharmacyId = pharmacy.Id,
                    CreatedDate = DateTime.Now
                });
            }
            _context.SaveChanges();
        }
    }
}
