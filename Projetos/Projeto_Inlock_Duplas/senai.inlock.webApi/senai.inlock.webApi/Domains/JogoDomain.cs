using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi.Domains
{
    /// <summary>
    /// Classe que representa a tabela de jogos dentro do Banco de dados.
    /// </summary>
    public class JogoDomain
    {
        public int idJogo { get; set; }


        [Required(ErrorMessage = "O campo de Nome é obrigatório!")]
        public string nomeJogo { get; set; }

        [Required(ErrorMessage = "O campo de valor é obrigatório!")]
        public float Valor { get; set; }

        public DateTime dataLancamento { get; set; }

        [Required(ErrorMessage = "O campo de descrição é obrigatório")]
        public string descricao { get; set; }

        public int idEstudio { get; set; }
        public EstudioDomain estudio { get; set; }
    }
}
