using Burgerci_Proje.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class BurgerGarniture : BaseEntity
    {
        public Guid BurgerId { get; set; }
        public Guid IngredientId { get; set; }
        public Hambuger Burger { get; set; }
        public Garniture Ingredient { get; set; }
    }
}
