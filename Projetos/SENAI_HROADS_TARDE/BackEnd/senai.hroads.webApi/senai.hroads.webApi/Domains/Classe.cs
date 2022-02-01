using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            Personagems = new HashSet<Personagem>();
            QuadroHabilidades = new HashSet<QuadroHabilidade>();
        }

        public byte IdClasse { get; set; }

        [Required(ErrorMessage = "O campo de NomeClasse precisa ser preenchido")]
        public string NomeClasse { get; set; }

        public virtual ICollection<Personagem> Personagems { get; set; }
        public virtual ICollection<QuadroHabilidade> QuadroHabilidades { get; set; }
    }
}
