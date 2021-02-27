using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReactCRUD.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactCRUD.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    [EnableCors("ReactPolicy")]
    public class UsersController : ControllerBase
    {
        private readonly UserService userService;
        public UsersController(UserService userService)
        {
            this.userService = userService;
        }
      
        //The GET api/users requests

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return userService.GetAll();
        }

        // The GET api/users/5 request

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(userService.GetById(id));
        }
       
        // The POST api/users request

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            return CreatedAtAction("Get", new { id = user.Id }, userService.Create(user));

        }

        // The PUT api/users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User user)
        {
            userService.Update(id, user);
            return NoContent();

        }

        // The DELETE api/users/5 request

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            userService.Delete(id);
            return NoContent();
        }
        public override NoContentResult NoContent()
        {
            return base.NoContent();
        }
    }
}
