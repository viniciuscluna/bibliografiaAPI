using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NameProject.Domain.Entities;
using NameProject.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NameProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase, IDisposable
    {
        private readonly INameConstructorService _service;
        public NameController(INameConstructorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return Ok(await _service.GetAllNames());
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> ConvertUsers([FromBody] IEnumerable<string> users)
        {
            var result = await _service.ConvertNames(users);
            return Ok(result);
        }
        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
