using Questao5.Domain.Enumerators;

namespace Questao5.Application.DTOs
{
    public class MovimentoDTO
    {
        public string IdContaCorrente { get; set; }
        public DateTime DataMovimento { get; set; }
        public TipoMovimentoEnum TipoMovimento { get; set; }
        public decimal Valor { get; set; }
    }
}
