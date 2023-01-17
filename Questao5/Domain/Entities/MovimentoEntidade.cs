using Questao5.Domain.Enumerators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questao5.Domain.Entities
{
    public class MovimentoEntidade
    {

        public MovimentoEntidade()
        {

        }

        public MovimentoEntidade(string idContaCorrente, TipoMovimentoEnum tipoMovimento, decimal valor)
        {
            IdMovimento = Guid.NewGuid();
            DataMovimento = DateTime.Now;
            TipoMovimento = tipoMovimento;
            Valor = valor;
            IdContaCorrente = idContaCorrente;
        }
        public Guid IdMovimento { get; set; }

        public DateTime DataMovimento { get; private set; }
        [EnumDataType(typeof(TipoMovimentoEnum))]
        public TipoMovimentoEnum TipoMovimento { get; private set; }
        public decimal Valor { get; private set; }

        public string IdContaCorrente { get; private set; }

        public ContaCorrenteEntidade ContasCorrentes { get; private set; }
    
    
        public void Adicionar(string idContaCorrente, DateTime dataMovimento, TipoMovimentoEnum tipoMovimento, decimal valor)
        {
            IdContaCorrente = idContaCorrente;
            DataMovimento = dataMovimento;
            TipoMovimento = tipoMovimento;
            Valor = valor;
        }
    }
}
