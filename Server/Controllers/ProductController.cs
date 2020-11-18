using System;
using System.Threading.Tasks;
using BlazorPO.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorPO.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;

        public ProductController(ApplicationDbContext db)
        {
            this.db = db; //Injeção de Dependência!!!
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> Get()
        {
            var products = await db.Product.ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var product = await db.Product.SingleOrDefaultAsync(x => x.Id == Convert.ToInt32(id));
            return Ok(product);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult> Post([FromBody] Product product)
        {
            try
            {
                var newProduct = new Product
                {
                    Name = product.Name,
                    Price = product.Price,
                    Category = product.Category,
                    IdCategory = product.IdCategory
                    //Convert.ToInt32(animal.IdEspecie)
                };

                db.Add(newProduct);
                await db.SaveChangesAsync();//INSERT INTO
                return Ok();
            }
            catch (Exception e)
            {
                return View(e);
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Put([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(product).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw (ex);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await db.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            db.Product.Remove(product);
            await db.SaveChangesAsync();
            return Ok(product);
        }
    }
}