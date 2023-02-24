using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
	public class OrderDetailsRepository : Repository<OrderDetail>, IOrderDetailsRepository
	{
		private ApplicationDbContext _db;

        public OrderDetailsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

		public void Update(OrderDetail obj)
		{
			throw new NotImplementedException();
		}
	}
}
