using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Domain.Entites
{
    public class FooterAddress
    {
        public int FooterAddressID { get; set; }
        public string? FooterAddressDescription { get; set; }
        public string? FooterAddressAddress { get; set; }
        public string? FooterAddressMail { get; set; }
        public string? FooterAddressPhone { get; set; }
    }
}
