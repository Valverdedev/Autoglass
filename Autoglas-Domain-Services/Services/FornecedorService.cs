using Autoglass_Domain.Entities;
using Autoglass_Domain.Interfaces.Repository;
using Autoglass_Domain.Response;
using System.Threading.Tasks;

namespace Autoglas_Domain_Services.Services
{
    public class FornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;

        public FornecedorService(IFornecedorRepository fornecedorRepository)
        {
            
            _fornecedorRepository = fornecedorRepository;
            
        }

        public async Task<SystemResponse> Adicionar(Fornecedor fornecedor)
        {
            SystemResponse response = new();
           await _fornecedorRepository.InsertAssync(fornecedor);

            response.Data = fornecedor;

            return response;
        }
    }
}
