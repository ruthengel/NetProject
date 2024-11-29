using EasyDiet.Core.Interfaces;
using EasyDiet.Core.Models;
using EasyDiet.Core.Services;
using EasyDiet.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyDiet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : ControllerBase
    {

        private readonly ICoachServices _service;

        public CoachController(ICoachServices context)
        {
            _service = context;
        }

        // GET
        [HttpGet]
        public List<Coach> Get()
        {
            return _service.GetAll();
        }

        // GET BY ID
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Coach c = _service.GetAll().Find(c => c.Id == id);
            if (c is null)
                return NotFound();
            return Ok();
        }

        // POST 
        [HttpPost("  After registration, add your diet course to the diet database")]
        public void Post(int id, string name, string city, string phone)
        {
            _service.GetAll().Add(new Coach(id, name, city, phone));
        }

        // PUT 
        [HttpPut("{id}")]
        public ActionResult Put(int id, string Name, string city, string phone, bool status)
        {

            Coach coach = _service.GetAll().FirstOrDefault(c => c.Id.Equals(id));
            if (coach is null)
                return NotFound();
            coach.City = city;
            coach.Phone = phone;
            coach.Name = Name;
            coach.Status = status;
            return Ok();
        }

        // DELETE 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            Coach coach = _service.GetAll().Find(c => c.Id.Equals(id));
            if (coach is null)
                return NotFound();
            coach.Status = false;
            coach.MyDiets.ForEach(d => d.Status = false);
            return Ok();
        }




    }
}
