using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    [Table("Yayinevi")]
    public class Yayinevi
    {
        public int YayinEviId { get; set; }
        public string Ad { get; set; }
    }
}
