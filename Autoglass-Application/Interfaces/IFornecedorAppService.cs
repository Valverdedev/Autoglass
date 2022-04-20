using Autoglass_Application.Dtos;
using Autoglass_Domain.Entities;
using Autoglass_Domain.Response;
using System.Threading.Tasks;

namespace Autoglass_Application.Interfaces
{
    public interface IFornecedorAppService
    {
        Task<SystemResponse> Adicionar(FornecedortDto fornecedor);
    }
}
