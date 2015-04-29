using MoqExample.Data.Interfaces;
using MoqExample.Data.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoqExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataAccessRepository _dataRepository;
        public HomeController(IDataAccessRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        public ActionResult Index(int id)
        {   
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttPost]
        public int GetProjectCount(int id)
        {
            return _dataRepository.GetNoOfProjects(id);
        }

        [HttpGet]
        public bool CheckTheSampleModel(SampleComplexType input)
        {
            try
            {
                return _dataRepository.CheckTheComplexType(input);
            }
            catch (NotSupportedException e) 
            {
                throw new NotImplementedException(e.Message);
            }
        }

        public bool CheckTheEventMoreComplexModel(SampleEvenMoreComplexType input)
        {
            return _dataRepository.CheckTheComplexType(input);
        }
    }
}
