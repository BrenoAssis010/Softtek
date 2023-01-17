using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Interfaces
{
    public interface IContaCorrenteRepositorio
    {
        Task<ContaCorrenteEntidade> BuscarContaCorrentePorId(string idContaCorrente);
        Task<IEnumerable<ContaCorrenteEntidade>> BuscarSaldoEmConta();
    }
}
