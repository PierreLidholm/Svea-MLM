
using Microsoft.AspNetCore.Mvc;
using MLM.Service.Services;

namespace Svea_MLM.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MLMController : Controller
  {
      private ISalesmanService salesmanService;

      public MLMController(ISalesmanService salesmanService)
      {
          this.salesmanService = salesmanService;
      }

      [HttpGet("get")]
      public ActionResult Get([FromQuery] int columns, [FromQuery] int rows, [FromQuery] int totalRuns)
      {
          if (columns <= 0 || rows <= 0 || totalRuns <= 0)
          {
              return BadRequest("Invalid length, width or total runs.");
          }

          var result = salesmanService.SimulateMLM(columns, rows, totalRuns);
          return Ok(result); 
      }
  }
}
