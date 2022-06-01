using Autoglas_Domain_Services.Services;
using Autoglass_Application.Dtos;
using Autoglass_Domain.Entities;
using Autoglass_Domain.Interfaces.Repository;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace Autoglass_Application.Services.Tests
{
    [TestClass()]
    public class ProdutoTests
    {


        [TestMethod()]
        public async Task InsertAssyncTestAsync()
        {
                       
          var  _mapper = new Mock<IMapper>();
          var _productService = new Mock<ProdutoService>();
          var _produtoRepository = new Mock<IBaseRepository<Produto>>();
          var _fornecedorRepository = new Mock<IBaseRepository<Fornecedor>>();

            ProdutoService ps = new(_produtoRepository.Object, _fornecedorRepository.Object);

           
            var ProdutoDto = new CriarProdutoDto();

            ProdutoDto.Descricao = "testeslola";
            ProdutoDto.DataFabricacao = DateTime.Now;
            ProdutoDto.DataValidade = new DateTime(2022, 05, 02, 22, 59, 59);
            ProdutoDto.FornecedorId = 1;
            ProdutoDto.Situacao = true;
            Produto produto = new();

            produto.Descricao = ProdutoDto.Descricao;
            produto.DataFabricacao = ProdutoDto.DataFabricacao;
            produto.DataValidade = ProdutoDto.DataValidade;
            produto.FornecedorId = ProdutoDto.FornecedorId;

            _mapper.Setup(x => x.Map<CriarProdutoDto>(produto)).Returns(ProdutoDto);
            


            try
            {
                await ps.Adicionar(produto);
            }
            catch
            {
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}