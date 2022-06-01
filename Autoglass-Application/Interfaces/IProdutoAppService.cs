using Autoglass_Application.Dtos;
using Autoglass_Domain.Entities;
using Autoglass_Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglass_Application.Interfaces
{
    public interface IProdutoAppService
    {
        Task<SystemResponse> InsertAssync(CriarProdutoDto Entity);
        Task<SystemResponse> Update(AlterarProdutoDto Entity);
        Task<SystemResponse> InativarProduto(int idProduto);
        Task<List<ExibirProdutoDto>> ListarTodos();
        SystemResponse Get(int idProduto);
    }
}
