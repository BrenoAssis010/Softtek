using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Interfaces;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Repositories
{
    public class ContaCorrenteRepositorio : IContaCorrenteRepositorio
    {
        private readonly DatabaseConfig databaseConfig;

        public ContaCorrenteRepositorio(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<ContaCorrenteEntidade> BuscarContaCorrentePorId(string idContaCorrente)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var parametros = new DynamicParameters();
            return await connection.QueryFirstAsync<ContaCorrenteEntidade>($"SELECT * FROM ContaCorrente where IdContaCorrente = @IdContaCorrente ", new { IdContaCorrente = idContaCorrente });
        }

        public async Task<IEnumerable<ContaCorrenteEntidade>> BuscarSaldoEmConta()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);
            return await connection.QueryAsync<ContaCorrenteEntidade>("SELECT * FROM ContaCorrente;");
        }
    }
}
