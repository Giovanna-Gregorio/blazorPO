using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorPO.Shared;

namespace BlazorPO.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategoryController(ApplicationDbContext db)
        {
            this.db = db; //Injeção de Dependência!!!
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> Get()
        {
            var category = await db.Category.ToListAsync();
            return Ok(category);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var category = await db.Category.SingleOrDefaultAsync(x => x.Id == Convert.ToInt32(id));
            return Ok(category);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Post([FromBody] Category category)
        {
            try
            {
                var newCaterory = new Category
                {
                    Description = category.Description,
                };

                db.Add(newCaterory);
                await db.SaveChangesAsync();//INSERT INTO
                return Ok();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }
    }
}