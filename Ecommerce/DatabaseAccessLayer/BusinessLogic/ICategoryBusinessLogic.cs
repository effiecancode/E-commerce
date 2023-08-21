using DatabaseAccessLayer.Models;

namespace DatabaseAccessLayer.BusinessLogic
{
    public interface ICategoryBusinessLogic
    {
        Guid AddCategory(Category category);
        List<Category> GetCategories();
    }
}