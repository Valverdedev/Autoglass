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
    public class FornecedorAppService : IFornecedorAppService
    {
        private readonly IMapper _mapper;
        private readonly FornecedorService _fornecedorService;

        public FornecedorAppService(IMapper mapper, FornecedorService fornecedorService)
        {
            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }

        public async Task<SystemResponse> Adicionar(CriarFornecedortDto Entity)
        {
            return await _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(Entity));
        }

        public async Task<List<ExibirFornecedorDto>> ListarTodos()
        {
            var litaProdutos = await _fornecedorService.ListarTodos();

            return _mapper.Map<List<ExibirFornecedorDto>>(litaProdutos);
        }
    }
}
