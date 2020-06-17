using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContaBill.Data;
using ContaBill.Models;

namespace ContaBill.Controllers
{
  [ApiController]
  [Route("v1/categories")]
  public class CategoryController : ControllerBase
  {
    public async Task<ActionResult<IEnumerable<Category>>> Get([FromServices] DataContext context)
    {
      var categories = await context.Categories.ToListAsync();
      return categories;
    }
  }
}
