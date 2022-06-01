using Autoglass_Application.Dtos;
using Autoglass_Domain.Entities;
using Autoglass_Domain.Interfaces.Repository;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Autoglass_Application.Validators
{
    public class ProdutoValidator : AbstractValidator<CriarProdutoDto>
    {
        private readonly IBaseRepository<Fornecedor> _fornecedorRepository;

        public ProdutoValidator(IBaseRepository<Fornecedor> fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
       
            RuleFor(c => c.Descricao)
                  .NotEmpty().WithMessage("Favor Inserir uma Descrição do produto.");

            RuleFor(c => c.DataFabricacao)
                .NotEqual(p => p.DataValidade).WithMessage("A data de Fabricação não pode ser igual a data de validade")
                .LessThan(p => p.DataValidade).WithMessage("A data de Fabricação não pode ser maior que a data de validade")
                .NotEmpty().WithMessage("Favor Inserir a data de fabricação.");
            RuleFor(c => c.DataValidade)
                .NotEmpty().WithMessage("Favor Inserir a data de validade.");

            RuleFor(x => x).Must(ExistId).WithMessage(x => $"Não há fornecedor com o ID : {x.FornecedorId }");
        }
        private bool ExistId(CriarProdutoDto arg)
        {
            var fornecedor = _fornecedorRepository.Query().FirstOrDefault(p => p.Id == arg.FornecedorId);

            if (fornecedor == null) { return false; }

            return true;
        }

    }
      
}

