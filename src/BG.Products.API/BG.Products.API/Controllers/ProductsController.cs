using BG.Products.API.Domain;
using BG.Products.API.Domain.DTO;
using BG.Products.API.Interfaces;
using BG.Shared;
using BG.Shared.APIResponse;
using Microsoft.AspNetCore.Mvc;


namespace BG.Products.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProduct repository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products = await repository.GetAllAsync();
            if (!products.Any())
                return NotFound(AppConstants.NoProductsFound);

            var (_, list) = ModelHelper.FromEntity(null!, products);
            return list!.Any() ? Ok(list) : NotFound(AppConstants.NoProductsFound);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id) 
        {
            var product = await repository.FindByIdAsync(id);
            if (product is null)
                return NotFound(AppConstants.ProductNotFount);

            var (_product, _) = ModelHelper.FromEntity(product, null!);
            return _product is not null ? Ok(_product) : NotFound(AppConstants.ProductNotFount);
        }


        [HttpPost]
        public async Task<ActionResult<Response>> CreateProduct(ProductDTO product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newEntity = ModelHelper.ToEntity(product);
            var response = await repository.CreateAsync(newEntity);
            return response.flag is true ? Ok(response) : BadRequest(response);
        }

        [HttpPut]
        public async Task<ActionResult<Response>> UpdateProduct(ProductDTO product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var newEntity = ModelHelper.ToEntity(product);
            var response = await repository.UdateAsync(newEntity);
            return response.flag is true ? Ok(response) : BadRequest(response);

        }

        [HttpDelete]
        public async Task<ActionResult<Response>> DeleteProduct(ProductDTO product)
        {
            var entity = ModelHelper.ToEntity(product);
            var response = await repository.DeleteAsync(entity);
            return response.flag is true ? Ok(response) : BadRequest(response);
        }
    }
}
