using System.Linq;
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
    public class RolController : BaseController
    {

        public RolController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache) { }

        [HttpGet("TumRolller")]
        public dynamic TumRoller()
        {
            List<Roll> items = repo.RollRepository.FindAll().ToList<Roll>();
            return new
            {
                success = true,
                data = items
            };
        }


        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Roll item = new Roll()
            {
                RollId = json.Id,
                RollAd = json.RollAd
            };

            if (string.IsNullOrEmpty(item.RollAd))
            {
                return new
                {
                    success = false,
                    message = "Ad alanı boş geçilemez"
                };
            }
            if (item.RollAd.Length > 20)
            {
                return new
                {
                    success = false,
                    message = "Ad alanı maksimum 20 karakter olabilir"
                };
            }

            if (item.RollId > 0)
            {
                repo.RollRepository.Update(item);
            }
            else
            {
                repo.RollRepository.Create(item);
            }

            repo.SaveChanges();

            return new
            {
                success = true
            };
        }

        [HttpDelete("Sil")]
        public dynamic Sil(int id)
        {
            if (id <= 0)
            {
                return new
                {
                    success = false,
                    message = "Geçersiz id"
                };
            }

            repo.RollRepository.RollSil(id);
            return new
            {
                success = true
            };
        }
    }


}
