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
        private readonly CustomerServices _service;

        public WeightController(CustomerServices service)
        {
            _service = service;
        }

        // GET 
        [HttpGet("{id}")]
        public List<Weight> Get(int id)
        {
            return _service.GetAll().FirstOrDefault(c => c.Id == id).MyWeigths;
        }

        // POST 
        [HttpPost]
        public void Post(int id, double weight)
        {

            Customer c = _service.GetAll().FirstOrDefault(c => c.Id == id);
            if (c != null)
                c.MyWeigths.Add(new Weight(DateTime.Now, weight));
        }
    }
}
