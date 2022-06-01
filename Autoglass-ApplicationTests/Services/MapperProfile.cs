using Autoglass_Application.Dtos;
using Autoglass_Domain.Entities;
using AutoMapper;
using NUnit.Framework;

namespace Autoglass_ApplicationTests.Services
{
    [TestFixture]
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Produto, CriarProdutoDto>().ReverseMap();
            CreateMap<Produto, AlterarProdutoDto>().ReverseMap();
            CreateMap<ExibirProdutoDto, Produto>().ReverseMap();
            CreateMap<Fornecedor, CriarFornecedortDto>().ReverseMap();
            CreateMap<ExibirFornecedorDto, Fornecedor>().ReverseMap();

        }
    }
}
   
   
