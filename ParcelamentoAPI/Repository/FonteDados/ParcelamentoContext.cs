using Microsoft.EntityFrameworkCore;
using ParcelamentoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Repository.FonteDados
{
    public class ParcelamentoContext : DbContext
    {

        public ParcelamentoContext()
        { }
        public ParcelamentoContext(DbContextOptions<ParcelamentoContext> options)
          : base(options)
        { }
        public DbSet<Parcelamento> Parcelamento { get; set; }
        public DbSet<Configuracao> Configuracao { get; set; }

        public DbSet<Cliente> Cliente { get; set; }
    }
}
