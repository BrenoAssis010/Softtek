using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;

namespace Questao5.Application.Handlers
{
    public class MovimentarContaCorrenteHandler : IRequestHandler<MovimentoContaCorrenteRequest, MovimentarContaCorrenteResponse>
    {
        IMovimentoRepositorio _movimentoRepositorio;
        IContaCorrenteRepositorio _contaCorrenteRepositorio;

        public MovimentarContaCorrenteHandler(IMovimentoRepositorio movimentoRepositorio, IContaCorrenteRepositorio contaCorrenteRepositorio)
        {
            _movimentoRepositorio = movimentoRepositorio;
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
        }

        public Task<MovimentarContaCorrenteResponse> Handle(MovimentoContaCorrenteRequest request, CancellationToken cancellationToken)
        {
            var validarContaCorrenteExiste = _contaCorrenteRepositorio.BuscarContaCorrentePorId(request.IdContaCorrente);

            if (validarContaCorrenteExiste.Result == null)
                throw new Exception("INVALID_ACCOUNT");

            var movimentacao = new MovimentoEntidade(request.IdContaCorrente, request.TipoMovimentoEnum, request.Valor);

            _movimentoRepositorio.MovimentacaoEmConta(movimentacao);

            var result = new MovimentarContaCorrenteResponse
            {
                IdMovimento = request.IdMovimento
            };

            return Task.FromResult(result);
        }
    }
}
