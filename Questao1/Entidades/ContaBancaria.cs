using Questao1.Enums;
using Questao1.Validacao;

namespace Questao1.Entidades
{
    public class ContaBancaria
    {
        public ContaBancaria(long numeroConta, string titularConta)
        {
            NumeroConta = numeroConta;
            TitularConta = titularConta;

            ValidarPropriedades();
        }

        public ContaBancaria(long numeroConta, string titularConta, double? depositoInicial)
        {
            NumeroConta = numeroConta;
            TitularConta = titularConta;

            Deposito(depositoInicial.GetValueOrDefault(0));

            ValidarPropriedades();
        }

        public long NumeroConta { get; private set; }
        public string TitularConta { get; private set; }
        public double? DepositoInicial { get; private set; }
        public TransacaoConta Transacao { get; private set; }
        public double SaldoEmConta { get; private set; }

        public void Deposito(double valorTransacao)
        {
            Validacoes.ValidarSeNulo(valorTransacao, "O campo deposito é obrigatório.");

            var transacao = new TransacaoConta();
            SaldoEmConta += transacao.TransacaoBancaria(valorTransacao, TipoTransacaoContaEnum.Deposito);
        }

        public void Saque(double valorTransacao)
        {
            Validacoes.ValidarSeNulo(valorTransacao, "O campo deposito é obrigatório.");

            var transacao = new TransacaoConta();
            SaldoEmConta -= transacao.TransacaoBancaria(valorTransacao, TipoTransacaoContaEnum.Saque);
        }

        public void ValidarPropriedades()
        {
            Validacoes.ValidarSeNulo(NumeroConta, "O campo número da conta é obrigatório.");
            Validacoes.ValidarSeNulo(TitularConta, "O campo titular da conta é obrigatório.");
        }
    }
}
