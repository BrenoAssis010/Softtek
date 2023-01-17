using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Questao5.Domain.Entities;
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
        public IActionResult BuscarSaldoEmConta(Guid idContaCorrente)
        {
            var conta = _contaCorrenteRepositorio.BuscarContaCorrentePorId(idContaCorrente);
            var teste = 0;

            if (conta != null)
            {
                _movimentoRepositorio.BuscarMovimentacaoEmConta()                
            }


            if (conta == null)
            {
                return Ok(0.00M);
            }

            var credito = conta.Result.Where(x => x.Movimentos.TipoMovimento == Domain.Enumerators.TipoMovimentoEnum.Credito).Select(x => x.Movimentos.Valor).Sum();
            var debito = conta.Result.Where(x => x.Movimentos.TipoMovimento == Domain.Enumerators.TipoMovimentoEnum.Debito).Select(x => x.Movimentos.Valor).Sum();
            

            var saldoEmConta = credito - debito;

            return Ok(saldoEmConta);
        }
    }
}
