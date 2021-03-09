using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Dto.Cliente
{
    public class ClienteParcelamentoDto: ClienteDividaDto
    {

        public ClienteParcelamentoDto() 
        {
            Parcelas = new List<ParcelasDto>();
        }

        public List<ParcelasDto> Parcelas { get; set; }

        public double ValorJuros { get; set; }
        public double ValorTotal { get; set; }
        public double ValorComissao { get; set; }
        public int DiasAtraso { get; set; }

        public int NumeroParcelas { get; set; }

    }
}
