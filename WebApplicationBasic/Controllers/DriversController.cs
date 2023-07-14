using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationBasic.Data;
using WebApplicationBasic.Models;

namespace WebApplicationBasic.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DriversController : ControllerBase
{
   private readonly ApiDbContext _context;

   public DriversController(ApiDbContext _context)
   {
      this._context = _context;
      
   }

   [HttpGet]
   public async Task<IActionResult>Get()
   {
      return Ok(await _context.Drivers.ToListAsync());
      
   }

   [HttpGet]
   [Route ( "GetById" )]
   public async Task<IActionResult> Get(int id)
   {
      var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);
      if (driver == null) return NotFound() ;
      return Ok(driver);

   }
   [HttpPost]
   [Route("AddDriver")]
   public async Task<IActionResult> AddDriver(Driver driver)
   {

      _context.Drivers.Add(driver);
       await _context.SaveChangesAsync();
      return Ok();



   }
   
   [HttpDelete]
   [Route (template: "DeleteDriver")]
   public async Task<IActionResult> DeleteDriver(int id)
   {
      var driver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == id);

      if (driver == null) return NotFound();
      
      _context. Drivers.Remove(driver);  
      await _context.SaveChangesAsync();
      return NoContent();
   
}
   
   [HttpPatch]
   [Route ( "UpdateDriver")]
   public async Task<IActionResult> UpdateDriver (Driver driver)
   {
      var existDriver = await _context.Drivers.FirstOrDefaultAsync(x => x.Id == driver.Id);

      if (existDriver == null) return NotFound();
      existDriver. Name = driver. Name;
      existDriver. Team = driver. Team;
      existDriver. DriverNumber = driver. DriverNumber;
      await _context.SaveChangesAsync();
      return NoContent ();
}
   
}
