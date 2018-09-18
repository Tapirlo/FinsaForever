using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CorsiOnline.Models.Database
{
    public class StudenteCorso
    {
        [Column("studente")]
        [StringLength(25)]
        public String Studente
        {
            get;
            set;
        }
        [Column("corso")]
        [StringLength(25)]
        public String Corso
        {
            get;
            set;
        }
        [Column("punteggio")]
        [StringLength(25)]
        public int? Punteggio
        {
            get;
            set;
        }

        [ForeignKey("Corso")]
        [InverseProperty("StudentiCorsi")]
        public Corso CorsoNavigation { get; set; }
        [ForeignKey("Studente")]
        [InverseProperty("StudentiCorsi")]
        public Studente StudenteNavigation { get; set; }
    }
}
