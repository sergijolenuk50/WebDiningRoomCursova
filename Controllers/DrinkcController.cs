﻿using Core.Dto;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebDiningRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkcController : ControllerBase
    {
        private readonly IDrinkcServices ctx;
        public DrinkcController(IDrinkcServices drinkcServices)
        {
            this.ctx = drinkcServices;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {

            return Ok(await ctx.GetAll());
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            // .. load data from database ..
            //var doctors = ctx.Doctors.Find(Id);
            //if (doctors == null) return NotFound();

            //return Ok(doctors);
            return Ok(await ctx.Get(Id));

        }



        // POST
        [HttpPost]
        public async Task<IActionResult> Create(CreateDrinkcDto model)
        {
            // TODO: add data validation
            //if (!ModelState.IsValid) return BadRequest();
            //ctx.Doctors.Add(model);
            //ctx.SaveChanges();
            //return Ok();
            await ctx.Create(model);
            return Ok();

        }




        [HttpPut]
        public async Task<IActionResult> Edit(EditDrinkcDto model)
        {


            //if (doctors == null) return NotFound();

            //if (!ModelState.IsValid) return BadRequest();
            //ctx.Doctors.Update(model);
            //ctx.SaveChanges();



            //return Ok();
            await ctx.Edit(model);
            return Ok();

        }



        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            //var product = ctx.Doctors.Find(id);
            //if (product == null) return NotFound();

            //ctx.Doctors.Remove(product);
            //ctx.SaveChanges();

            //return Ok();
            await ctx.Delete(id);
            return Ok();

        }

    }
}
