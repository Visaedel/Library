using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Model
{


    [Table("Kategori")]
    public class Kategori
    {
       
        public int KategoriId { get; set; }
        public string Ad { get; set; }
    }
}