using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CronJob.Common.UnitofWork;
using CronJob.Data.Entities;
using CronJob.Dto;
using Microsoft.AspNetCore.Mvc;
using CronJob.Data.Entities;
using CronJob.Common.Repository;
using AutoMapper;

namespace CronJob.Controllers
{
    public class DefaultController : Controller
    {
        private IGenericRepository<Demo> _repository;
        private IUnitofWork _unitofwork;

        public DefaultController(IUnitofWork unitofWork, IGenericRepository<Demo> repository)
        {
            _repository = repository;
            _unitofwork = unitofWork;
        }
        public IActionResult Index()
        {

            try
            {
                var entities = _repository.GetAll().ToList();
                List<DemoDto> vari =
                     entities.Select(x => Mapper.Map<DemoDto>(x)).ToList();
            }
            catch (Exception ex)
            {
                List<DemoDto> a = null;
                
                   
                
            }
            return View();
        }
    }
}