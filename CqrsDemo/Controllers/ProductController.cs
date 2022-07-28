using CqrsDemo.Models;
using CqrsDemo.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public Task<ProductModel?> Get([FromRoute] GetProductById request)
        {
            return _mediator.Send(request);
        }

        [HttpGet("")]
        public Task<IEnumerable<ProductModel>> GetAll()
        {
            return _mediator.Send(new GetAllProducts());
        }

        [HttpPost("")]
        public Task<ProductModel> Create([FromBody]CreateProduct request)
        {
            return _mediator.Send(request);
        }
    }
}