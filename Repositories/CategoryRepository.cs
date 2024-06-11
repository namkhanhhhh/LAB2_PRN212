using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        public CategoryDAO categoryDAO=new CategoryDAO();
        public List<Category> GetCategories()=> categoryDAO.GetCategories();
    }
}
