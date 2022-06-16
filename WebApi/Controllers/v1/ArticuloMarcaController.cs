using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//using Application.Features.ArticuloMarcaFeatures.Commands;
using Application.Features.ArticuloMarcaFeatures.Queries;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ArticuloMarcaController : BaseApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllArticuloMarcaQuery()));
        }
    }
}