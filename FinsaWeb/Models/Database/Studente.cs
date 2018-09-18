using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CorsiOnline.Models.Database
{
    public class Studente
    {
        [Key]
        [Column("nome")]
        [StringLength(25)]
        public int Id { get; set; }

        [Required]
        [Column("nome")]
        [StringLength(25)]
        public string Nome { get; set; }

        [Required]
        [Column("cognome")]
        [StringLength(25)]
        public string Cognome { get; set; }

        [Required]
        [Column("datanascita")]
        public DateTime DataNascita { get; set; }


        [Required]
        [Column("sesso")]
        [StringLength(1)]
        public string Sesso { get; set; }

        [Required]
        [Column("email")]
        [StringLength(25)]
        public string Email { get; set; }
    }
}
