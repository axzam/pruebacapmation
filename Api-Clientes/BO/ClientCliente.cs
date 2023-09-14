using DA;

using Models.Request;
using Models.Response;


namespace BO
{
    public class ClientCliente
    {
        private readonly OperatorCliente _operatorCliente;

        public ClientCliente(SqlHelper sqlhelper) 
        {
            _operatorCliente = new OperatorCliente()
            {
                sqlHelper = sqlhelper,
                cliente = new Cliente()
            };
        }


        public async Task<ClienteResponseModel> GetClienteAsync(int id) => await _operatorCliente.GetClienteAsync(id);
        public async Task<List<ClienteResponseModel>> GetListClienteAsync() => await _operatorCliente.GetListClienteAsync();
        public void  CreateClienteAsync(ClienteRequestModel clienteModel) =>  _operatorCliente.CreateClienteAsync(clienteModel);
        public void UpdateClienteAsync(int id, ClienteRequestModel clienteModel) => _operatorCliente.UpdateClienteAsync(id, clienteModel);
        public void DeleteeClienteAsync(int id) => _operatorCliente.DeleteClienteAsync(id);


    }
}
