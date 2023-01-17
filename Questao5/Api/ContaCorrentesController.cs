using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Queries.Requests;
using Questao5.Domain.Interfaces;

namespace Questao5.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaCorrentesController : ControllerBase
    {
        private readonly IContaCorrenteRepositorio _contaCorrenteRepositorio;
        private readonly IMovimentoRepositorio _movimentoRepositorio;

        public ContaCorrentesController(IContaCorrenteRepositorio contaCorrenteRepositorio, IMovimentoRepositorio movimentoRepositorio)
        {
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
            _movimentoRepositorio = movimentoRepositorio;
        }

        [HttpGet]
        public IActionResult BuscarSaldoEmContaPorId([FromServices] IMediator mediator,
                                                [FromQuery] FindContaCorrenteByIdRequest command)
        {

            var result = mediator.Send(command);

            return Ok(result);
        }
    }
}
