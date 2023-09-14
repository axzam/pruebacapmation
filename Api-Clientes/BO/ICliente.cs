using DA;
using Models.Response;
using Models.Request;

namespace BO
{
    public interface ICliente
    {
        SqlHelper sqlHelper { get; set; }
        void CreateAsync(ClienteRequestModel clienteModel);
        Task<ClienteResponseModel> GetAsync(int id);
        Task<List<ClienteResponseModel>> GetListAsync();
        void DeleteAsync(int id);
        void UpdateAsync(int id, ClienteRequestModel clienteModel);

    }
}
