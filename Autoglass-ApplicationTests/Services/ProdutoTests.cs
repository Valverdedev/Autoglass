using Autoglas_Domain_Services.Services;
using Autoglass_Application.Dtos;
using Autoglass_Application.Interfaces;
using Autoglass_Application.Validators;
using Autoglass_Domain.Entities;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace Autoglass_Application.Services.Tests
{
    [TestClass()]
    public class ProdutoTests
    {
        private IProdutoAppService _produtoAppService;
        private ProdutoService _produtoService;
        private IMapper _mapper;

        
      
        [SetUp]
        public void Setup(IMapper mapper, IProdutoAppService produtoAppService, ProdutoService produtoService)
        {
            _produtoAppService = produtoAppService;
            _produtoService = produtoService;
            _mapper = mapper;
        }


        [TestMethod()]
        public async Task InsertAssyncTestAsync()
        {
            var produto = new Produto();
            var ProdutoDto = new CriarProdutoDto();

            ProdutoDto.Descricao = "testes";
            ProdutoDto.DataFabricacao = DateTime.Now;
            ProdutoDto.DataValidade = new DateTime(2022, 07, 02, 22, 59, 59);
            ProdutoDto.FornecedorId = 1;
            ProdutoDto.Situacao = true;

            
            //var produtoAppService = new ProdutoAppService(_mapper, _produtoService);

            try
            {
                await _produtoAppService.Inserir(ProdutoDto);
            }
            catch
            {
                Assert.Pass("Ok.");
            }

            Assert.Fail("Falha.");
        }
    }
}