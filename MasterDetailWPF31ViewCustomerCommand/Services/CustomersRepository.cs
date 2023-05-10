using System.Linq;
// using CV19.Models.Decanat;
// using CV19.Services.Base;

using MasterDetailWPF31ViewCustomerCommand.Models;
using MasterDetailWPF31ViewCustomerCommand.Services.Base;

namespace MasterDetailWPF31ViewCustomerCommand.Services
{
    public class CustomersRepository : RepositoryInMemory<Customer>
    {
        public CustomersRepository() : base(TestData.Customers) { }

        public Customer Get(string FirstName) => GetAll().FirstOrDefault(g => g.FirstName == FirstName);

        protected override void Update(Customer Source, Customer Destination)
        {
            Destination.FirstName = Source.FirstName;
            Destination.LastName = Source.LastName;
        }

        public bool Remove(Customer item)
        {
            bool isDeletsd = base.Remove(item);

            return isDeletsd;
        }
    }
}