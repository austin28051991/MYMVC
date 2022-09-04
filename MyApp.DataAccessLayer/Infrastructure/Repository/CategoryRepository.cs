using MyApp.DataAccessLayer.Infrastructure.IRepository;
using MyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.DataAccessLayer.Infrastructure.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRespository
    {
        private readonly ApplicationDBContext _dbContext;
        public CategoryRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(Category category)
        {
            var categorydb=_dbContext.categories.FirstOrDefault(x=>x.Id==category.Id);
            if(categorydb!=null)
            {
                categorydb.Name=category.Name;
                categorydb.DisplayOrder=category.DisplayOrder;
            }
        }

        
    }
}
