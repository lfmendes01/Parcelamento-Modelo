using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Dto.Cliente
{
    public class ClienteDividaDto
    {

        public double ValorDivida { get; set; }

        public DateTime DataVencimento { get; set; }

        public int IdCliente { get; set; }

        public int IdDivida { get; set; }

    }
}
