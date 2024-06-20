using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryDAO
    {
        
        public List<Category> GetCategories()
        {
            var listCategories=new List<Category>();
            try
            {
            using var db = new MyStoreContext();
            listCategories= db.Categories.ToList();
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listCategories;
        }
        
    }
}
