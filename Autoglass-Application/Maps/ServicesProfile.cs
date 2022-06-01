using Autoglass_Application.Dtos;
using Autoglass_Domain.Entities;
using AutoMapper;

namespace Autoglass_Application.Maps
{
    public class ServicesProfile : Profile
    {
        public ServicesProfile()
        {
            CreateMap<Produto, CriarProdutoDto>().ReverseMap();
            CreateMap<Produto, AlterarProdutoDto>().ReverseMap();
            CreateMap<Fornecedor, FornecedortDto>().ReverseMap();
            CreateMap<ExibirProdutoDto, Produto>().ReverseMap();
        }
    }
}
