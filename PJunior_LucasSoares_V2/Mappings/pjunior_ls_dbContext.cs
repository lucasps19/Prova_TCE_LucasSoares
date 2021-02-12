using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PJunior_LucasSoares_V2.Mappings
{
    public partial class pjunior_ls_dbContext : DbContext
    {
        public pjunior_ls_dbContext()
        {
        }

        public pjunior_ls_dbContext(DbContextOptions<pjunior_ls_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; }
        public virtual DbSet<Estudante> Estudantes { get; set; }
        public virtual DbSet<Professor> Professors { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }
        public virtual DbSet<TurmaAluno> TurmaAlunos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("data source=localhost;initial catalog=pjunior_ls_db;user id=LucasPS;password=Lucas1903", Microsoft.EntityFrameworkCore.ServerVersion.FromString("8.0.23-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId)
                    .HasColumnType("varchar(95)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasColumnType("varchar(32)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Estudante>(entity =>
            {
                entity.HasKey(e => e.Matricula)
                    .HasName("PRIMARY");

                entity.ToTable("estudante");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(80)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Professor>(entity =>
            {
                entity.HasKey(e => e.Registro)
                    .HasName("PRIMARY");

                entity.ToTable("professor");

                entity.Property(e => e.Nome)
                    .HasColumnType("varchar(80)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.ToTable("turma");

                entity.HasIndex(e => e.ProfessorRegistro, "IX_Turmas_TeacherRegistro");

                entity.Property(e => e.Disciplina)
                    .HasColumnType("varchar(80)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.HasOne(d => d.ProfessorRegistroNavigation)
                    .WithMany(p => p.Turmas)
                    .HasForeignKey(d => d.ProfessorRegistro)
                    .HasConstraintName("fk_turma_professor");
            });

            modelBuilder.Entity<TurmaAluno>(entity =>
            {
                entity.ToTable("turma_aluno");

                entity.HasIndex(e => e.Matricula, "fk_turma_aluno_idx");

                entity.HasIndex(e => e.Turma, "fk_turma_turma_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Matricula).HasColumnName("matricula");

                entity.Property(e => e.Turma).HasColumnName("turma");

                entity.HasOne(d => d.MatriculaNavigation)
                    .WithMany(p => p.TurmaAlunos)
                    .HasForeignKey(d => d.Matricula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_turma_aluno");

                entity.HasOne(d => d.TurmaNavigation)
                    .WithMany(p => p.TurmaAlunos)
                    .HasForeignKey(d => d.Turma)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_turma_turma");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
