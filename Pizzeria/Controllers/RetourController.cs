using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Form;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Mappers;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pizzeria.Controllers
{
    public class RetourController : Controller
    {

        RetourRepo retourRepo;
        List<Retour> retourList;

        public RetourController()
        {
            retourRepo = new RetourRepo();
            retourList = new List<Retour>();
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            retourList = retourRepo.Get();
            return View(retourList);
        }

        public IActionResult Details(int id)
        {
            Retour retour = retourRepo.Get(id);
            return View(retour);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RetourForm retour)
        {
            if (ModelState.IsValid)
            {
                retourRepo.Create(retour.RetourFormToRetour());
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            RetourForm retourForm = retourRepo.Get(id).RetourToRetourForm();
            return View(retourForm);
        }

        [HttpPost]
        public IActionResult Edit(RetourForm retour)
        {
            if (ModelState.IsValid)
            {
                retourRepo.Update(retour.RetourFormToRetour());
                return RedirectToAction("Index");
            }
            return View(retour);
        }

        public IActionResult Delete(int id)
        {
            retourRepo.Delete(id);
            return RedirectToAction("index");
        }
    }
}
