using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CorsiOnline.Models.Database;

namespace CorsiOnline.Models
{
    public class Docente
    {

        [Required]
        [Column("nome")]
        [StringLength(25)]
        public string Nome { get; set; }

        [Required]
        [Column("cognome")]
        [StringLength(25)]
        public string Cognome { get; set; }

        [Required]
        [Column("email")]
        [StringLength(25)]
        public string Email { get; set; }

        [Required]
        [Column("datanascita")]
        public DateTime DataNascita { get; set; }

        [Required]
        [Column("telefono")]
        [StringLength(10)]
        public string Telefono { get; set; }

        [Key]
        [Column("codicefiscale")]
        [StringLength(25)]
        public string CodFiscale { get; set; }

        [InverseProperty("DocenteNavigation")]
        public ICollection<DocenteCorso> DocentiCorsi { get; set; }
    }
}
