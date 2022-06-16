
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.ArticuloMarcaFeatures.Queries
{
    public class GetAllArticuloMarcaQuery : IRequest<IEnumerable<ArticuloMarca>>
    {

        public class GetAllArticuloMarcaQueryHandler : IRequestHandler<GetAllArticuloMarcaQuery, IEnumerable<ArticuloMarca>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllArticuloMarcaQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            //private DbSet<ArticuloMarca> am = new DbSet<ArticuloMarca>();
            //DbSet<ArticuloMarca> ArticulosMarcas {
            //    set { am.AddRange(_context.ListarAriculosMarcas()); } 
            //}


            public async Task<IEnumerable<ArticuloMarca>> Handle(GetAllArticuloMarcaQuery query, CancellationToken cancellationToken)
            {
                try
                {
                    //_context.ArticulosMarcas.AddRange(_context.ListarAriculosMarcas());
                    var res = await _context.ArticulosMarcas.ToListAsync();
                    //ArticulosMarcas = new DbSet<ArticuloMarca>(null);
                    //ArticulosMarcas.AddRange(_context.ListarAriculosMarcas());
                    //var res = await this.ArticulosMarcas.ToListAsync();

                    if (res != null)
                    {
                        return res.AsReadOnly();
                    }
                }
                catch (Exception ex)
                {
                    var m = ex.Message;
                }
                return null;
            }
        }
    }
}
