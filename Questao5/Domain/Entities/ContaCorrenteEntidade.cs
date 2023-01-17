namespace Questao5.Domain.Entities
{
    public class ContaCorrenteEntidade
    {
        public ContaCorrenteEntidade()
        {

        }

        public ContaCorrenteEntidade(string idContaCorrente, decimal numero, string nome, bool ativo)
        {
            Numero = numero;
            Nome = nome;
            Ativo = ativo;
            IdContaCorrente = idContaCorrente;
        }
        public string IdContaCorrente { get; private set; }
        public decimal Numero { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        public MovimentoEntidade Movimentos { get; set; }
    }
}
