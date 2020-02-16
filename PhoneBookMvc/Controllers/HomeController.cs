using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhoneBookMvc.Models;
using PhoneBookRepository.Interfaces;
using PhoneBookRepository.Tables;

namespace PhoneBookMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IPersonRepository _personRepository;

        public HomeController(ILogger<HomeController> logger, IPersonRepository personRepository)
        {
            _logger = logger;

            _personRepository = personRepository;
        }

        public IActionResult Index()
        {

            IndexModel indexModel = new IndexModel();

            indexModel.Init(_personRepository);

            return View(indexModel);
        }

        public IActionResult Add()
        {

            try
            {
                Person person = new Person();

                return View(person);
            }
            catch(Exception ex)
            {

            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Add(Person person)
        {

            try
            {
                _personRepository.Add(person);

                return Redirect("~/Home/Index");
            }
            catch (Exception ex)
            {

            }

            return View(person);
        }

        public IActionResult Edit(int id)
        {

            try
            {
                Person person = _personRepository.GetOneById(id);

                return View(person);
            }
            catch (Exception ex)
            {
                
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult Edit(Person person)
        {

            try
            {
                _personRepository.Update(person);

                return Redirect("~/Home/Index");
            }
            catch (Exception ex)
            {
                
            }

            return View(person);
        }

        public IActionResult Remove(int id)
        {

            try
            {
                _personRepository.RemoveById(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
               
            }

            return NoContent();
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
