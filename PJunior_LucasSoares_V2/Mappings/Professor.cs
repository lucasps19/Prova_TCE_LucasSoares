using System;
using System.Collections.Generic;

#nullable disable

namespace PJunior_LucasSoares_V2.Mappings
{
    public partial class Professor
    {
        public Professor()
        {
            Turmas = new HashSet<Turma>();
        }

        public int Registro { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Turma> Turmas { get; set; }
    }
}
