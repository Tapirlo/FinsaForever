using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace CorsiOnline.Models.Database
{
    public class ContestoCorso:DbContext
    {

        public ContestoCorso(DbContextOptions<ContestoCorso> options) : base(options)
        {

        }

        public virtual DbSet<Studente> Studenti { get; set; }
        public virtual DbSet<Aula> Aule { get; set; }
        public virtual DbSet<Corso> Corsi { get; set; }
        public virtual DbSet<Docente> Docenti { get; set; }
        public virtual DbSet<DocenteCorso> DocentiCorsi { get; set; }
        public virtual DbSet<Insegnamento> Insegnamenti { get; set; }
        public virtual DbSet<MateriaCorso> MaterieCorsi { get; set; }
        public virtual DbSet<StudenteCorso> StudentiCorsi { get; set; }
        public virtual DbSet<PrenotazioneAula> PrenotazioniAule { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Studente>(entity =>
            {
                entity.Property(e => e.CodiceFiscale)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cognome).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Sesso).IsUnicode(false);
            });

            modelBuilder.Entity<Aula>(entity =>
            {
                entity.Property(e => e.NomeAula)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Corso>(entity =>
            {
                entity.Property(e => e.IDCorso)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<Docente>(entity =>
            {
                entity.Property(e => e.CodiceFiscale)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cognome).IsUnicode(false);

                entity.Property(e => e.Telefono).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

            });

            modelBuilder.Entity<DocenteCorso>(entity =>
            {
                entity.HasKey(e => new { e.Corso, e.Docente });

                entity.Property(e => e.Corso).IsUnicode(false);

                entity.Property(e => e.Docente).IsUnicode(false);

                entity.HasOne(d => d.DocenteNavigation)
                    .WithMany(p => p.DocentiCorsi)
                    .HasForeignKey(d => d.Docente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__docentico__docen__412EB0B6");

                entity.HasOne(d => d.CorsoNavigation)
                    .WithMany(p => p.DocentiCorsi)
                    .HasForeignKey(d => d.Corso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__docentico__idcor__403A8C7D");
            });

            modelBuilder.Entity<Insegnamento>(entity =>
            {
                entity.HasKey(e => new { e.Docente, e.Materia });

                entity.Property(e => e.Docente).IsUnicode(false);

                entity.Property(e => e.Materia).IsUnicode(false);

                entity.HasOne(d => d.DocenteNavigation)
                    .WithMany(p => p.Insegnamenti)
                    .HasForeignKey(d => d.Docente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__insegname__inseg__4D94879B");
            });

            modelBuilder.Entity<MateriaCorso>(entity =>
            {
                entity.HasKey(e => new { e.Corso, e.Materia });

                entity.Property(e => e.Corso).IsUnicode(false);

                entity.Property(e => e.Materia).IsUnicode(false);

                entity.HasOne(d => d.CorsoNavigation)
                    .WithMany(p => p.MaterieCorsi)
                    .HasForeignKey(d => d.Corso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__materieco__corso__3D5E1FD2");
            });

            modelBuilder.Entity<StudenteCorso>(entity =>
            {
                entity.HasKey(e => new { e.Corso, e.Studente });

                entity.Property(e => e.Corso).IsUnicode(false);

                entity.Property(e => e.Studente).IsUnicode(false);

                entity.HasOne(d => d.CorsoNavigation)
                    .WithMany(p => p.StudentiCorsi)
                    .HasForeignKey(d => d.Corso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__studentic__idcor__49C3F6B7");

                entity.HasOne(d => d.StudenteNavigation)
                    .WithMany(p => p.StudentiCorsi)
                    .HasForeignKey(d => d.Studente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__studentic__stude__4AB81AF0");
            });

            modelBuilder.Entity<PrenotazioneAula>(entity =>
            {
                entity.HasKey(e => new { e.Corso, e.Aula, e.Data });

                entity.Property(e => e.Corso).IsUnicode(false);

                entity.Property(e => e.Aula).IsUnicode(false);

                entity.HasOne(d => d.CorsoNavigation)
                    .WithMany(p => p.PrenotazioniAule)
                    .HasForeignKey(d => d.Corso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__svolgimen__idcor__45F365D3");

                entity.HasOne(d => d.AulaNavigation)
                    .WithMany(p => p.PrenotazioniAule)
                    .HasForeignKey(d => d.Aula)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__svolgimen__nomea__46E78A0C");
            });
        }
    }
}


