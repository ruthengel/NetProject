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
        public ActionResult<List<Coach>> Get()
        {
            return Ok(_service.GetList());
        }

        // GET BY ID
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Coach c = _service.GetById(id);
            if (c is null)
            {
                return NotFound($"Id: {id} is not exists");
            }
            return Ok(c);
        }

        // POST 
        [HttpPost("  After registration, add your diet course to the diet database")]
        public void Post(int id, string name, string city, string phone)
        {
            _service.AddCoach(id, name, city, phone);
        }

        // PUT 
        [HttpPut("{id}")]
        public ActionResult Put(int id, string Name, string city, string phone, bool status)
        {
            int result = _service.ChangeCoach(id, Name, city, phone, status);
            if (result == -1)
                return NotFound("Sorry, The update failed, please make sure the details you entered are correct.");
            return Ok($"The upadte was successful.");
        }

        // DELETE 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            int result = _service.RemoveCoach(id);
            if (result == -1)
                return NotFound($"The removal failed, please make sure the details you entered are correct.");
            return Ok($"The removal was successful.");
        }




    }
}
