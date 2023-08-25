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
    public class KiralamaController : BaseController
    {
        public KiralamaController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Kiralama item = new Kiralama()
            {
                KiralamaId = json.KiralanaId,
                KitapId = json.KitapId,
                KullaniciId = json.KullaniciId,
                AlımTarihi = json.AlımTarihi,
                İadeTarihi = json.İadeTarih,
                SonTeslimTarihi = json.SonTeslimTarihi
            };
            if (item.KiralamaId > 0)
            {
                repo.KiralamaRepository.Update(item);
            }
            else
            {
                repo.KiralamaRepository.Create(item);
            }
            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
    }
}
