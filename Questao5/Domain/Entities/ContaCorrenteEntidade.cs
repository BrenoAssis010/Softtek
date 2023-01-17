namespace Questao5.Domain.Entities
{
    public class ContaCorrenteEntidade
    {
        public ContaCorrenteEntidade()
        {

        }

        public ContaCorrenteEntidade(Guid idContaCorrente, int numero, string nome, bool ativo)
        {
            Numero = numero;
            Nome = nome;
            Ativo = ativo;
            IdContaCorrente = idContaCorrente;
        }
        public Guid IdContaCorrente { get; private set; }
        public int Numero { get; private set; }
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }

        public MovimentoEntidade Movimentos { get; set; }
    }
}
