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
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRespository
    {
        private readonly ApplicationDBContext _dbContext;
        public OrderDetailRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(OrderDetail orderDetail)
        {
            _dbContext.OrderDetails.Update(orderDetail);
            //var categorydb=_dbContext.categories.FirstOrDefault(x=>x.Id==category.Id);
            //if(categorydb!=null)
            //{
            //    categorydb.Name=category.Name;
            //    categorydb.DisplayOrder=category.DisplayOrder;
            //}
        }

        
    }
}
