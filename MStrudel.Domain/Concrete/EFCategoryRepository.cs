using MStrudel.Domain.Abstract;
using MStrudel.Domain.Entities;
using System.Collections.Generic;

namespace MStrudel.Domain.Concrete
{
    public class EFCategoryRepository : ICategoriesRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Category> Categories
        {
            get { return context.Categories; }
        }

        public void SaveCategory(Category category)
        {
            if(category.CategoryId == 0)
            {
                context.Categories.Add(category);
            }
            else
            {
                Category categoryToEdit = context.Categories.Find(category.CategoryId);
                if(categoryToEdit != null)
                {
                    categoryToEdit.Name = category.Name;
                    categoryToEdit.SortId = category.SortId;
                }
            }
            context.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            Category item = context.Categories.Find(categoryId);
            if(item != null)
            {
                context.Categories.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
