namespace Questao1.Validacao
{
    public class Validacoes
    {
        public static void ValidarSeNumeroContaExisteNaoAltera(string nome, string nome2, string menssagem)
        {
            // Não há nessecidade por enquanto
        }

        public static void ValidarSeVazio(string valor, string menssagem)
        {
            if (valor == null || valor.Trim().Length == 0)
            {
                throw new DomainException(menssagem);
            }
        }

        public static void ValidarSeNulo(object valor, string menssagem)
        {
            if (valor == null)
            {
                throw new DomainException(menssagem);
            }
        }
    }
}
