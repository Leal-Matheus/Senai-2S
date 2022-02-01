using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a tabela de estudio dentro do Banco de dados.
    /// </summary>
    public class EstudioDomain
    {
        public int idEstudio { get; set; }
        public string NomeEstudio { get; set; }
    }
}
