using System;

namespace Domain.Entities
{
    public class ArticuloMarca
    {
        public int IdArticulo { get; set; }
        public string Descripcion { get; set; }
        public int Sku { get; set; }
        public int IdMarca { get; set; }
        public string Marca { get; set; }
    }
}
