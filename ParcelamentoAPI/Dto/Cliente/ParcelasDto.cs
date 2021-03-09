using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Dto.Cliente
{
    public class ParcelasDto
    {
        public byte NumeroParcela { get; internal set; }
        public int IdDivida { get; internal set; }
        public double ValorParcela { get; internal set; }
        public DateTime DataVencimento { get; internal set; }
    }
}
