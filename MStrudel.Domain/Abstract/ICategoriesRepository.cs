using MStrudel.Domain.Entities;
using System.Collections.Generic;

namespace MStrudel.Domain.Abstract
{
    public interface ICategoriesRepository
    {
        IEnumerable<Category> Categories { get; }
        void SaveCategory(Category category);
        void DeleteCategory(int categoryId);
    }
}
