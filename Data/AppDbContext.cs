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
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ContaPagar> ContasPagar { get; set; }
        public DbSet<ContaReceber> ContasReceber { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Indica que ItemCarrinho não tem chave e não será mapeado para tabela
            modelBuilder.Entity<ItemCarrinho>().HasNoKey();

            // Caso tenha outras configurações, coloque aqui
        }
    }
}
