using Core.Services;
using Core.Interfaces;
using Data.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using Microsoft.AspNetCore.Authorization;
using Data.Entities;

namespace WebDiningRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        //public readonly DiningRoomDbContext ctx;
        private readonly IMenuServices ctx;

        public MenuController(IMenuServices menuServices)
        {
            this.ctx = menuServices;
        }


        [HttpGet("all")]
        public async Task<IActionResult> GetOll()
        {

            return Ok(await ctx.GetAll());
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            // .. load data from database ..
            //var doctors = ctx.Doctors.Find(Id);
            //if (doctors == null) return NotFound();

            //return Ok(doctors);
            return Ok(await ctx.Get(Id));

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMenuDto model)
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
        public async Task<IActionResult> Edit(EditMenuDto model)
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
        [HttpPatch("Archive")]
        public async Task<IActionResult> ArchiveItem(int Id)
        {
            //var doctors = ctx.Doctors.Find(Id);
            //if (doctors == null) return NotFound();
            //doctors.Archived = true;
            //ctx.SaveChanges();
            //return Ok(doctors);
            await ctx.Archive(Id);
            return Ok();

            //return Ok(doctors);
            //var doctors = ctx.Doctors.Find(id);

            //if (doctors == null) return NotFound();

            //doctors.Archived = true;

            //ctx.SaveChanges();

            //return RedirectToAction("Index");
        }
        [HttpPatch("respons")]
        public async Task<IActionResult> RestoreItem(int Id)
        {
            //var doctors = ctx.Doctors.Find(Id);
            //if (doctors == null) return NotFound();
            //doctors.Archived = false;
            //ctx.SaveChanges();
            //return Ok();
            await ctx.Restore(Id);
            return Ok();
        }



    }
}
