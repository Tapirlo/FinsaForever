using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorsiOnline.Models.Database
{
    public class DocenteCorso
    {
        [Column("corso")]
        [StringLength(25)]
        public string Corso { get; set; }
        [Column("docente")]
        [StringLength(25)]
        public string Docente { get; set; }

        [Column("punteggio")]
        public int? Punteggio { get; set; }

        [ForeignKey("Docente")]
        [InverseProperty("DocentiCorsi")]
        public Docente DocenteNavigation { get; set; }

        [ForeignKey("Corso")]
        [InverseProperty("DocentiCorsi")]
        public Corso CorsoNavigation { get; set; }
    }
}
