using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppPersonelGorevDagitim.Models
{
    public class ProsesDagitimView
    {
        [DisplayName("PDId")]
        public int PDId { get; set; }

        [DisplayName("Tarih")]
        [DataType(DataType.Date)]
        public DateTime Tarih { get; set; }

        [DisplayName("Personel Adı")]
        public string PersonelAdi { get; set; }

        [DisplayName("Personel Soyadı")]
        public string PersonelSoyadi { get; set; }

        [DisplayName("Proses Adı")]
        public string ProsesAdi { get; set; }

        [DisplayName("Proses Zorluk")]
        public short Zorluk { get; set; }
    }
}
