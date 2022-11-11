

namespace myProject.Model
{
    public class Compra
    {
       public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCompra { get; set; }
        public string Destino { get; set; }
        public int Quantidade { get; set; } 
    }
}