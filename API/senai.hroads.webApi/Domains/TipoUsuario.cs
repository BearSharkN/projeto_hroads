using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
#nullable disable

namespace senai.hroads.webApi_.Domains
{
    [Table("tipoUsuario")]

    public partial class TipoUsuario
    {
        public TipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idTipoUsuario { get; set; }
        [Column(TypeName = "VARCHAR(255)")]
        public string titulo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
