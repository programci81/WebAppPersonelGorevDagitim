using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPersonelGorevDagitim.Models
{
    public class TarihPrm
    {
       public DateTime? Tarih { get; set; }
       public string Tarih_ToString { get => Tarih.HasValue ? string.Format("{0:dd.MM.yyyy}", Tarih.Value) : ""; }
       public IEnumerable<WebAppPersonelGorevDagitim.Models.ProsesDagitimView> prosesDagitim { get; set; }
    }
}
