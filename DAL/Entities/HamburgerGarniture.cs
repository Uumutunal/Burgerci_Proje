using Burgerci_Proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class HamburgerGarniture : BaseEntity
    {
        public Guid HamburgerId { get; set; }
        public Guid GarnitureId { get; set; }
        public Hamburger Hamburger { get; set; }
        public Garniture Garniture { get; set; }
    }
}
