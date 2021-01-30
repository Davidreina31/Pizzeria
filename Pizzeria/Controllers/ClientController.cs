using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Form;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Mappers;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pizzeria.Controllers
{
    public class ClientController : Controller
    {
        ClientRepo clientRepo;
        List<Client> clientList;
        List<Pizza> pizzaList;
        public ClientController()
        {
            clientRepo = new ClientRepo();
            clientList = new List<Client>();
            pizzaList = new List<Pizza>();
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult Index()
        {
            clientList = clientRepo.Get();
            return View(clientList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ClientForm clientForm = new ClientForm();
            return View(clientForm);
        }

        [HttpPost]
        public IActionResult Create(ClientForm client)
        {
            if (ModelState.IsValid)
            {
                clientRepo.Create(client.ClientFormToClient());
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Details(int id)
        {
            Client c = clientRepo.Get(id);
            return View(c);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ClientForm c = clientRepo.Get(id).ClientToClientForm();
            return View(c);

        }

        [HttpPost]
        public IActionResult Edit(ClientForm model)
        {
            if (ModelState.IsValid)
            {
                clientRepo.Update(model.ClientFormToClient());
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            clientRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
