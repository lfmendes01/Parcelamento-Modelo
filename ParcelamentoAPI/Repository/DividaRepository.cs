using ParcelamentoAPI.Dto.Cliente;
using ParcelamentoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Repository
{
    public class DividaRepository : IDividaRepository
    {

        ParcelamentoMemoryContext db;

        public DividaRepository(ParcelamentoMemoryContext _db)
        {
            db = _db;
        }
        public  List<ClienteDividaDto> GetByIdCliente(int idCliente)
        {
            if (db != null)
            {
                var query = db.Divida.Where(c => c.IdCliente == idCliente);

                var dto = query.Select(a => new ClienteDividaDto()
                {
                    IdDivida = a.IdDivida,
                    ValorDivida = a.ValorDivida,
                    DataVencimento = a.DataVencimento,
                    IdCliente = a.IdCliente
                }).ToList();

                return dto;
            }
            return null;
        }

        public int Add(ClienteDividaDto dto)
        {
            if (db != null)
            {
                Divida entidade = new Divida()
                {
                    IdDivida = dto.IdDivida,
                    ValorDivida = dto.ValorDivida,
                    DataVencimento = dto.DataVencimento,
                    IdCliente = dto.IdCliente
                };

                db.Divida.Add(entidade);
                db.SaveChanges();

                return entidade.IdDivida;
            }

            return 0;
        }

        public int Update(ClienteParcelamentoDto dto)
        {
            if (db != null)
            {
                Divida entidade = db.Divida.Where( c=> c.IdDivida == dto.IdDivida).FirstOrDefault();

                entidade.NumeroParcelas = dto.NumeroParcelas;
                entidade.ValorComissao = dto.ValorComissao;
                entidade.ValorFinal = dto.ValorTotal;
                entidade.ValorJuros = dto.ValorJuros;

                db.Divida.Add(entidade);
                db.SaveChanges();

                return entidade.IdDivida;
            }

            return 0;
        }
    }
}
