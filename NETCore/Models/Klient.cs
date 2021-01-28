using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Models
{
    [Table("Klient")]
    public class Klient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nie podałeś imienia")]
        public string Imie { get; set; }
        [Required(ErrorMessage = "Nie podałeś nazwiska")]
        public string Nazwisko { get; set; }

        [Required(ErrorMessage = "Nie podałeś adresu")]
        public string Adres { get; set; }

        [Required(ErrorMessage = "Nie podałeś e-maila")]
        public string Email { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
