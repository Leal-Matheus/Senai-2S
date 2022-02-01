using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Personagem
    {
        public byte IdPersonagem { get; set; }

        [Required(ErrorMessage = "O campo de idClasse precisa ser preenchido")]
        public byte? IdClasse { get; set; }

        [Required(ErrorMessage = "O campo de NomePersonagem precisa ser preenchido")]
        public string NomePersonagem { get; set; }

        [Required(ErrorMessage = "O campo de VidaMax precisa ser preenchido")]
        public string VidaMax { get; set; }

        [Required(ErrorMessage = "O campo de ManaMax precisa ser preenchido")]
        public string ManaMax { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
