using ParcelamentoAPI.Dto.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Repository
{
    public interface IConfiguracaoRepository
    {
        int Add(ConfiguracaoDto dto);

        ConfiguracaoDto GetUltimaConfiguracao();
    }
}
