using Autoglass_Application.Dtos;
using Autoglass_Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglass_Application.Interfaces
{
    public interface IFornecedorAppService
    {
        Task<SystemResponse> Adicionar(CriarFornecedortDto fornecedor);

        Task<List<ExibirFornecedorDto>> ListarTodos();
    }
}
