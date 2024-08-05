using Burgerci_Proje.Entities;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Hamburger> Hamburgers { get; set; }
        public DbSet<Garniture> Garnitures { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<HamburgerGarniture> HamburgerGarnitures { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seeddata
        }
    }
}
