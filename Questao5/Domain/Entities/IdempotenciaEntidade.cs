namespace Questao5.Domain.Entities
{
    public class IdempotenciaEntidade
    {
        public IdempotenciaEntidade(string requisicao, string resultado)
        {
            Requisicao = requisicao;
            Resultado = resultado;
        }

        public Guid ChaveIdempotencia { get; private set; }
        public string Requisicao { get; private set; }
        public string Resultado { get; private set; }
    }
}
