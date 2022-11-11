using Microsoft.AspNetCore.Mvc;
using myProject.Model;
using myProject.Repository;

namespace myProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExController : ControllerBase 
    {   
        //Injetar dependência do repositório
        private readonly ICadastroRepository _repository;  // aqui é igual no repository
        
        public ExController(ICadastroRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var cadastros = await _repository.GetExes();  // GetExes é o nome sugerido pelo sistema pra substituir cadastros
            return cadastros.Any() ? Ok(cadastros) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            var cadastro = await _repository.GetCadastroById(id);  
            return cadastro != null
            ? Ok(cadastro) : NotFound("Cadastro não encontrado.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Cadastro cadastro) {
            _repository.AddCadastro(cadastro);
            return await _repository.SaveChangesAsync()
            ? Ok("Cadastro adicionado") : BadRequest("Algo deu errado.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Cadastro cadastro){
            var cadastroExiste = await _repository.GetCadastroById(id);
            if(cadastroExiste == null) return NotFound("Cadastro não encontrado.");
            
            cadastroExiste.Nome = cadastro.Nome ?? cadastroExiste.Nome;
            cadastroExiste.DataNascimento = cadastro.DataNascimento != new DateTime()
            ? cadastro.DataNascimento : cadastroExiste.DataNascimento;

            _repository.AtualizarCadastro(cadastroExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Cadastro atualizado.") : BadRequest("Algo deu errado.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var cadastroExiste = await _repository.GetCadastroById(id);
            if(cadastroExiste == null) return NotFound("Cadastro não encontrado.");
                return NotFound("Cadastro não encontrado.");

            _repository.DeletarCadastro(cadastroExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Cadastro atualizado.") : BadRequest("Algo deu errado.");
        }
    }
}
