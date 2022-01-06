using Codat.Public.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodatDemo.Models
{
    public class InvoiceModel
    {
        public string Id { get; set; }
        public DateTime DueDate { get; set; }
        public string Currency { get; set; }
        public string CustomerRefId { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int UnitAmount { get; set; }
    }
}
