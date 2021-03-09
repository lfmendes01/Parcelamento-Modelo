using ParcelamentoAPI.Dto.Cliente;
using ParcelamentoAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Repository
{
    public class ConfiguracaoRepository : IConfiguracaoRepository
    {
        ParcelamentoMemoryContext db;
        public ConfiguracaoRepository(ParcelamentoMemoryContext _db)
        {
            db = _db;
        }

        public ConfiguracaoDto GetUltimaConfiguracao()
        {
            if (db != null)
            {
                return db.Configuracao.Select(a => new ConfiguracaoDto()
                {
                    Id = a.IdConfiguracao,
                    ComissaoPorcentagem = a.ComissaoPorcentagem,
                    Juros = a.Juros,
                    JurosSimples = a.JurosSimples,
                    MaximoParcelas = a.MaximoParcelas,
                    TelefoneContato = a.TelefoneContato
                }).FirstOrDefault();
            }
            return null;
        }


        public int Add(ConfiguracaoDto dto)
        {
            if (db != null)
            {
                Configuracao entidade = new Configuracao()
                {
                    ComissaoPorcentagem = dto.ComissaoPorcentagem,
                    Juros = dto.Juros,
                    JurosSimples = dto.JurosSimples,
                    MaximoParcelas = dto.MaximoParcelas,
                    TelefoneContato = dto.TelefoneContato
                };

                db.Configuracao.Add(entidade);
                db.SaveChangesAsync();

                return entidade.IdConfiguracao;
            }

            return 0;
        }
        
       
    }
}
