using DA;
using Models.Response;
using Models.Request;
using System.Data;

namespace BO
{
    public class Cliente : ICliente
    {
        public SqlHelper sqlHelper { get ; set; }

        public async void CreateAsync(ClienteRequestModel clienteModel) => await sqlHelper.ExecSpAsync( "usp_insert_cliente", clienteModel );
        public async void  DeleteAsync(int id) => await sqlHelper.ExecSpAsync("usp_delete_cliente", new { Id = id });
        public async Task<ClienteResponseModel> GetAsync(int id) => await sqlHelper.GetTAsync<ClienteResponseModel>("usp_get_cliente_by_id", new { Id = id});
        public async Task<List<ClienteResponseModel>> GetListAsync() => await sqlHelper.GetListTAsync<ClienteResponseModel>("usp_get_list_cliente");
        public async void UpdateAsync(int id, ClienteRequestModel clienteModel) => await sqlHelper.ExecSpAsync("usp_update_cliente", new {Id = id,
                                                                                                                                          Name = clienteModel.Name,
                                                                                                                                          LastName = clienteModel.LastName,
                                                                                                                                          Age = clienteModel.Age,
                                                                                                                                          Nationality = clienteModel.Nationality});
    }
}
