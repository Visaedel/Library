using Library.Model;
using Library.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KullaniciController : BaseController
    {
        public KullaniciController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpPost("Getir")]
        public dynamic Getir([FromBody] dynamic model)
        {
            dynamic Json = JObject.Parse(model.GetRawText());
            string eposta = Json.Eposta;
            string sifre = Json.Sifre;
            Kullanici item = repo.KullaniciRepository.FindByCondition(k => k.Eposta == eposta && k.Sifre == sifre).SingleOrDefault<Kullanici>();
            if (item != null)
            {
                return new
                {
                    success = true,
                    date = item
                };
            }
            else
            {
                return new
                {
                    success = false,
                    message = "Kullanıcı Adı veya Şifre Hatalı!"
                };
            }
        }
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Kullanici item = new Kullanici()
            {
                KullaniciId = json.Id,
                TC=json.Tc,
                Ad = json.Ad,
                Soyad = json.Soyad,
                DogumTarihi=json.DogumTarihi,
                KayıtTarihi=json.KayitTarihi,
                Cinsiyet=json.Cinsiyet,
                Eposta = json.Eposta,
                Sifre = json.Sifre,
                Telefon = json.TelNo,
                RollId = json.RolId,
                Adres = json.Adres,
                
            };
            if (item.KullaniciId > 0)
            {
                repo.KullaniciRepository.Update(item);
            }
            else
            {
                repo.KullaniciRepository.Create(item);
            }
            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
    }
}
