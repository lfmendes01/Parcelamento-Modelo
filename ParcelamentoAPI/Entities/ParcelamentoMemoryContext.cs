using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Entities
{
    public class ParcelamentoMemoryContext : DbContext
    {
        public ParcelamentoMemoryContext(DbContextOptions<ParcelamentoMemoryContext> options)
          : base(options)
        { }
        public DbSet<Parcelamento> Parcelamento { get; set; }
        public DbSet<Configuracao> Configuracao { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Divida> Divida { get; set; }
    }
}
