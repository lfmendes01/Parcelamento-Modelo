using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Entities
{
    public class Parcelamento
    {
       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdParcelamento { get; set; }
        public DateTime DataVencimento { get; set; }

        public byte NumeroParcela { get; set; }

        public double ValorFinalParcela { get; set; }

        public Divida Divida { get; set; }

        public int IdDivida { get; set; }
    }
}
