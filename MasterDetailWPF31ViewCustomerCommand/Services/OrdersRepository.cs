using MasterDetailWPF31ViewCustomerCommand.Models;
using MasterDetailWPF31ViewCustomerCommand.Services.Base;

namespace MasterDetailWPF31ViewCustomerCommand.Services
{
    public class OrdersRepository : RepositoryInMemory<Order>
    {
        public OrdersRepository() : base(TestData.Orders) { }

        protected override void Update(Order Source, Order Destination)
        {
            Destination.Description = Source.Description;
            Destination.Quantity = Source.Quantity;
        }


    }
}
