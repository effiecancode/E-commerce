using DatabaseAccessLayer.EcommerceDBContext;
using DatabaseAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.BusinessLogic
{
    public class CategoryBusinessLogic : ICategoryBusinessLogic
    {
        private readonly EcommerceContext econtext; //can only be only be instanciated in the constructor
        public CategoryBusinessLogic(EcommerceContext ecommerceContext)
        {
            econtext = ecommerceContext;
        }
        public Guid AddCategory(Category category)
        {
            econtext.Categories.Add(category);
            econtext.SaveChanges();
            return category.Id;
        }
        public List<Category> GetCategories()
        {
            return econtext.Categories.ToList();
        }
    }
}
