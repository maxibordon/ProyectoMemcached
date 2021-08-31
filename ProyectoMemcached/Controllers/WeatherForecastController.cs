using Enyim.Caching;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoMemcached.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IDistributedCache _memcachedClient;

     

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IDistributedCache memcachedClient, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _memcachedClient = memcachedClient;
            

        }

        [HttpGet]
        public async Task<string> Get()
        {
            var cacheKey = "info-suministros";       

            var creativesJson = await _memcachedClient.GetStringAsync(cacheKey);
             if (creativesJson == null)
            {
                creativesJson = GetFromWs();
               await _memcachedClient.SetStringAsync(
               cacheKey,
               creativesJson,
               new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5)));
            }

            return creativesJson;

        } 

        private string GetFromWs()
        {
            string json = null;
            using (StreamReader r = new StreamReader("respuesta.json"))
            {
                json = r.ReadToEnd();

            }
            return json;
        }

    }
}
