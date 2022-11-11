using myProject.Model;

namespace myProject.Repository
{
    public interface ICadastroRepository
    {
        Task<IEnumerable<Cadastro>> GetExes();  // aqui GetExes o sistema que sugeriu
        Task<Cadastro> GetCadastroById(int id);  // aqui é pra pegar o Id
        void AddCadastro(Cadastro cadastro);
        void AtualizarCadastro(Cadastro cadastro);
        void DeletarCadastro(Cadastro cadastro);

        Task<bool> SaveChangesAsync();  // aqui só se usa no banco de dados
    }
}