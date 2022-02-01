using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a tabela de tipoUsuario dentro do Banco de dados.
    /// </summary>
    public class TipoUsuarioDomain
    {
        public int idTipoUsuario { get; set; }
        public string titulo { get; set; }
    }
}
