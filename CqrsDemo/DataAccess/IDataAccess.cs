using CqrsDemo.Models;

namespace CqrsDemo.DataAccess
{
    public interface IDataAccess
    {
        public Task<ProductModel?> GetProductByIdAsync(int id);
        public Task<IEnumerable<ProductModel>> GetAllProductsAsync();
        public Task<int> CreateProductAsync(string name);
    }
}
