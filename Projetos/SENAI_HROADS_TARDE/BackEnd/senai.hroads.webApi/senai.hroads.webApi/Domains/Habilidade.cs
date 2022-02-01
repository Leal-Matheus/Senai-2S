using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai.hroads.webApi_.Domains
{
    public partial class Habilidade
    {
        public Habilidade()
        {
            QuadroHabilidades = new HashSet<QuadroHabilidade>();
        }

        public byte IdHabilidade { get; set; }

        [Required(ErrorMessage = "O campo de IdTipo precisa ser preenchido")]
        public byte? IdTipo { get; set; }
        public string Habilidade1 { get; set; }

        public virtual TipoHabilidade IdTipoNavigation { get; set; }
        public virtual ICollection<QuadroHabilidade> QuadroHabilidades { get; set; }
    }
}
