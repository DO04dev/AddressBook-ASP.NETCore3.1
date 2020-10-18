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

                if (data == null) return StatusCode((int)HttpStatusCode.NotFound, $"Could Not Found the record Of Id {id.ToString()}");

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

                var data = await this._context.Set<ContactDetail>().SingleOrDefaultAsync(x => x.ContactDetailId == id);


                //this._context.Entry(data).State = EntityState.Detached;


                data.ContactDetailId = value.ContactDetailId;
                data.Description = value.Description;
                data.Contact.ContactId = value.Contact.ContactId;
                data.Contact.FirstName = value.Contact.FirstName;
                data.Contact.Surname = value.Contact.Surname;
                data.Contact.UpdatedDate = value.Contact.UpdatedDate;
                data.Contact.BirthDate = value.Contact.BirthDate;
                data.ContactType.ContactTypeId = value.ContactType.ContactTypeId;
                data.ContactType.Address = value.ContactType.Address;
                data.ContactType.Telephone = value.ContactType.Telephone;
                data.ContactType.Cell = value.ContactType.Cell;
                data.ContactType.Email = value.ContactType.Email;

                //this._context.Attach<ContactDetail>(data);

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
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var data = await this._context
                .Set<ContactDetail>()
                .SingleOrDefaultAsync(x => x.ContactDetailId == id);

                if (data == null) return StatusCode((int)HttpStatusCode.NotFound, "Colud not find this record to delete");

                this._context.ContactDetails.Remove(data);

                var success = await this._context.SaveChangesAsync() > 0;


                return success ? Ok("Record deleted Successfully") : StatusCode((int)HttpStatusCode.InternalServerError, "somethismg Happend while trying to delete data");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, "Something happened with our server please try again later");
            }
        }
    }
}
