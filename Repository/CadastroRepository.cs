using myProject.Model;
using myProject.Database;
using Microsoft.EntityFrameworkCore;

namespace myProject.Repository
{
    public class CadastroRepository : ICadastroRepository  // ao colocar ICadastroRepository ele chama o faz parte do ICadastroRepository
    {   
        //Injetar dependência do contexto
        private readonly ExDbContext _context;

        public CadastroRepository(ExDbContext context) {
            _context = context;
        }
        


        public void AddCadastro(Cadastro cadastro)
        {
            _context.Add(cadastro);
        }

        public void AtualizarCadastro(Cadastro cadastro)
        {
            _context.Update(cadastro);
        }

        public void DeletarCadastro(Cadastro cadastro)
        {
            _context.Remove(cadastro);
        }

        public async Task<Cadastro> GetCadastroById(int id)
        {
            return await _context.Cadastros
            .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Cadastro>> GetExes()  // GetExes é o nome sugerido pelo sistema
        {
            return await _context.Cadastros.ToListAsync();  // aqui no caso é o nome da tabela
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;  // aqui se for falso ele vem 1 e verdadeiro 0
        }
    }
}