using DownloadApp.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DownloadApp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class FileController : Controller
    {
        [Authorize]
        [HttpGet]
        [Route("ShowFiles")]
        public IActionResult Index()
        {
            string[] filePaths = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Files/"));

            List<FileModel> files = new List<FileModel>();
            foreach (string filePath in filePaths)
            {
                files.Add(new FileModel { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
        }

        [Authorize]
        public FileResult DownloadFile(string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Files/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}