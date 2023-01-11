using Questao1.Enums;

namespace Questao1.Entidades
{
    public class TransacaoConta
    {
        public TransacaoConta()
        {

        }

        public TransacaoConta(double valorTransacao)
        {
            ValorTransacao = valorTransacao;
        }

        public double ValorTransacao { get; private set; }

        public double TransacaoBancaria(double ValorTransacao, TipoTransacaoContaEnum TipoTransacaoConta)
        {
            switch (TipoTransacaoConta)
            {
                case TipoTransacaoContaEnum.Saque:
                    ValorTransacao = ValorTransacao == 0 ? 0 : ValorTransacao + 3.5;
                    break;
                case TipoTransacaoContaEnum.Deposito:
                    ValorTransacao = ValorTransacao == 0 ? 0 : ValorTransacao;
                    break;
                default:
                    break;
            }

            return ValorTransacao;
        }
    }
}
