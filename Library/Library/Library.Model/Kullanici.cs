using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    [Table("Kullanici")]
    public class Kullanici
    {
        public int KullaniciId { get; set; }
        public long TC { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public DateTime DogumTarihi { get; set; }
        public DateTime KayıtTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public string Telefon { get; set; }
        public string Adres { get; set; }
        public string Eposta { get; set; }
        public int RollId { get; set; }
        public string Sifre { get; set; }
        public virtual Roll Roll { get; set; }
    }
}
