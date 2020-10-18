using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AddressBook.Domain.Model.Models;
using AddressBook.Persistance.EntityFrameWorkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ContactController(ApplicationDBContext context)
        {
            this._context = context;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                var data = await this._context
                    .Set<ContactDetail>()
                    .ToListAsync();

                if (data == null) return StatusCode((int)HttpStatusCode.NoContent);

                return Ok(data);
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Something happened with our server please try again later");
            }

        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                var data = await this._context
                    .Set<ContactDetail>()
                    .SingleOrDefaultAsync(x => x.ContactDetailId == id);

                if (data == null) return StatusCode((int)HttpStatusCode.NoContent);

                return Ok(data);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Something happened with our server please try again later");
            }
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContactDetail value)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                this._context
                    .Set<ContactDetail>()
                    .Add(value);

                var success = await this._context.SaveChangesAsync() > 0;


                return success ? Ok("Record Add Successfully") : StatusCode((int)HttpStatusCode.InternalServerError, "somethismg Happend while trying to add data");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Something happened with our server please try again later");
            }
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, [FromBody] ContactDetail value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var data = await this._context.Set<ContactDetail>().FindAsync(id);

                data = value;

                this._context
                    .Set<ContactDetail>()
                    .Update(data);

                var success = await this._context.SaveChangesAsync() > 0;


                return success ? Ok("Record Updated Successfully") : StatusCode((int)HttpStatusCode.InternalServerError, "somethismg Happend while trying to Update data");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Something happened with our server please try again later");
            }
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
