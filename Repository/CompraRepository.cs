using myProject.Database;
using myProject.Model;
using Microsoft.EntityFrameworkCore;

namespace myProject.Repository
{
    public class CompraRepository : ICompraRepository
    {   
        private readonly ExDbContext _context;

        public CompraRepository(ExDbContext context) {
            _context = context;



        }
        public void AddCompra(Compra compra)
        {
            _context.Add(compra);
        }

        public void AtualizarCompra(Compra compra)
        {
            _context.Update(compra);
        }

        public void DeletarCompra(Compra compra)
        {
            _context.Remove(compra);
        }

        public async Task<Compra> GetCompraById(int id)
        {
            return await _context.Compras
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Compra>> GetCompras()
        {
            return await _context.Compras.ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}