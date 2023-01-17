namespace Questao5.Application.DTOs
{
    public class MovimentoBuscarDTO
    {
        public string IdContaCorrente { get; set; }
        public DateTime DataMovimento { get; set; }
        public string TipoMovimento { get; set; }
        public decimal Valor { get; set; }
    }
}
