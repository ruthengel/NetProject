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
    public class WeightController : ControllerBase
    {
        private readonly IWeightServices _service;

        public WeightController(IWeightServices service)
        {
            _service = service;
        }

        // GET 
        [HttpGet("{id}")]
        public ActionResult<List<Weight>> Get(int id)
        {
            List<Weight> result = _service.GetById(id);
            //if (result.Count == 0)
            //    return NotFound($"The customer with the requested ID: {id} does not exist.");
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
