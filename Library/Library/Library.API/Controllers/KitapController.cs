using Library.Model;
using Library.Repository;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitapController : BaseController
    {
        public KitapController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpGet("TumKitaplar")]
        public dynamic TumKitaplar()
        {
            List<Kitap> items = repo.KitapRepository.FindAll().ToList<Kitap>();
            return new
            {
                success = true,
                data = items,
            };
        }
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Kitap item = new Kitap()
            {
                KitapId = json.KitapId,
                Ad = json.Ad,
                YayinTarihi = json.YayinTarihi,
                ISBN = json.ISBN,
                KategoriId = json.KategoriId,
            };
            if (item.KitapId > 0)
            {
                repo.KitapRepository.Update(item);
            }
            else
            {
                repo.KitapRepository.Create(item);
            }
            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
    }
}
