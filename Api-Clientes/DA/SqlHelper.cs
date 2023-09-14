using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DA
{
    public class SqlHelper
    {
        private SqlConnection _connection { get; set; }
        private SqlTransaction _trx { get; set; }
        private bool EnTransaccion => _trx != null;


        public SqlHelper(Configuracion sqlConfiguracion) 
        {
            _connection = new SqlConnection(sqlConfiguracion.ConnectionString);

        }

        public void InitConnection()
        {
            if (_connection.State != ConnectionState.Open) _connection.Open();
        }
        public void CloseConnection() 
        {
            _connection.Close();
        }
        public void InitTransaction() 
        {
            if (!EnTransaccion) return;
            _connection.Open();
            _trx = _connection.BeginTransaction();
        }
        public void AbortTransaction() 
        {
            if (!EnTransaccion) return;
            _trx.Rollback();
            _trx = null;
            _connection.Close();
        }
        public void ConfirmTransaction() 
        {
            if (!EnTransaccion) return;
            _trx.Commit();
            _trx = null;
            _connection.Close();
        }
        public async Task<T> GetTAsync<T>(string spName, object paramters = null) 
        {
            return await _connection.QueryFirstOrDefaultAsync<T>(spName, paramters, _trx, commandType: CommandType.StoredProcedure);
        }
        public async Task ExecSpAsync( string spName, object parameters) 
        {
            await _connection.ExecuteAsync(spName, parameters, _trx, 1200, commandType: CommandType.StoredProcedure);
        }
        public async Task<List<T>> GetListTAsync<T>(string spName, object paramters = null) 
        {
            var result = await _connection.QueryAsync<T>(spName, paramters, _trx, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


    }
}
