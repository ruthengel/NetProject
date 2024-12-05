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
        public DietController(IDietServices service)
        {
            _service = service;
        }

        //GET
        [HttpGet]
        public ActionResult<List<Diet>> Get()
        {
            return Ok(_service.GetList());
        }

        //GET BY PRICE
        [HttpGet("{price}")]
        public ActionResult<List<Diet>> Get(/*[FromQuery]*/ int price)
        {
            List<Diet> result = _service.GetByPrice(price);
            if (result.Count == 0)
                return NotFound($"No diets found within the requested range.");
            return Ok(result);
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
            int result = _service.AddDiet(name, price, idcoach);
            if (result == -1)
                return NotFound("Sorry, The addition failed, please make sure the details you entered are correct.");
            return Ok($"The addition was successful.");
        }

        // PUT
        [HttpPut("{id}")]
        public ActionResult Put(int id,string name, double price)
        {
            int result = _service.ChangeDiet(id, name, price);
            if (result == -1)
                return NotFound($"The update failed, please make sure the details you entered are correct.");
            return Ok($"The update was successful.");
        }

        // DELETE 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            int result = _service.RemoveDiet(id);
            if (result == -1)
                return NotFound($"The removal failed, please make sure the details you entered are correct.");
            return Ok($"The removal was successful.");
        }
    }
}
