using AspNetCoreDapper.Domain.Entities;
using AspNetCoreDapper.Domain.Interfaces;

namespace AspNetCoreDapper.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
    }
}
