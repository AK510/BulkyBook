using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class OrderHeaderRepository : Repository<OrderHeader>, IOrderHeaderRepository
	{
        private ApplicationDbContext _db;

        public OrderHeaderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

		public void UpdateStatus(int id, string status, string? paymentStatus)
		{
			var orderObj = _db.OrderHeader.FirstOrDefault(u => u.Id == id);
			if(orderObj != null)
			{
				orderObj.OrderStatus = status;
				if(paymentStatus != null)
				{
					orderObj.PaymentStatus = paymentStatus;
				}
			}
		}

		public void Update(OrderHeader obj)
		{
			_db.OrderHeader.Update(obj);
		}

		public void UpdateStripePaymentID(int id, string sessionId, string paymentIntentId)
		{
			var orderObj = _db.OrderHeader.FirstOrDefault(u => u.Id == id);
			orderObj.PaymentDate = DateTime.Now;
			orderObj.SessionId = sessionId;
			orderObj.PaymentIntentId= paymentIntentId;
		}
	}
}
