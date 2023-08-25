using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    [Table("Roll")]
    public class Roll
    {
        public Roll()
        {
            Kullanicilar = new HashSet<Kullanici>();
        }
        public int RollId { get; set; }
        public string RollAd { get; set; }
        public virtual ICollection<Kullanici> Kullanicilar { get; set; }
    }
}
