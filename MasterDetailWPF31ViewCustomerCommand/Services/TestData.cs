using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using MasterDetailWPF31ViewCustomerCommand.Models;

namespace MasterDetailWPF31ViewCustomerCommand.Services
{
    static class TestData
    {
        public static Customer[] Customers { get; } = Enumerable
           .Range(1, 10)
           .Select(i => new Customer { FirstName = $"Customer FirstName {i}" })
           .ToArray();

        public static Order[] Orders { get; } = CreateOrders(Customers);

        private static Order[] CreateOrders(Customer[] customers)
        {
            var rnd = new Random();

            var index = 1;
            foreach (var customer in customers)
                for(var i = 0; i < 10; i++)
                    customer.Orders.Add(new Order
                    {
                        Description = $"Description - {index++}",                        
                        Quantity = rnd.NextDouble() * 100
                    });

            return customers.SelectMany(g => g.Orders).ToArray();
        }
    }
}
