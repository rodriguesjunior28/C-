using myProject.Model;

namespace myProject.Repository
{
    public interface ICompraRepository
    {
        Task<IEnumerable<Compra>> GetCompras();
         Task<Compra> GetCompraById(int id);
         void AddCompra(Compra compra);
         void AtualizarCompra(Compra compra);
         void DeletarCompra(Compra compra);

         Task<bool> SaveChangesAsync();
    }
}