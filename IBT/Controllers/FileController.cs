using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Linq;

namespace IBT.Controllers
{
    public class FileController : Controller
    {
        private readonly IStringLocalizer _localizer;

        public FileController(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            _localizer = factory.Create(type);
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