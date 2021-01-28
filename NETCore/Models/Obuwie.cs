using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NETCore.Models
{
    [Table("Obuwie")]
    public class Obuwie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nie podałeś nazwy")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Nie wybrałeś rodzaju")]
        public string Rodzaj { get; set; }

        [Required(ErrorMessage = "Nie podałeś rozmiaru")]
        public int Rozmiar { get; set; }

        [Required(ErrorMessage = "Nie wybrałeś płci dla której przeznaczone jest to obuwie")]
        [Display(Name = "Męskie/Damskie")]
        public string ManorWomen { get; set; }

        [Required(ErrorMessage = "Nie podałeś ceny")]
        public double Cena { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }

    }
}
