using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CronJob.Models;
using Microsoft.Extensions.Logging;
using CronJob.Data;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace CronJob.Controllers
{
    public class HomeController : Controller
    {
        private CronDbContext _context;
        private ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, CronDbContext cronDbContext)
        {
            _context = cronDbContext;
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogError("Index kibana");
            _logger.LogCritical("Index Critical");

            var model =_context.Demos.ToList();
            return View(model);
            //return Content("Jobs are running...");
        }

        public IActionResult Privacy()
        {
            _logger.LogError("Index kibana");
            _logger.LogCritical("Index Critical");
            XmlReader reader = new XmlReader();
            //re.XmlRead(@"http://aiweb.cs.washington.edu/research/projects/xmltk/xmldata/data/auctions/ebay.xml");
            var url = @"http://aiweb.cs.washington.edu/research/projects/xmltk/xmldata/data/auctions/ebay.xml";
            var model= reader.GetXmlRequest<ebay.Root>(url);
            using (var client = new WebClient())
            {
                client.DownloadFile(url, @"C:\Users\hyarimaga\Desktop\New folder\ebaycik.xml");
            }
            return View(model);
            //return Content("Jobs are running...");
        }

        public IActionResult Detail(int id)
        {
            var model = _context.Demos.FirstOrDefault(x => x.DemoId == id);
            return View(model);
            //return Content("Jobs are running...");
        }
        public IActionResult About()
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
