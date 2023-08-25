using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    [Table("Kitap")]
    public class Kitap
    {
        
        public int KitapId { get; set; }
        public string Ad { get; set; }
        public string ISBN { get; set; }
        public DateTime YayinTarihi { get; set; }
        public int KategoriId { get; set; }

    }
}
