using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.DTOs;
using Questao5.Application.Handlers;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;

namespace Questao5.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentosController : ControllerBase
    {
        private readonly IMovimentoRepositorio _movimentoRepositorio;
        private readonly IMapper _mapper;

        public MovimentosController(IMovimentoRepositorio movimentoRepositorio, IMapper mapper)
        {
            _movimentoRepositorio = movimentoRepositorio;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult MovimentacaoSaldoEmConta([FromServices] IMediator mediator,
                   [FromBody] MovimentoContaCorrenteRequest command)
        {
            var response = mediator.Send(command);

            return Ok(response.Result);
        }
    }
}
