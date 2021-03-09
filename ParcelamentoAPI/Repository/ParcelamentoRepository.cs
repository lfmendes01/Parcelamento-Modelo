using ParcelamentoAPI.Dto.Cliente;
using ParcelamentoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Repository
{
    public class ParcelamentoRepository: IParcelamentoRepository
    {
        ParcelamentoMemoryContext db;
        public ParcelamentoRepository(ParcelamentoMemoryContext _db)
        {
            db = _db;
        }

        public int Add(ParcelasDto dto)
        {
            if (db != null)
            {
                Parcelamento entidade = new Parcelamento()
                {
                    IdDivida = dto.IdDivida,
                    NumeroParcela = dto.NumeroParcela,
                    ValorFinalParcela = dto.ValorParcela
                };

                db.Parcelamento.Add(entidade);
                db.SaveChanges();

                return entidade.IdDivida;
            }

            return 0;
        }

    }
}
