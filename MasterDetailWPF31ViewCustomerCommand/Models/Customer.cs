using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using MasterDetailWPF31ViewCustomerCommand.Models.Interfaces;


namespace MasterDetailWPF31ViewCustomerCommand.Models
{
    // [DataContract]
    public class Customer : IEntity
    {       
        public int Id { get; set; }
       
        public string FirstName { get; set; }
       
        public string LastName { get; set; }

        public IList<Order> Orders { get; set; } = new List<Order>();

        //internal Customer(Business.Customer i)
        //{
        //    CustomerId = i.CustomerId;
        //    FirstName = i.FirstName;
        //    LastName = i.LastName;
        //}       

    }
}