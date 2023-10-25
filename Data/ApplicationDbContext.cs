using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using WebAppPedido.Areas.Gerente.Models;

namespace WebAppPedido.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasSequence<int>("ProximoID");

            builder.Entity<Produto>()
                .Property(p => p.ProdutoId)
                .HasDefaultValueSql("NEXT VALUE FOR ProximoID");
            builder.Entity<Produto>()
                .Property(p => p.Descricao)
                .HasMaxLength(100);
            builder.Entity<Produto>()
                .Property(p => p.UsuarioCriacao)
                .HasMaxLength(100);
            builder.Entity<Produto>()
                .Property(p => p.UsuarioAlteracao)
                .HasMaxLength(100);
        }
    }
}