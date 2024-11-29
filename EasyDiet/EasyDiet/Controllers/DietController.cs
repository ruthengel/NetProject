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
    public class DietController : ControllerBase
    {
        private readonly IDietServices _service;
        private readonly ICoachServices _coachService;
        public DietController(IDietServices service, ICoachServices coachService)
        {
            _service = service;
            _coachService = coachService;
        }

        //GET
        [HttpGet]
        public List<Diet> Get()
        {
            return _service.GetAll();
        }

        //GET BY PRICE
        [HttpGet("{price}")]
        public List<Diet> Get([FromQuery] int price)
        {
            return _service.GetAll().FindAll(d => d.Price <= price);
        }

        //GET BY CODE
        //[HttpGet("{code}")]
        //public Diet Get_by_code( int code)
        //{
        //    Diet d=Data.Diets.FirstOrDefault(diet => diet.Code == code);
        //    return d;
        //    //Diet d= Data.Diets.Find(diet => diet.Code == code);
        //    //if(d is null)
        //    //{
        //    //    return NotFound();
        //    //}
        //    //return Ok(d);
        //}

        // POST 
        [HttpPost]
        public ActionResult Post(string name, double price, int idcoach)
        {
            Coach coach = _coachService.GetAll().FirstOrDefault(c => c.Id == idcoach);
            if (coach is null)
                return NotFound();
            if (coach.Status)
            {
                Diet diet = new Diet(name, price, idcoach);
                coach.MyDiets.Add(diet);
                _service.GetAll().Add(diet);
            }
            return Ok();
        }

        // PUT
        [HttpPut("{code}")]
        public ActionResult Put(int id, [FromBody] string name, double price)
        {

            Diet diet = _service.GetAll().Find(d => d.Code == id);
            if (diet is null)
                return NotFound();
            if (diet.Status)
            {
                diet.Name = name;
                diet.Price = price;
            }
            return Ok();
        }

        // DELETE 
        [HttpDelete("{code}")]
        public ActionResult Delete(int id)
        {

            Diet d = _service.GetAll().Find(d => d.Code == id);
            if (d is null)
                return NotFound();
            d.Status = false;
            return Ok();
        }
    }
}
