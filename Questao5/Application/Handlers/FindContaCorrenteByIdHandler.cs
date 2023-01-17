using MediatR;
using NSubstitute;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Entities;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Repositories;

namespace Questao5.Application.Handlers
{
    public class FindContaCorrenteByIdHandler : IRequestHandler<FindContaCorrenteByIdRequest, FindContaCorrenteByIdResponse>
    {
        IContaCorrenteRepositorio _contaCorrenteRepositorio;
        IMovimentoRepositorio _movimentoRepositorio;

        public FindContaCorrenteByIdHandler(IContaCorrenteRepositorio contaCorrenteRepositorio, IMovimentoRepositorio movimentoRepositorio)
        {
            _contaCorrenteRepositorio = contaCorrenteRepositorio;
            _movimentoRepositorio = movimentoRepositorio;
        }

        public Task<FindContaCorrenteByIdResponse> Handle(FindContaCorrenteByIdRequest request, CancellationToken cancellationToken)
        {
            var result = _contaCorrenteRepositorio.BuscarContaCorrentePorId(request.Id);
            var credito = 0.00m;
            var debito = 0.00m;

            if (result.Result != null)
            {

                var saldo = _movimentoRepositorio.BuscarMovimentacaoEmConta(result.Result.IdContaCorrente);
                credito = saldo.Result.Where(x => x.TipoMovimento == Domain.Enumerators.TipoMovimentoEnum.Credito).Select(x => x.Valor).Sum();
                debito = saldo.Result.Where(x => x.TipoMovimento == Domain.Enumerators.TipoMovimentoEnum.Debito).Select(x => x.Valor).Sum();
            }

            var retorno = new FindContaCorrenteByIdResponse
            {
                Numero = result.Result.Numero,
                Nome = result.Result.Nome,
                Data = DateTime.Now,
                Saldo = credito - debito
            };

            return Task.FromResult(retorno);
        }
    }
}
