using MediatR;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests
{
    public class FindContaCorrenteByIdRequest : IRequest<FindContaCorrenteByIdResponse>
    {
        public string Id { get; set; }
    }
}
