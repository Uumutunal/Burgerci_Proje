using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Garniture : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public List<BurgerGarniture> BurgerGarnitures { get; set; }
    }
}
