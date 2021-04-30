using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace senai.hroads.webApi_.Domains
{
    [Table("Habilidade")]
    public partial class Habilidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idHabilidade { get; set; }

        public int idTipo { get; set; }
        [ForeignKey("idTipo")]
        public TipoHabilidade tipoHabilidade { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string habilidade { get; set; }

        public virtual TipoHabilidade IdTipoHabilidadeNavigation { get; set; }
    }
}

