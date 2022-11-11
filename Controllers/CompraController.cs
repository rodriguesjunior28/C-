using Microsoft.AspNetCore.Mvc;
using myProject.Model;
using myProject.Repository;

namespace myProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly ICompraRepository _repository;

        public CompraController(ICompraRepository repository) {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(){
            var compras = await _repository.GetCompras();  // GetExes é o nome sugerido pelo sistema pra substituir cadastros
            return compras.Any() ? Ok(compras) : NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id){
            var compra = await _repository.GetCompraById(id);  
            return compra != null
            ? Ok(compra) : NotFound("Compra não encontrada.");
        }

        [HttpPost]
        public async Task<IActionResult> Post(Compra compra) {
            _repository.AddCompra(compra);
            return await _repository.SaveChangesAsync()
            ? Ok("Compra adicionada") : BadRequest("Algo deu errado.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Compra compra){
            var compraExiste = await _repository.GetCompraById(id);
            if(compraExiste == null) return NotFound("Compra não encontrada.");
            
            compraExiste.Nome = compra.Nome ?? compraExiste.Nome;
            compraExiste.DataCompra = compra.DataCompra != new DateTime()
            ? compra.DataCompra : compraExiste.DataCompra;

            _repository.AtualizarCompra(compraExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Compra atualizada.") : BadRequest("Algo deu errado.");

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var compraExiste = await _repository.GetCompraById(id);
            if(compraExiste == null) return NotFound("Compra não encontrada.");
                return NotFound("Compra não encontrada.");

            _repository.DeletarCompra(compraExiste);

            return await _repository.SaveChangesAsync()
            ? Ok("Compra atualizada.") : BadRequest("Algo deu errado.");
        }
    }
}