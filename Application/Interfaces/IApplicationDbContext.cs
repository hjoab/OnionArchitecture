
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Articulo> Articulos { get; set; }
        DbSet<Marca> Marcas { get; set; }
        DbSet<ArticuloMarca> ArticulosMarcas { get; set; }
        Task<int> SaveChangesAsync();
        IEnumerable<ArticuloMarca> ListarAriculosMarcas();
    }
}
