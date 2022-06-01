using Autoglass_Domain.Entities;
using Autoglass_Domain.Interfaces.Repository;
using Autoglass_Domain.Response;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoglas_Domain_Services.Services
{
    public class ProdutoService : SystemResponse
    {
        private readonly IBaseRepository<Produto> _produtoRepository;
        private readonly IBaseRepository<Fornecedor> _fornecedorRepository;

        public ProdutoService(IBaseRepository<Produto> baseRepository, IBaseRepository<Fornecedor> fornecedorRepository)
        {
            _produtoRepository = baseRepository;
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<SystemResponse> Adicionar(Produto produto)
        {

            Result(await _produtoRepository.InsertAssync(produto));

            return Return();
        }

        public async Task<List<Produto>> ListarTodos()
        {
            return await _produtoRepository.Query().Include(a => a.Fornecedor).Where(p => p.Situacao).ToListAsync();
        }

        public SystemResponse Get(int idProduto)
        {

            var produto = _produtoRepository.Query().Include(a => a.Fornecedor).FirstOrDefault(p => p.Situacao == true && p.Id == idProduto);

            if (produto == null) AddError(idProduto.ToString(), "Não há produtos cadastrados");

            Result(produto);

            return Return();
        }

        public async Task<SystemResponse> Alterar(Produto produto)
        {

            Result(await _produtoRepository.Update(produto));

            return Return();
        }

        public async Task<SystemResponse> InativarProduto(int idProduto)
        {
            var produto = _produtoRepository.Query().Where(p => p.Id == idProduto && p.Situacao == true).FirstOrDefault();

            if (produto == null) AddError("Não Encontrado", "o id informado não existe na base de dados, ou está inativo");


            produto.SetSituacaoFalse();

            Result(await _produtoRepository.Update(produto));

            return Return();

        }


    }
}
