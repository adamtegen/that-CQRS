using CqrsDemo.Models;

namespace CqrsDemo.DataAccess
{
    public class DemoDataAccess : IDataAccess
    {
        private readonly List<ProductModel> _all = new()
        {
            new ProductModel(1, "Chicken Soup"),
            new ProductModel(2, "Tomato Soup"),
        };

        public Task<ProductModel?> GetProductByIdAsync(int id)
        {
            return Task.FromResult(_all.FirstOrDefault(x => x.Id == id));
        }

        public Task<IEnumerable<ProductModel>> GetAllProductsAsync()
        {
            return Task.FromResult(_all.AsEnumerable());
        }

        public Task<int> CreateProductAsync(string name)
        {
            var id = _all.Max(x => x.Id) + 1;
            _all.Add(new ProductModel(id, name));
            return Task.FromResult(id);
        }
    }
}
