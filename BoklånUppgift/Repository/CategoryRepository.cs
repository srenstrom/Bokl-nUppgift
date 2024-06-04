using BoklånUppgift.Interface;
using BoklånUppgift.Model;

namespace BoklånUppgift.Repository
{
    public class CategoryRepository : ICategory
    {
        public Task<Category> AddAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetAllAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
