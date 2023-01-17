using Questao5.Domain.Entities;

namespace Questao5.Domain.Interfaces
{
    public interface IMovimentoRepositorio
    {
        Task<IEnumerable<MovimentoEntidade>> BuscarMovimentacaoEmConta(Guid idContaCorrente);
        Task MovimentacaoEmConta(MovimentoEntidade movimentoEntidade);
    }
}
