
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Application.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProductFeatures.Queries
{
    public class GetAllArticuloMarcaQuery : IRequest<IEnumerable<Product>>
    {

        public class GetAllProductsQueryHandler : IRequestHandler<GetAllArticuloMarcaQuery, IEnumerable<Product>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllProductsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Product>> Handle(GetAllArticuloMarcaQuery query, CancellationToken cancellationToken)
            {
                var res = await _context.Products.ToListAsync();
                if (res == null)
                {
                    return null;
                }
                return res.AsReadOnly();
            }
        }
    }
}
