﻿using EasyDiet.Core.Interfaces;
using EasyDiet.Core.Models;
using EasyDiet.Core.Services;
using EasyDiet.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EasyDiet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _service;
        private readonly ICoachServices _coachservice;
        private readonly IDietServices _dietservice;
        public CustomerController(ICustomerServices service, ICoachServices coachservice, IDietServices dietservice)
        {
            _service = service;
            _coachservice = coachservice;
            _dietservice = dietservice;
        }

        // GET 
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Customer c = _service.GetAll().Find(c => c.Id == id);
            if (c is null)
            {
                return NotFound();
            }
            return Ok(c);
        }

        // POST 
        [HttpPost]
        public void Post(int id, string name, int codeDiet)
        {
            Diet diet = _dietservice.GetAll().Find(d => d.Code == codeDiet);
            if (diet != null && diet.Status)
            {
                Coach coach = _coachservice.GetAll().FirstOrDefault(c => c.Id == diet.Coach);
                Customer customer = new Customer(id, name, diet);
                _service.GetAll().Add(customer);
                _coachservice.GetAll().Find(c => coach.Id == c.Id).MyCustomers.Add(customer);
            }
        }

        // PUT 
        [HttpPut("{id}")]
        public void Put(int id, string name, int codeDiet, bool status)
        {
            Customer customer = _service.GetAll().FirstOrDefault(c => c.Id == id);
            Diet diet = _dietservice.GetAll().FirstOrDefault(d => d.Code == codeDiet);
            if (customer != null && diet != null && diet.Status)
            {
                customer.Id = id;
                customer.Name = name;
                customer.Status = status;
                diet.Code = codeDiet;
                if (diet.Coach != customer.MyDiet.Coach)
                {
                    Coach coach = _coachservice.GetAll().FirstOrDefault(c => c.Id == customer.MyDiet.Coach);
                    coach.MyCustomers.Remove(customer);
                    coach.MyCustomers.Add(customer);
                }
                customer.MyDiet = diet;

            }
        }


        // DELETE 
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Customer customer = _service.GetAll().FirstOrDefault(c => c.Id == id);
            if (customer != null)
            {
                Coach coach = _coachservice.GetAll().FirstOrDefault(c => c.Id == customer.MyDiet.Coach);
                customer.Status = false;
                coach.MyCustomers.Remove(customer);
            }
        }
    }
}