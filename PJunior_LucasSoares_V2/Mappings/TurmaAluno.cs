using System;
using System.Collections.Generic;

#nullable disable

namespace PJunior_LucasSoares_V2.Mappings
{
    public partial class TurmaAluno
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public int Turma { get; set; }

        public virtual Estudante MatriculaNavigation { get; set; }
        public virtual Turma TurmaNavigation { get; set; }
    }
}
