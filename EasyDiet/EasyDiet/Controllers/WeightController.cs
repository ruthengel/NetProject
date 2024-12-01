using EasyDiet.Core.Interfaces;
using EasyDiet.Core.Models;
using EasyDiet.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyDiet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightController : ControllerBase
    {
        private readonly WeightServices _service;

        public WeightController(WeightServices service)
        {
            _service = service;
        }

        // GET 
        [HttpGet("{id}")]
        public ActionResult<List<Weight>> Get(int id)
        {
            int result = _service.GetById(id);
            if (result == -1)
                return NotFound($"The customer with the requested ID: {id} does not exist.");
            return Ok(result);
        }

        // POST 
        [HttpPost]
        public ActionResult Post(int id, double weight)
        {
            int result = _service.AddWeight(id, weight);
            if (result == -1)
                return NotFound("Sorry, The addition failed, please make sure the details you entered are correct.");
            return Ok($"The addition was successful.");
        }
    }
}
