using DA;

using Models.Request;
using Models.Response;

namespace BO
{
    public class OperatorCliente
    {
        public SqlHelper sqlHelper {  get; set; }
        public ICliente cliente { get; set; }

        public async Task<ClienteResponseModel> GetClienteAsync(int id)
        {
            try
            {
                cliente.sqlHelper = sqlHelper;
                return await cliente.GetAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<ClienteResponseModel>> GetListClienteAsync()
        {
            try
            {
                cliente.sqlHelper = sqlHelper;
                return await cliente.GetListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void CreateClienteAsync(ClienteRequestModel clienteModel)
        {
            try
            {
                cliente.sqlHelper = sqlHelper;
                
                cliente.sqlHelper.InitTransaction();
                cliente.CreateAsync(clienteModel);
                cliente.sqlHelper.ConfirmTransaction();
            }
            catch (Exception ex)
            {
                cliente.sqlHelper.AbortTransaction();
                throw ex;
            }
        }

        public void UpdateClienteAsync(int id, ClienteRequestModel clienteModel)
        {
            try
            {

                cliente.sqlHelper = sqlHelper;
                cliente.sqlHelper.InitTransaction();
                cliente.UpdateAsync(id, clienteModel);
                cliente.sqlHelper.ConfirmTransaction();

            }
            catch (Exception ex)
            {
                cliente.sqlHelper.AbortTransaction();
                throw ex;
            }
        }

        public void DeleteClienteAsync(int id)
        {
            try
            {
                cliente.sqlHelper = sqlHelper;
                cliente.DeleteAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
