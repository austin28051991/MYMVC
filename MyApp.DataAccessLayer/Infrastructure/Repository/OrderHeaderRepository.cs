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
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRespository
    {
        private readonly ApplicationDBContext _dbContext;
        public OrderHeaderRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void Update(OrderHeader orderHeader)
        {
            _dbContext.OrderHeaders.Update(orderHeader);


            //var categorydb=_dbContext.categories.FirstOrDefault(x=>x.Id==orderHeader.Id);
            //if(categorydb!=null)
            //{
            //    categorydb.Name=category.Name;
            //    categorydb.DisplayOrder=category.DisplayOrder;
            //}
        }

        public void UpdateStatus(int Id, string orderStatus, string? paymentStatus = null)
        {
            var order = _dbContext.OrderHeaders.FirstOrDefault(x => x.Id == Id);
        if(order!=null)
            {
                order.OrderStatus = orderStatus;
            }
        if(paymentStatus!=null)
            {
                order.PaymentStatus = paymentStatus;
            }
        }
    }
}
