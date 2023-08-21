using DatabaseAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccessLayer.EcommerceDBContext
{
    public class EcommerceContext:DbContext
    {
        public EcommerceContext (DbContextOptions<EcommerceContext> options) : base(options)//Specifies the type of provider of database to use- mysql, postgres etc
        {
        }
        public DbSet <Category> Categories { get; set; }
        public DbSet <Product> Products { get; set; }

    }
}
