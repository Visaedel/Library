using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    [Table("Kiralama")]
    public class Kiralama
    {
        public int KiralamaId { get; set; }
        public int KitapId { get; set; }
        public int KullaniciId { get; set; }
        public DateTime AlımTarihi { get; set; }
        public DateTime İadeTarihi { get; set; }
        public DateTime SonTeslimTarihi { get; set; }

    }

}
