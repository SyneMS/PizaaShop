using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
                : base(options)
        {
        }

        public DbSet<Ingradients> Ingradients { get; set; }
        public DbSet<PizzaDetails> PizzaDetails { get; set; }
        public DbSet<PizzaIngradients> PizzaIngradients { get; set; }
        public DbSet<PizzaOrderDetails> PizzaOrderDetails { get; set; }
        public DbSet<PizzaIngradientOrderDetails> PizzaIngradientOrderDetails { get; set; }
    }
}
