using Autoglas_Domain_Services.Services;
using Autoglass_Application.Dtos;
using Autoglass_Application.Interfaces;
using Autoglass_Domain.Entities;
using Autoglass_Domain.Response;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglass_Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private ProdutoService _produtoService;
        private IMapper _mapper;

        public ProdutoAppService(IMapper mapper, ProdutoService produtoService )
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

       public SystemResponse Get(int idProduto)
        {
            return _produtoService.Get(idProduto);
        }

        public async Task<SystemResponse> Inserir(CriarProdutoDto Entity)
        {            
            return await _produtoService.Adicionar(_mapper.Map<Produto>(Entity));
        }

       public async Task<SystemResponse> Atualizar(AlterarProdutoDto Entity)
        {
            return await _produtoService.Alterar(_mapper.Map<Produto>(Entity));
        }

       public async Task<SystemResponse> InativarProduto(int idProduto)
        {
            return await _produtoService.InativarProduto(idProduto);
        }

       public async Task<List<ExibirProdutoDto>> ListarTodos()
        {
           var litaProdutos = await _produtoService.ListarTodos();

            return _mapper.Map<List<ExibirProdutoDto>>(litaProdutos);
        }
    }
}
