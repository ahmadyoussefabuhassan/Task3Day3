using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task3Day3.Application.Products.Command.AddProduct;
using Task3Day3.Application.Products.Command.DeleteProduct;
using Task3Day3.Application.Products.Command.UpdateProduct;
using Task3Day3.Application.Products.Queries.GetAllProducts;
using Task3Day3.Application.Products.Queries.GetByIdProduct;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Task3Day3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ISender _sender;

        public ProductsController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProduct(Guid id , CancellationToken cancellationToken = default)
        {
            var query = new GetByIdProductQuery(id);
            var result = await _sender.Send(query, cancellationToken);
            return Ok(result);
        }
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts(CancellationToken cancellationToken)
        {
            var query = new GetAllProductsQuery();
            var result = await _sender.Send(query, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }
        [HttpPost("AddProduct")]
        public async Task<IActionResult> Add([FromForm] AddProductCommand command , CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> Update([FromForm] UpdateProductCommand command, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
        }
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id , CancellationToken cancellationToken)
        {
            var command = new DeleteProductCommand(id);
            var result = await _sender.Send(command, cancellationToken);
            return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
        }
    }
}
