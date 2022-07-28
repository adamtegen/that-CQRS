using CqrsDemo.DataAccess;
using CqrsDemo.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDemo.Queries
{
    public class GetProductById: IRequest<ProductModel?>
    {
        [FromRoute]
        public int Id { get; set; }
    }

    public class GetProductByIdHandler: IRequestHandler<GetProductById, ProductModel?> 
    {
        private readonly IDataAccess _data;
        public GetProductByIdHandler(IDataAccess data)
        {
            _data = data;
        }

        public Task<ProductModel?> Handle(GetProductById request, CancellationToken cancellation)
        {
            return _data.GetProductByIdAsync(request.Id);
        }
    }
}
