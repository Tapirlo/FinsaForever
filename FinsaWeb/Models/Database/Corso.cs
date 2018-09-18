using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorsiOnline.Models.Database
{
    public class Corso
    {

        public Corso()
        {
           /* DocenteCorso = new HashSet<DocenteCorso>();
            Materiecorsi = new HashSet<MateriaCorso>();
            StudenteCorso = new HashSet<StudenteCorso>();
            SvolgimentoCorsi = new HashSet<SvolgimentoCorso>();
            */
        }
        public Corso(String id, String n, DateTime inizio, DateTime fine) : this()
        {
            IDCorso = id;
            Nome = n;
            DataInizio = inizio;
            DataFine = fine;

        }


        [Key]
        [Column("idcorso")]
        [StringLength(25)]
        public string IDCorso { get; set; }
        [Required]
        [Column("nome")]
        [StringLength(25)]
        public string Nome { get; set; }
        [Column("datainizio", TypeName = "datetime")]
        public DateTime DataInizio { get; set; }
        [Column("datafine", TypeName = "datetime")]
        public DateTime DataFine { get; set; }

        /*
       
        [InverseProperty("CorsoNavigation")]
        public ICollection<MateriaCorso> Materiecorsi { get; set; }
        [InverseProperty("CorsoNavigation")]

        public ICollection<SvolgimentoCorso> SvolgimentoCorsi { get; set; }
        */

        [InverseProperty("CorsoNavigation")]
        public ICollection<DocenteCorso> DocentiCorsi { get; set; }

        [InverseProperty("CorsoNavigation")]
        public ICollection<StudenteCorso> StudentiCorsi { get; set; }


        public override bool Equals(object obj)
        {
            if (!(obj is Corso))
            {
                return false;
            }

            Corso s = (Corso)obj;
            return IDCorso == s.IDCorso;
        }

        public override int GetHashCode()
        {
            return IDCorso.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Nome).Append(Environment.NewLine);
            builder.Append("Materie:").Append(Environment.NewLine);
           /* foreach (MateriaCorso materia in Materiecorsi)
            {
                builder.Append(materia.Materia).Append(" ");
            }
            builder.Remove(builder.Length - 1, 1).Append(Environment.NewLine);
            builder.Append("Docenti:").Append(Environment.NewLine);
            foreach (DocenteCorso docet in DocenteCorso)
            {
                builder.Append(docet.DocenteNavigation).Append(Environment.NewLine).Append("Punteggio:").Append(docet.Punteggio).Append(Environment.NewLine).Append(Environment.NewLine);
            }
            builder.Remove(builder.Length - 1, 1).Append(Environment.NewLine);
            builder.Append("Icritti:").Append(Environment.NewLine);
            foreach (StudenteCorso stude in StudenteCorso)
            {
                builder.Append(stude.StudenteNavigation).Append(Environment.NewLine).Append("Punteggio:").Append(stude.Punteggio).Append(Environment.NewLine).Append(Environment.NewLine);
            }
            builder.Remove(builder.Length - 1, 1).Append(Environment.NewLine);

            builder.Append("Svolgimento:").Append(Environment.NewLine);
            foreach (SvolgimentoCorso svolgi in SvolgimentoCorsi)
            {
                builder.Append(svolgi.Datacorso).Append(" ").Append(svolgi.AulaNavigation).Append(Environment.NewLine);
            }*/
            return builder.Remove(builder.Length - 1, 1).ToString();

        }


    }

}
