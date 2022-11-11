using Microsoft.EntityFrameworkCore;
using myProject.Model;

namespace myProject.Database
{
    public class ExDbContext : DbContext
    {
        public ExDbContext(DbContextOptions<ExDbContext>
        options) : base(options)
        {

        }

        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<Compra> Compras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cadastro = modelBuilder.Entity<Cadastro>();
            cadastro.ToTable("cadastros");  // onde tá cadastro é onde podemos mudar o nome da tabela
            cadastro.HasKey(x => x.Id);
            cadastro.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();  // ValueGeneratedOnAdd quando coloca isso gera automaticamente o Id
            cadastro.Property(x => x.Nome).HasColumnName("nome").IsRequired();  // IsRequired é uma requisição obrigatória  
            cadastro.Property(x => x.DataNascimento).HasColumnName("data_nascimento");
            cadastro.Property(x => x.Endereco).HasColumnName("endereço").IsRequired();
            cadastro.Property(x => x.Email).HasColumnName("email").IsRequired();

            var compra = modelBuilder.Entity<Compra>();
            compra.ToTable("Compras");
            compra.HasKey(x => x.Id);
            compra.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            compra.Property(x => x.Nome).HasColumnName("nome").IsRequired();
            compra.Property(x => x.DataCompra).HasColumnName("data_compra").IsRequired();
            compra.Property(x => x.Destino).HasColumnName("destino").IsRequired();
            compra.Property(x => x.Quantidade).HasColumnName("quantidade").IsRequired();

            // Despois de autlizar aplica: dotnet ef migrations add AtualizarTabela
            // Pra mudar no banco também tem que colocar: dotnet ef database update
        }
    }
}