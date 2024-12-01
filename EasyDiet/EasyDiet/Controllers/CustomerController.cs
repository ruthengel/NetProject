using EasyDiet.Core.Interfaces;
using EasyDiet.Core.Models;
using EasyDiet.Core.Services;
using EasyDiet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyDiet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _service;
        public CustomerController(ICustomerServices service)
        {
            _service = service;
        }

        // GET 
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Customer c = _service.GetById(id);
            if (c is null)
            {
                return NotFound($"Id: {id} is not exists");
            }
            return Ok(c);
        }

        // POST 
        [HttpPost]
        public ActionResult Post(int id, string name, int codeDiet)
        {
            int result = _service.AddCustomer(id, name, codeDiet);
            if (result == -1)
                return NotFound("Sorry, The addition failed, please make sure the details you entered are correct.");
            return Ok($"The addition was successful.");
        }

        // PUT 
        [HttpPut("{id}")]
        public ActionResult Put(int id, string name, int codeDiet, bool status)
        {
            int result = _service.ChangeCustomer(id, name, codeDiet, status);
            if (result == -1)
                return NotFound($"The update failed, please make sure the details you entered are correct.");
            return Ok($"The update was successful.");
        }


        // DELETE 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            int result = _service.RemoveCustomer(id);
            if (result == -1)
                return NotFound($"The removal failed, please make sure the details you entered are correct.");
            return Ok($"The removal was successful.");
        }
    }
}
