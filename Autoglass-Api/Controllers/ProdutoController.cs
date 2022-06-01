using Autoglass_Application.Dtos;
using Autoglass_Application.Interfaces;
using Autoglass_Domain.Entities;
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
    public class ProdutoController : ControllerBase
    {
        private IProdutoAppService _produtoAppService;

        public ProdutoController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(CriarProdutoDto), StatusCodes.Status201Created)]

        public async Task<SystemResponse> PostProduto([FromBody] CriarProdutoDto produto)
        {

            return await _produtoAppService.InsertAssync(produto);
        }

        [HttpPut]
        [ProducesResponseType(typeof(CriarProdutoDto), StatusCodes.Status201Created)]
        public async Task<SystemResponse> AlterarProduto([FromBody] AlterarProdutoDto produto)
        {

            return await _produtoAppService.Update(produto);
        }
        [EnableQuery]
        [HttpGet]
        public async Task<List<ExibirProdutoDto>> ListarTodos()
        {
            return await _produtoAppService.ListarTodos();
        }

        [HttpGet("{idProduto}")]
        public SystemResponse GetId(int idProduto)
        {
            return _produtoAppService.Get(idProduto);
        }

        [HttpPut("/Deletar/{idProduto}")]       
        public async Task<SystemResponse> InativarProduto(int idProduto)
        {

            return await _produtoAppService.InativarProduto(idProduto);
        }
    }
}
