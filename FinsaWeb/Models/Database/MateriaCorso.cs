using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorsiOnline.Models.Database
{
    [Table("materiecorsi")]
    public class MateriaCorso
    {
        [Column("corso")]
        [StringLength(25)]
        public string Corso { get; set; }
        [Column("materia")]
        [StringLength(25)]
        public string Materia { get; set; }

        [ForeignKey("Corso")]
        [InverseProperty("MaterieCorsi")]
        public Corso CorsoNavigation { get; set; }
    }
}
