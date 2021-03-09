using Microsoft.EntityFrameworkCore;
using ParcelamentoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Data
{
    public class ParcelamentoContext : DbContext
    {
        public ParcelamentoContext(DbContextOptions<ParcelamentoContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
