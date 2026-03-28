using WebAppDemo28_3.Models;

namespace WebAppDemo28_3.Services
{
    public interface IProduct
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> AddAsync(Product product);
        Task<Product?> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
}
