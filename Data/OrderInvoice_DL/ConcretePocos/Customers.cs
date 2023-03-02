
using System;
using OrderInvoice_Interfaces.DB_DTOs;
using Dapper;

namespace OrderInvoice_DL.ConcretePocos
{
    /// <summary>
    /// Represents a Customers.
    /// NOTE: This class is generated from a T4 template - you should not modify it manually.
    /// </summary>
	[Table("Customers")]
    public class Customers : ICustomers 
    {
		[Required]
		[Key]
        public int Objid { get; set; }
 
		
		
        public int Number { get; set; }
 
		
		
        public bool ShippingIsSameAsBilling { get; set; }
    }
}
