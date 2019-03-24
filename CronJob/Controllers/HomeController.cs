using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CronJob.Models;
using Microsoft.Extensions.Logging;
using CronJob.Data;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using CronJob.Common.UnitofWork;
using System.Threading.Tasks;
using CronJob.Common.Repository;
using CronJob.Dto;
using AutoMapper;
using System.Collections.Generic;
using System;

namespace CronJob.Controllers
{

    public class HomeController : Controller
    {
        //private IGenericRepository<CronJob.Data.Entities.Demo> _repository;
        private IUnitofWork _unitofwork;
        //private CronDbContext _context;
        private ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IUnitofWork unitofWork)
        {
            _unitofwork = unitofWork;
            //_context = cronDbContext;
            _logger = logger;
        }
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        
        public IActionResult Index()
        {
             var a = _unitofwork.GetRepository<CronJob.Data.Entities.Demo>();
            _logger.LogError("Index kibana");
            //var model=  _unitofwork.GetRepository<CronJob.Data.Entities.Demo>().GetAll();
            var model = a.GetAll();

            //var model =_context.Demos.ToList();
            return View(model);
            //return Content("Jobs are running...");
        }

        
        public IActionResult Privacy()
        {
            _logger.LogError($"Index Privacy {DateTime.Now}");
            XmlReader reader = new XmlReader();
            //re.XmlRead(@"http://aiweb.cs.washington.edu/research/projects/xmltk/xmldata/data/auctions/ebay.xml");
            var url = @"http://aiweb.cs.washington.edu/research/projects/xmltk/xmldata/data/auctions/ebay.xml";
            var model= reader.GetXmlRequest<ebay.Root>(url);
            //using (var client = new WebClient())
            //{
            //    client.DownloadFile(url, @"C:\Users\hyarimaga\Desktop\New folder\ebaycik.xml");
            //}
            return View(model);
            //return Content("Jobs are running...");
        }

        public IActionResult Detail(int id)
        {
            //var model = _context.Demos.FirstOrDefault(x => x.Id == id);
            //return View(model);
            return View();
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
