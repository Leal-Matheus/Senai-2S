using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a tabela de Usuários dentro do Banco de dados.
    /// </summary>
    public class UsuarioDomain
    {
        public int idUsuario { get; set; }

        [Required(ErrorMessage = "O campo de email é obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo de senha é obrigatório")]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "O campo senha precisa ter no mínimo 3 e no máximo 10 caracteres.")]
        public string Senha { get; set; }
        public int idTipoUsuario { get; set; }
        public TipoUsuarioDomain tipoUsuario { get; set; }
    }
}
