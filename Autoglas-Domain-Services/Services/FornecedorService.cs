using Autoglass_Domain.Entities;
using Autoglass_Domain.Interfaces.Repository;
using Autoglass_Domain.Response;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Autoglas_Domain_Services.Services
{
    public class FornecedorService : SystemResponse
    {
        private readonly IBaseRepository<Fornecedor> _fornecedorRepository;

        public FornecedorService(IBaseRepository<Fornecedor> fornecedorRepository)
        {
            
            _fornecedorRepository = fornecedorRepository;
            
        }

        public async Task<SystemResponse> Adicionar(Fornecedor fornecedor)
        {
            
          Result(await  _fornecedorRepository.InsertAssync(fornecedor));            

            return Return();
        }

        public async Task<List<Fornecedor>> ListarTodos()
        {
            return await _fornecedorRepository.Query().ToListAsync();
        }
    }
}
