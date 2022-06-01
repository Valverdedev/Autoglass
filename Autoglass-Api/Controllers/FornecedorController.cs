using Autoglass_Application.Dtos;
using Autoglass_Application.Interfaces;
using Autoglass_Domain.Response;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglass_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : Controller
    {
        private readonly IFornecedorAppService _fornecedorAppService;

        public FornecedorController(IFornecedorAppService fornecedorAppService)
        {
            _fornecedorAppService = fornecedorAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CriarFornecedortDto), StatusCodes.Status201Created)]

        public async Task<SystemResponse> PostProduto([FromBody] CriarFornecedortDto fornecedor)
        {

            return await _fornecedorAppService.Adicionar(fornecedor);
        }

        [EnableQuery]
        [HttpGet]
        public async Task<List<ExibirFornecedorDto>> ListarTodos()
        {
            return await _fornecedorAppService.ListarTodos();
        }
    }
}
