using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NETCore.Models
{
    [Table("Zamowienie")]
    public class Zamowienie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Nazwa obuwia")]
        [Required(ErrorMessage = "Nie wybrałeś nazwy obuwia")]
        public int ObuwieId { get; set; }

        [Display(Name = "Nazwisko klienta")]
        [Required(ErrorMessage = "Nie wybrałeś nazwiska klienta")]
        public int KlientId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Nie podałeś daty")]
        public DateTime Data { get; set; }
        public virtual Obuwie Obuwie { get; set; }
        public virtual Klient Klient { get; set; }

    }
}
