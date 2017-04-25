using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesQueries
{
    public class Sale
    {
        public String Item { get; set; }
        public String Customer { get; set; }
        public double PricePerItem { get; set; }
        public int Quantity { get; set; }
        public String Address { get; set; }
        public bool ExpeditedShipping { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nItem: ");
            sb.Append(Item);
            sb.Append("\nCustomer: ");
            sb.Append(Customer);
            sb.Append("\nPrice Per Item: ");
            sb.Append(PricePerItem);
            sb.Append("\nQuantity: ");
            sb.Append(Quantity);
            sb.Append("\nAddress: ");
            sb.Append(Address);
            if (ExpeditedShipping) sb.Append("\nExpedited Shipping");
            else sb.Append("\nNo Expedited Shipping");

            return sb.ToString();
        }
    }
}
