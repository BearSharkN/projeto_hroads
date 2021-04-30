using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace senai.hroads.webApi_.Domains
{
    [Table("Classe")]
    public partial class Classe
    {
       
        public Classe()
        {
            Personagems = new HashSet<Personagem>();
        }

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int idClasse { get; set; }

            [Column(TypeName = "VARCHAR(255)")]
            public string Nome { get; set; }

            public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
