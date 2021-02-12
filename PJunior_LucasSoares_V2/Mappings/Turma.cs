using System;
using System.Collections.Generic;

#nullable disable

namespace PJunior_LucasSoares_V2.Mappings
{
    public partial class Turma
    {
        public Turma()
        {
            TurmaAlunos = new HashSet<TurmaAluno>();
        }

        public int Id { get; set; }
        public string Disciplina { get; set; }
        public int? ProfessorRegistro { get; set; }

        public virtual Professor ProfessorRegistroNavigation { get; set; }
        public virtual ICollection<TurmaAluno> TurmaAlunos { get; set; }
    }
}
