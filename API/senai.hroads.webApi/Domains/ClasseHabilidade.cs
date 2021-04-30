using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace senai.hroads.webApi_.Domains
{
    [Table("ClassHab")]

    public partial class ClasseHabilidade
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idClassHab { get; set; }

        public int idClasse { get; set; }
        [ForeignKey("idClasse")]
        public Classe Classe { get; set; }

        public int idHabilidade { get; set; }
        [ForeignKey("idHabilidade")]
        public Habilidade habilidade { get; set; }



        public virtual Classe IdClasseNavigation { get; set; }
        public virtual Habilidade IdHabilidadeNavigation { get; set; }
    }
}
