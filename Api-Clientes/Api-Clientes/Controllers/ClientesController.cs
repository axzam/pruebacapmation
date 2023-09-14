using BO;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Models.Request;
using Models.Response;

namespace Api_Clientes.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClientCliente _clientCliente;

        public ClientesController( ClientCliente clientCliente) 
        {
            _clientCliente = clientCliente;
        }

        [HttpGet]
        public Task<ClienteResponseModel> GetClientDetails(int id)
        {
            return _clientCliente.GetClienteAsync(id);
        }

        [HttpGet]
        [Route("List")]
        public  Task<List<ClienteResponseModel>> GetClientList()
        {
            return _clientCliente.GetListClienteAsync();
        }

        [HttpPost]
        public void CreateClient(ClienteRequestModel clientModel)
        {
            _clientCliente.CreateClienteAsync(clientModel);
        }

        [HttpPut]
        public void EditClient(int id, ClienteRequestModel clientModel)
        {
            _clientCliente.UpdateClienteAsync(id, clientModel);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _clientCliente.DeleteeClienteAsync(id);
        }
    }
}
