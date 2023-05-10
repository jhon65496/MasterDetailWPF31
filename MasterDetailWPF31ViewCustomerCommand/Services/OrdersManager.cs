using System;
using System.Collections.Generic;
using System.Text;
// using CV19.Models.Decanat;
using MasterDetailWPF31ViewCustomerCommand.Models;

namespace MasterDetailWPF31ViewCustomerCommand.Services
{
    public class OrdersManager
    {   
        private readonly OrdersRepository _Orders;
        private readonly CustomersRepository _Customers;

        public IEnumerable<Order> Orders => _Orders.GetAll();

        public IEnumerable<Customer> Customers => _Customers.GetAll();

        public OrdersManager(OrdersRepository Orders, CustomersRepository Customers)
        {
            // _Orders = Orders;
            // _Customers = Groups;

            _Orders = Orders;
            _Customers = Customers;            
        }


        #region Order
        public bool Create(Order Order, string CustomerFirstName)
        {
            if (Order is null) throw new ArgumentNullException(nameof(Order));
            if(string.IsNullOrWhiteSpace(CustomerFirstName)) throw new ArgumentException("Некорректное имя группы", nameof(CustomerFirstName));

            var group = _Customers.Get(CustomerFirstName);
            if (group is null)
            {
                group = new Customer { FirstName = CustomerFirstName };
                _Customers.Add(group);
            }
            group.Orders.Add(Order);
            _Orders.Add(Order);
            return true;
        }

        public void Update(Order Order) => _Orders.Update(Order.Id, Order);
        #endregion


        #region Customer
        public bool Remove(Customer item) => _Customers.Remove(item);
        
        #endregion
    }
}
