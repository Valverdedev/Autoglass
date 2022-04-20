using Autoglass_Domain.Entities;
using Autoglass_Domain.Interfaces.Repository;
using Autoglass_Domain.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autoglass_Domain.Services
{
    public class ProdutoService
    {
        private IBaseRepository<Produto> _baseRepository;

        public ProdutoService(IBaseRepository<Produto> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<SystemResponse> Adicionar(Produto produto)
        {
            produto.Situacao = true;
            var response = new SystemResponse();

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
            return _baseRepository.Query().Where(p => p.Situacao).ToList();
        }

        public SystemResponse Get(int idProduto)
        {
            var response = new SystemResponse();

            var produto = _baseRepository.Query().FirstOrDefault(p => p.Situacao == true && p.Id == idProduto);
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

            produto = _baseRepository.Query().FirstOrDefault(p => p.Id == idProduto && p.Situacao == true);

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
