using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace senai.hroads.webApi_.Domains
{
    [Table("Personagens")]
    public partial class Personagem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idPersonagem { get; set; }

        public int idClasse { get; set; }
        [ForeignKey("idClasse")]
        public Classe Classe { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string Nome { get; set; }

        [Column(TypeName = "int")]
        public int CapacidadeMaxVida { get; set; }

        [Column(TypeName = "int")]
        public int CapacidadeMaxMana { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime DataAtualizacao { get; set; }

        [Column(TypeName = "DATE")]
        public DateTime DataCriacao { get; set; }


        public virtual Classe IdClasseNavigation { get; set; }
    }
}
