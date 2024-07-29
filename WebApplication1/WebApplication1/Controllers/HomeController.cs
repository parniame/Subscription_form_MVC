using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WebApplication1.Models;
using Utilities;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Subscription()
        {
            return View();
        }
        public IActionResult Rules()
        {
            return View();
        }
        public IActionResult Submit(FormViewModel form)
        {

           
            if (form != null)
            {
                if (Utilities.Validate.ValidateForm(form))
                {
                    var jForm = Json(form);



                    string docPath =
                      Directory.GetCurrentDirectory();

                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "file/WriteLines.txt")))
                    {
                        string sForm = JsonSerializer.Serialize(jForm);
                        outputFile.WriteLine(sForm);
                    }
                    return jForm;
                }
            }
            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
