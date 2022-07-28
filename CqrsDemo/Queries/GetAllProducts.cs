using CqrsDemo.DataAccess;
using CqrsDemo.Infrastructure;
using CqrsDemo.Models;
using MediatR;

namespace CqrsDemo.Queries
{
    public class GetAllProducts : ContextualRequest<IEnumerable<ProductModel>>
    {
    }

    public class GetAllProductsHandler: IRequestHandler<GetAllProducts, IEnumerable<ProductModel>> 
    {
        private readonly IDataAccess _data;
        public GetAllProductsHandler(IDataAccess data)
        {
            _data = data;
        }

        public Task<IEnumerable<ProductModel>> Handle(GetAllProducts request, CancellationToken cancellation)
        {
            return _data.GetAllProductsAsync();
        }
    }
}
