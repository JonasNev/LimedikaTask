using LimedikaTask.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimedikaTask.Data
{
    public class DataContext : DbContext
    {
        public DbSet<PharmacyDetails> PharmacyDetails { get; set; }
        public DbSet<LogModel> Log { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
    }
}
