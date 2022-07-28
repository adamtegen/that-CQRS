using CqrsDemo.DataAccess;
using CqrsDemo.Models;
using MediatR;

namespace CqrsDemo.Queries
{
    public record CreateProduct(string Name) : IRequest<ProductModel>;

    public class CreateProductHandler: IRequestHandler<CreateProduct, ProductModel> 
    {
        private readonly IDataAccess _data;
        public CreateProductHandler(IDataAccess data)
        {
            _data = data;
        }

        public async Task<ProductModel> Handle(CreateProduct request, CancellationToken cancellation)
        {
            var id = await _data.CreateProductAsync(request.Name);
            return new ProductModel(id, request.Name);
        }
    }
}
