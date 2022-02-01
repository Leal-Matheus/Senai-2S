using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }

        public byte? IdTipoUsuario { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo de Email precisa ser preenchido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo de Senha precisa ser preenchido")]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "O campo senha precisa ter no mínimo 3 e no máximo 10 caracteres.")]
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
    }
}
