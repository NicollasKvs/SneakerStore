using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SneakerStore.Models;

namespace SneakerStore.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options){}

        public DbSet<Produto> Produtos {get; set;}
        public DbSet<Fornecedor> Fornecedores {get; set;}
        public DbSet<Insumo> Insumos {get; set;}
        
    }
}