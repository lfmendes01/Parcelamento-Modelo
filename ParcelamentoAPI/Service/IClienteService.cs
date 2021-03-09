using ParcelamentoAPI.Dto.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Service
{
    public interface IClienteService
    {
        ClienteDto Get(int idCliente);
    }
}
