using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using MasterDetailWPF31ViewCustomerCommand.Models.Interfaces;


namespace MasterDetailWPF31ViewCustomerCommand.Models
{    
    public class Order : IEntity
    {        
        public int Id { get; set; }
                
        public string Description { get; set; }
        
        public double Quantity { get; set; }

        //internal Order(Business.Order i)
        //{
        //    OrderId = i.OrderId;
        //    Description = i.Description;
        //    Quantity = i.Quantity;
        //}
        
    }
}