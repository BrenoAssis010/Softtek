using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Repositories
{
    public class MovimentoRepositorio : IMovimentoRepositorio
    {
        private readonly DatabaseConfig databaseConfig;

        public MovimentoRepositorio(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<MovimentoEntidade>> BuscarMovimentacaoEmConta(Guid idContaCorrente)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);
            return await connection.QueryAsync<MovimentoEntidade>("SELECT idmovimento, idcontacorrente, datamovimento, CAST(tipomovimento AS char), valor FROM Movimento where idContaCorrente =;");
                                                                 
        }

        public async Task MovimentacaoEmConta(MovimentoEntidade movimentoEntidade)
        {
            var tipoMovimento = movimentoEntidade.TipoMovimento == Domain.Enumerators.TipoMovimentoEnum.Credito ?
                "C" : "D";
            var idMovimento = Guid.NewGuid().ToString();
            var parametros = new DynamicParameters();
            
            parametros.Add("IdMovimento", idMovimento);
            parametros.Add("IdContaCorrente", movimentoEntidade.IdContaCorrente);
            parametros.Add("DataMovimento", movimentoEntidade.DataMovimento);
            parametros.Add("TipoMovimento", tipoMovimento.ToString());
            parametros.Add("Valor", movimentoEntidade.Valor);

            using var connection = new SqliteConnection(databaseConfig.Name);
            await connection.ExecuteAsync("INSERT INTO movimento (idmovimento, idcontacorrente,datamovimento,tipomovimento,valor)" +
                " VALUES (@IdMovimento,@IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor);", parametros);
            
        }
    }
}
