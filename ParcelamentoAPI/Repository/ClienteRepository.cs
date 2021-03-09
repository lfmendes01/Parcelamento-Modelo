using ParcelamentoAPI.Dto.Cliente;
using ParcelamentoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Repository
{
    public class ClienteRepository : IClienteRepository
    {

        ParcelamentoMemoryContext db;
        public ClienteRepository(ParcelamentoMemoryContext _db)
        {
            db = _db;
        }
        public  ClienteDto Get(int id)
        {
            if (db != null)
            {
                var query = db.Cliente.Where(c => c.IdCliente == id);

                var dto = query.Select(a => new ClienteDto()
                {
                    Id = a.IdCliente,
                    Nome = a.Nome
                }).FirstOrDefault();

                return dto;
            }
            return null;
        }

        public int Add(ClienteDto dto)
        {
            if (db != null)
            {
                Cliente entidade = new Cliente()
                {
                    Nome = dto.Nome
                };

                db.Cliente.Add(entidade);
                db.SaveChanges();

                return entidade.IdCliente;
            }

            return 0;
        }

    }
}
