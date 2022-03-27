using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPersonelGorevDagitim.Models
{
    public class Personel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]  // fk icin gerekli
        [ScaffoldColumn(true)]
        [DisplayName("Personel Id")]
        public int PersonelId { get; set; }

        [DisplayName("Personel Adı")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Personel Adı girilmelidir")]
        public string PersonelAdi { get; set; }

        [DisplayName("Personel Soyadı")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Personel Soyadı girilmelidir")]
        public string PersonelSoyadi { get; set; }        
    }
}
