using Autoglass_Domain.Entities;
using Autoglass_Domain.Interfaces.Repository;
using Autoglass_Infrastructure_data.Context;

namespace Autoglass_Infrastructure_data.Repository
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(DataContext dataContext) : base(dataContext)
        {
        }
      
    }
}
