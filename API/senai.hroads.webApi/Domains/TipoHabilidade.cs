using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    [Table("TipoHabilidade")]

    public partial class TipoHabilidade
    {
        public TipoHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTipo { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string Tipo { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
