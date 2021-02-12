using System;
using System.Collections.Generic;

#nullable disable

namespace PJunior_LucasSoares_V2.Mappings
{
    public partial class Estudante
    {
        public Estudante()
        {
            TurmaAlunos = new HashSet<TurmaAluno>();
        }

        public int Matricula { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<TurmaAluno> TurmaAlunos { get; set; }
    }
}
