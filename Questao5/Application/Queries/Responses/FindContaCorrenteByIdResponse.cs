namespace Questao5.Application.Queries.Responses
{
    public class FindContaCorrenteByIdResponse
    {
        public int Numero { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public decimal Saldo { get; set; }
    }
}
