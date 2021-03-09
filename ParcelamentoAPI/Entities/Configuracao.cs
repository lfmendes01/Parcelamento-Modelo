using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Entities
{
    public class Configuracao
    {
        [Column("IdConfiguracao")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdConfiguracao { get; set; }
        public int MaximoParcelas { get; set; }

        public bool JurosSimples { get; set; }

        public double Juros { get; set; }

        public double ComissaoPorcentagem { get; set; }

        public string TelefoneContato { get; set; }

    }
}
