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
    public class YayineviController : BaseController
    {
        public YayineviController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache)
        {
        }
        [HttpPost("Yayinevleri")]
        public dynamic Yayinevleri([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Yayinevi item = new Yayinevi()
            {
                YayinEviId = json.YayinEviId,
                Ad = json.Ad,
            };
          
            if (item.YayinEviId > 0)
            {
                repo.YayineviRepository.Update(item);
            }
            else
            {
                repo.YayineviRepository.Create(item);
            }
            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
    }
}
