using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Form;
using Data.Models;
using Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Mappers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PizzeriaAPI.Controllers
{
    [Route("api/[controller]")]
    public class RetourController : Controller
    {
        RetourRepo retourRepo;
        List<Retour> retourList;

        public RetourController()
        {
            retourRepo = new RetourRepo();
            retourList = new List<Retour>();
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Retour> Get()
        {
            retourList = retourRepo.Get();
            return retourList;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Retour Get(int id)
        {
            return retourRepo.Get(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] RetourForm retourForm)
        {
            retourRepo.Create(retourForm.RetourFormToRetour());
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] RetourForm retourForm)
        {
            retourRepo.Update(retourForm.RetourFormToRetour());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            retourRepo.Delete(id);
        }
    }
}
