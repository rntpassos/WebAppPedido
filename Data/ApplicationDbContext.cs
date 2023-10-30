using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using WebAppPedido.Areas.Cliente.Models;
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
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<EnderecoCliente> EnderecoCliente { get; set; }

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
            builder.Entity<Produto>()
                .Property(p => p.Valor)
                .HasColumnType("decimal")
                .HasPrecision(10, 2);

            builder.Entity<Cliente>()
                .HasMany(c => c.Enderecos)
                .WithOne(c => c.Cliente)
                .HasForeignKey(e => e.ClienteId)
                .IsRequired();
            builder.Entity<Cliente>()
                .Property(c => c.ClienteId)
                .HasDefaultValueSql("NEXT VALUE FOR ProximoID");
            builder.Entity<Cliente>()
                .Property(c => c.Nome)
                .HasMaxLength(100);
            builder.Entity<Cliente>()
                .Property(c => c.CpfCnpj)
                .HasMaxLength(14);

            builder.Entity<EnderecoCliente>()
                .Property(e => e.EnderecoClienteID)
                .HasDefaultValueSql("NEXT VALUE FOR ProximoID");
            builder.Entity<EnderecoCliente>()
                .Property(e => e.Denominacao)
                .HasMaxLength(20);
            builder.Entity<EnderecoCliente>()
                .Property(e => e.Logradouro)
                .HasMaxLength(100);
            builder.Entity<EnderecoCliente>()
                .Property(e => e.Complemento)
                .HasMaxLength(50);
        }
    }
}