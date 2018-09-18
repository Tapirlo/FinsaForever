using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorsiOnline.Models.Database
{
    [Table("prenotazioniaule")]
    public class PrenotazioneAula
    {
        [Column("corso")]
        [StringLength(25)]
        public string Corso { get; set; }
        [Column("aula")]
        [StringLength(15)]
        public string Aula { get; set; }
        [Column("data", TypeName = "datetime")]
        public DateTime Data { get; set; }

        [ForeignKey("Corso")]
        [InverseProperty("PrenotazioniAule")]
        public Corso CorsoNavigation { get; set; }
        [ForeignKey("Aula")]
        [InverseProperty("PrenotazioniAule")]
        public Aula AulaNavigation { get; set; }
    }
}
