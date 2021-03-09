using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParcelamentoAPI.Entities
{
    public class Cliente
    {
        [Column("IdCliente")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int IdCliente { get; set; }
        public string Nome { get; set; }

        public string Telefone { get; set; }

        public List<Divida> Divida { get; set; }

    }
}
