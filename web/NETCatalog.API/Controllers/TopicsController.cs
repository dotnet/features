using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace NETCatalog.Api.Controllers
{
    [Route("topics")]
    public class TopicsController : Controller
    {
        public TopicsController(IMemoryCache cache)
        {
           _cache = cache;
        }

        private string _featuresPath = Path.Combine(AppContext.BaseDirectory, "features");
        private IMemoryCache _cache = null;


        [HttpGet]
        public string Get()
        {
            const string key = "categories";
            var categories = _cache.Get<string>(key);

            if (categories == null)
            {
                var dirNames = Directory.EnumerateDirectories(_featuresPath).Select(Path.GetFileName);
                categories = string.Join(Environment.NewLine, dirNames);
                _cache.Set(key, categories, TimeSpan.FromMinutes(5));
            }

            return categories;
        }

        [HttpGet("{category}")]
        public IActionResult Get(string category)
        {
            var concepts = _cache.Get<string>(category);
            
            if (concepts == null)
            {
                var categoryPath = Path.Combine(_featuresPath, category);

                if (!Directory.Exists(categoryPath))
                    return NotFound();

                var conceptList = Directory.EnumerateFiles(categoryPath).Select(Path.GetFileNameWithoutExtension);
                concepts = string.Join(Environment.NewLine, conceptList);
                _cache.Set(category, concepts, TimeSpan.FromMinutes(5));
            }

            return Ok(concepts);
        }

        [HttpGet("{category}/{concept}")]
        public IActionResult Get(string category, string concept)
        {
            var categoryPath = Path.Combine(_featuresPath, category);
            var conceptPath = Path.Combine(categoryPath, concept) + ".md";

            if (!System.IO.File.Exists(conceptPath))
                return NotFound();

            var contents = System.IO.File.ReadAllText(conceptPath);
            return Ok(contents);
        }
    }
}