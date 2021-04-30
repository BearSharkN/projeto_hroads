
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


#nullable disable

namespace senai.hroads.webApi_.Domains
{
    [Table("usuario")]

    public partial class Usuario
    {
        /// <summary>
        /// Propriedades da tabela Usuario
        /// </summary>
        /// 

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idUsuario { get; set; }
        [Column(TypeName = "VARCHAR(255)")]
        public string email { get; set; }
        [Column(TypeName = "VARCHAR(255)")]
        public string senha { get; set; }

        public int idTipoUsuario { get; set; }
        [ForeignKey("idTipoUsuario")]
        public TipoUsuario tipoUsuario { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
