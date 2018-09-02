using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using System.Linq;

namespace IBT.Controllers
{
    public class FileController : Controller
    {
        private readonly IStringLocalizer _localizer;
        private readonly IConfiguration _configuration;

        public FileController(IStringLocalizerFactory factory, IConfiguration configuration)
        {
            var type = typeof(SharedResource);
            _localizer = factory.Create(type);
            _configuration = configuration;
        }

        public FileResult Index(string file)
        {
            var filename = _localizer.GetString(file);
            var stream = Resources.Files.ResourceManager.GetMemoryStream(file);
            return File(stream, "application/msword", $"{filename}.docx");
        }

        public FileResult Abu(int id)
        {
            if(!new int[] { 5,10,25 }.Any(q => q == id))
            {
                id = 25;
            }

            var abu = _localizer.GetString("Abu", id);
            var filename = _localizer.GetString("abuSpecsFilename");
            var stream = Resources.Files.ResourceManager.GetMemoryStream($"abu{id}specs");
            return File(stream, "application/msword", $"{abu} {filename}.docx");
        }
    }
}