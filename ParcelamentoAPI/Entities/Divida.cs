using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Entities
{
    public class Divida
    {
        [Column("IdDivida")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdDivida { get; set; }

        public DateTime DataVencimento { get; set; }

        public int NumeroParcelas { get; set; }

        public double ValorComissao { get; set; }

        public double ValorDivida { get; set; }

        public int IdCliente { get; set; }


        public double ValorJuros { get; set; }

        public double ValorFinal { get; set; }

        public List<Parcelamento> Parcelamento { get; set; }

    }
}
