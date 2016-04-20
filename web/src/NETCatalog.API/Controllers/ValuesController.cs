using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace NETCatalog.Api.Controllers
{
    [Route("topics")]
    public class ConceptsController : Controller
    {
        public ConceptsController()
        {
        }

        [HttpGet]
        public async Task<string> Get()
        {
            var featurePath = GetFeaturePath();
            var categories = Directory.EnumerateDirectories(featurePath).Select(Path.GetFileName);
            var names = string.Join(Environment.NewLine, categories);
            return names;
        }

        [HttpGet("{category}")]
        public async Task<IActionResult> Get(string category)
        {
            var featurePath = GetFeaturePath();
            var conceptsPath = Path.Combine(featurePath, category);

            if (!Directory.Exists(conceptsPath))
                return NotFound();

            var concepts = Directory.EnumerateFiles(conceptsPath).Select(Path.GetFileNameWithoutExtension);
            var names = string.Join(Environment.NewLine, concepts);
            return Ok(names);
        }

        [HttpGet("{category}/{concept}")]
        public async Task<IActionResult> Get(string category, string concept)
        {
            var featurePath = GetFeaturePath();
            var categoryPath = Path.Combine(featurePath, category);
            var conceptPath = Path.Combine(categoryPath, concept) + ".md";

            if (!System.IO.File.Exists(conceptPath))
                return NotFound();

            var contents = System.IO.File.ReadAllText(conceptPath);
            return Ok(contents);
        }

        private static string GetFeaturePath()
        {
            var rootPath = GetRepositoryRoot();
            return Path.Combine(rootPath, "features");
        }

        private static string GetRepositoryRoot()
        {
            var baseDirectoryPath = AppContext.BaseDirectory;
            var repositoryPath = Path.Combine(Path.GetDirectoryName(baseDirectoryPath), "repository");

            // Production

            if (Directory.Exists(repositoryPath))
                return repositoryPath;

            // Development

            var featurePath = AppContext.BaseDirectory;
            for (var i = 0; i < 6; i++)
                featurePath = Path.GetDirectoryName(featurePath);
            return featurePath;
        }
    }
}