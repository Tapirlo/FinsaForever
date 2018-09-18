using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorsiOnline.Models.Database
{
    [Table("aule")]
    public class Aula
    {
        [Key]
        [Column("nomeaula")]
        [StringLength(15)]
        public string NomeAula { get; set; }
        [Required]
        [Column("numeroposti")]
        public int NumeroPosti { get; set; }
        [Required]
        [Column("numerocomputer")]
        public int NumeroComputer { get; set; }
        [Required]
        [Column("superficie")]
        public int Superficie { get; set; }

        [InverseProperty("AulaNavigation")]
        public ICollection<PrenotazioneAula> PrenotazioniAule { get; set; }

    }
}
