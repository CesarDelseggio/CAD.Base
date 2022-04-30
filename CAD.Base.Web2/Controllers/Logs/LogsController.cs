using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CAD.Base.DataAccess.Data.Models;
using CAD.Base.Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CAD.Base.Web.Controllers.Logs
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LogsController : ControllerBase
    {
        private readonly IService<Log> logService;

        //
        public LogsController(IService<Log> service)
        {
            logService = service;
        }

        // GET: api/Logs1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Log>>> GetLogs()
        {
            return await logService.GetAll();
        }

        // GET: api/Logs1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Log>> GetLog(int id)
        {
            var log = await logService.Get(id);

            if (log == null)
            {
                return NotFound();
            }

            return log;
        }

        // PUT: api/Logs1/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLog(int id, Log log)
        {
            if (id != log.Id)
            {
                return BadRequest();
            }

            try
            {
                logService.Update(log);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (! await logService.Exist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Logs1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Log>> PostLog(Log log)
        {
            logService.Create(log);
  
            return CreatedAtAction("GetLog", new { id = log.Id }, log);
        }

        // DELETE: api/Logs1/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Log>> DeleteLog(int id)
        {
            var log = await logService.Get(id);
            if (log == null)
            {
                return NotFound();
            }

            await logService.Delete(log);
            
            return log;
        }
    }
}
