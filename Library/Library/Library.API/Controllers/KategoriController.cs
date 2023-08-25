﻿using Library.Model;
using Library.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : BaseController
    {
        public KategoriController(RepositoryWrapper repo, IMemoryCache cache) : base(repo, cache) 
        {
        }
        [HttpPost("Kaydet")]
        public dynamic Kaydet([FromBody] dynamic model)
        {
            dynamic json = JObject.Parse(model.GetRawText());

            Kategori item = new Kategori()
            {
                KategoriId = json.KategoriId,
                Ad = json.Ad
            };
            if (item.KategoriId > 0)
            {
                repo.KategoriRepository.Update(item);
            }
            else
            {
                repo.KategoriRepository.Create(item);
            }
            repo.SaveChanges();
            return new
            {
                success = true
            };
        }
        [HttpDelete("{id}")]
        public dynamic Sil(int id)
        {
            if (id <= 0)
            {
                return new
                {
                    success = false,
                    message = "Geçersiz id",
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
