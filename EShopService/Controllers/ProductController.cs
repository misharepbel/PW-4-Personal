using EShop.Application;
using EShop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EShopService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private IProductService _ps;
    public ProductController(IProductService ps)
    {
        _ps = ps;
    }
    
    // GET: api/<ProductController>
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var result = await _ps.GetAllAsync();
        return Ok(result);
    }

    // GET api/<ProductController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult> Get(int id)
    {
        var result = await _ps.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    // POST api/<ProductController>
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Product product)
    {
        var result = await _ps.AddAsync(product);
        return Ok(result);
    }

    // PUT api/<ProductController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] Product product)
    {
        var result = await _ps.UpdateAsync(product);
        return Ok(result);
    }

    // DELETE api/<ProductController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var product = await _ps.GetByIdAsync(id);
        product.Deleted = true;
        var result = await _ps.UpdateAsync(product);
        return Ok(result);
    }
}
