using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Dto.Cliente
{
    public class ConfiguracaoDto
    {
        public int Id { get; set; }
        public int MaximoParcelas { get; set; }

        public bool JurosSimples { get; set; }

        public double Juros { get; set; }

        public double ComissaoPorcentagem { get; set; }

        public string TelefoneContato { get; set; }
    }
}
