using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ivt_ass.Models;
using Infrastructure.UnitOfWork;
using Core.Entities;
using Core.Interfaces;

namespace ivt_ass.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        public IUnitOfWork<Category> _category { get; }
        public IUnitOfWork<CServices> _cServices { get; }
        public IUnitOfWork<SubServices> _subServices { get; }
        public IUnitOfWork<Partners> _partners { get; }
        public HomeController(
           IUnitOfWork<Category> category,
           IUnitOfWork<CServices> cServices,
           IUnitOfWork<SubServices> subServices,
           IUnitOfWork<Partners> partners)
        {
            _category = category;
            _cServices = cServices;
            _subServices = subServices;
            _partners = partners;
        }
        /* public HomeController(ILogger<HomeController> logger)
         {
             _logger = logger;

         }*/

        public IActionResult Index()
        {

            var homeViewModel = new HomeViewModel
            {
                category = _category.Entity.GetAll().ToList(),
                cServices = _cServices.Entity.GetAll().ToList(),
                subServices = _subServices.Entity.GetAll().ToList(),
                partners = _partners.Entity.GetAll().ToList()

            };
            return View(homeViewModel);
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
