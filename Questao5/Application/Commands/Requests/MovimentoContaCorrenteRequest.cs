using MediatR;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Enumerators;

namespace Questao5.Application.Commands.Requests
{
    public class MovimentoContaCorrenteRequest : IRequest<MovimentarContaCorrenteResponse>
    {
        public Guid IdMovimento { get; set; }
        public Guid IdContaCorrente { get; set; }
        public decimal Valor { get; set; }
        public TipoMovimentoEnum TipoMovimentoEnum { get; set; }
    }
}
