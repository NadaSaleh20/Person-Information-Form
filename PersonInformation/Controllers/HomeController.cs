using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonInformation.Data;
using PersonInformation.Models;
using PersonInformation.Repostry;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PersonInformation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserInfoRepostry _iUserInfoRepostry;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly Dbcontext _dbcontext;

        public HomeController(ILogger<HomeController> logger , IUserInfoRepostry IUserInfoRepostry , IWebHostEnvironment webHostEnvironment , Dbcontext dbcontext)
        {
            _logger = logger;
            _iUserInfoRepostry = IUserInfoRepostry;
         _webHostEnvironment = webHostEnvironment;
           _dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult AddPersonInfo( bool isAdded )
        {
            ViewBag.isAdded = isAdded;
            
            return View();
        }

       [HttpPost]

        public async Task <IActionResult> AddPersonInfo(PersonInfo personInfo)
        {
            if (ModelState.IsValid)
            {
                if (personInfo.img != null)
                {
                    string folder = "img/";
                    folder += Guid.NewGuid() + "_" + personInfo.img.FileName;
                    personInfo.imgURL = $"/{folder}";
                    string serverfolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                    await personInfo.img.CopyToAsync(new FileStream(serverfolder, FileMode.Create));

                }

                 int id =await _iUserInfoRepostry.Addperson(personInfo);

                if (id >0)
                {
                    return RedirectToAction(nameof(AddPersonInfo) , new { isAdded = true });
                }
            }
            return View();
        }

        public async Task<IActionResult> GetAllBookInfo()
        { 
           var obj =await _iUserInfoRepostry.Getinfopersons();

            return View("GetAllBookInfo", obj);
        }

        public  IActionResult GetCities( int CountryId)
        {
             var obj =_dbcontext.City.Where(a => a.CountryId == CountryId).ToList();

            return Ok(obj);
        }

    }
}
