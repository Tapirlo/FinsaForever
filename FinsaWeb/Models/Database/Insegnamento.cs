using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorsiOnline.Models.Database
{
    [Table("insegnamenti")]
    public class Insegnamento
    {
        [Column("materia")]
        [StringLength(25)]
        public string Materia { get; set; }
        [Column("docente")]
        [StringLength(25)]
        public string Docente { get; set; }

        [ForeignKey("Docente")]
        [InverseProperty("Insegnamenti")]
        public Docente DocenteNavigation { get; set; }
    }
}
