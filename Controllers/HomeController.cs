using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using Upload_File_Pjt.Models;
using Upload_File_Pjt.Helper;
using Upload_File_Pjt.Repository;

namespace Upload_File_Pjt.Controllers
{
    public class HomeController : Controller
    {
        private UploadHelper helper ;
        private readonly UploadRepository _xmlUploadRepository =null;

        public HomeController(UploadRepository xMLUploadRepository)
        {
            _xmlUploadRepository = xMLUploadRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ImportFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Import(IFormFile postedFile, [FromServices] IWebHostEnvironment env)
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "Upload";
            string webRootPath = env.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);
            StringBuilder sb = new StringBuilder();
            bool isSuccessXml = false;
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)
            {
                string fullPath = Path.Combine(newPath, file.FileName);
                helper = new UploadHelper(_xmlUploadRepository);
                
                if (file.ContentType == "text/xml")
                {
                    isSuccessXml = helper.parseXML(fullPath);
                }
                else
                {
                    using (FileStream stream = new FileStream(fullPath, FileMode.Create))
                    {
                        postedFile.CopyTo(stream);
                    }
                    isSuccessXml = helper.parseCSV(fullPath);
                }
                
            }
            if (!isSuccessXml)
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { message = "Invalid Input Data" });
            }
            return StatusCode(StatusCodes.Status200OK, new { message = "Successfully Upload Data!!" });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}