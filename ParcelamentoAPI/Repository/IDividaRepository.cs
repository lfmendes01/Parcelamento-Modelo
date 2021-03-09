using ParcelamentoAPI.Dto.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Repository
{
    public interface IDividaRepository
    {
        List<ClienteDividaDto> GetByIdCliente(int idCliente);

        int Add(ClienteDividaDto dto);

        int Update(ClienteParcelamentoDto dto);
    }
}
