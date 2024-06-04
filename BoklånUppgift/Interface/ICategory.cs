using BoklånUppgift.Model;

namespace BoklånUppgift.Interface
{
    public interface ICategory
    {
        public Task GetByIdAsync(int id);
        public Task<Category> GetAllAsync(Category category);
        public Task<Category> AddAsync(Category category);
      
    }
}
