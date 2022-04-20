using Autoglass_Domain.Entities;
using Autoglass_Domain.Interfaces.Repository;
using Autoglass_Domain.Response;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoglas_Domain_Services.Services
{
    public class ProdutoService
    {
        private IBaseRepository<Produto> _baseRepository;
        private IFornecedorRepository _fornecedorRepository;

        public ProdutoService(IBaseRepository<Produto> baseRepository, IFornecedorRepository fornecedorRepository)
        {
            _baseRepository = baseRepository;
            _fornecedorRepository = fornecedorRepository;
        }

        public async Task<SystemResponse> Adicionar(Produto produto)
        {
            var response = new SystemResponse();
            var fornecedor = _fornecedorRepository.Query().FirstOrDefault(a => a.Id == produto.FornecedorId);
            
            if (fornecedor == null)
            {
                response.AddError("Id", "Não há fornecedor com este ID");
                return response;
            }
            produto.Situacao = true;
            

            try
            {
                await _baseRepository.InsertAssync(produto);
                response.Data = produto;
            }
            catch (System.Exception)
            {

                throw;
            }
            return response;
        }

        public  List<Produto> ListarTodos()
        {
            return _baseRepository.Query().Include(a => a.Fornecedor).Where(p => p.Situacao).ToList();
        }

        public SystemResponse Get(int idProduto)
        {
            var response = new SystemResponse();

            var produto = _baseRepository.Query().Include(a => a.Fornecedor).FirstOrDefault(p => p.Situacao == true && p.Id == idProduto);
            if (produto == null)
            {
                response.AddError("Não encontrado", "Não há produtos cadastrados");
                return response;
            }

            response.Data = produto;

            return response;
        }

        public async Task<SystemResponse> Alterar(Produto produto)
        {
            var response = new SystemResponse();
            var fornecedor = _fornecedorRepository.Query().FirstOrDefault(a => a.Id == produto.FornecedorId);

            if (fornecedor == null)
            {
                response.AddError("Id", "Não há fornecedor com este ID");
                return response;
            }
            if (_baseRepository.Query().FirstOrDefault(p => p.Id == produto.Id && p.Situacao == true) != null)
            {
                try
                {
                    _baseRepository.Update(produto);
                  await  _baseRepository.SaveChangesAsync();

                    response.Data = produto;
                }
                catch (System.Exception)
                {

                    throw;
                }

            }
            else
            {
                response.AddError("Não Encontrado", "o id informado não existe na base de dados, ou está inativo");
            }
            return response;
        }

        public async Task<SystemResponse> InativarProduto(int idProduto)
        {
            var response = new SystemResponse();
            Produto produto = new Produto();

            produto = _baseRepository.Query().Where(p => p.Id == idProduto && p.Situacao == true).FirstOrDefault();

            if (produto == null)
            {
                response.AddError("Não Encontrado", "o id informado não existe na base de dados, ou está inativo");
                return response;
            }

            produto.Situacao = false;
            try
            {
                _baseRepository.Update(produto);
               await _baseRepository.SaveChangesAsync();

                response.Data = produto;
            }
            catch (System.Exception)
            {

                throw;
            }

            return response;

        }


    }
}
