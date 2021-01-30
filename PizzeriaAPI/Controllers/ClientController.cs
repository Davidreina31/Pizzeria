using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Data.Form;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Mappers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzeriaAPI.Controllers
{
    
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        ClientRepo clientRepo;
        List<Client> clientList;

        public ClientController()
        {
            clientRepo = new ClientRepo();
            clientList = new List<Client>();
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Client> Get()
        {
            clientList = clientRepo.Get();
            return clientList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Client Get(int id)
        {
            Client c = clientRepo.Get(id);
            return c;

        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] ClientForm client)
        {
            clientRepo.Create(client.ClientFormToClient());
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put([FromBody] ClientForm model)
        {
            clientRepo.Update(model.ClientFormToClient());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            clientRepo.Delete(id);
        }
    }
}
