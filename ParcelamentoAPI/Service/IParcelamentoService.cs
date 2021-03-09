using ParcelamentoAPI.Dto.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Service
{
    public interface IParcelamentoService
    {
        List<ClienteParcelamentoDto> CalcularParcelamento(int idCliente, DateTime dataCalculo);

        List<ClienteDividaDto> Divida(int idCliente);

        void SalvarParcelamento(ClienteParcelamentoDto dto);
    }
}
