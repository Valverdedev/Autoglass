using Autoglass_Application.Dtos;
using Autoglass_Domain.Entities;
using Autoglass_Domain.Interfaces.Repository;
using FluentValidation;
using System.Linq;

namespace Autoglass_Application.Validators
{
    public class AlterarProdutoValidator : AbstractValidator<AlterarProdutoDto>
    {
        private readonly IBaseRepository<Fornecedor> _fornecedorRepository;
        private readonly IBaseRepository<Produto> _produtoRepository;

        public AlterarProdutoValidator(IBaseRepository<Produto> produtoRepository, IBaseRepository<Fornecedor> fornecedorRepository)
        {
            _fornecedorRepository = fornecedorRepository;
            _produtoRepository = produtoRepository;

            RuleFor(c => c.Descricao)
                  .NotEmpty().WithMessage("Favor Inserir uma Descrição do produto.");

            RuleFor(c => c.DataFabricacao)
                .NotEqual(p => p.DataValidade).WithMessage("A data de Fabricação não pode ser igual a data de validade")
                .LessThan(p => p.DataValidade).WithMessage("A data de Fabricação não pode ser maior que a data de validade")
                .NotEmpty().WithMessage("Favor Inserir a data de fabricação.");
            RuleFor(c => c.DataValidade)
                .NotEmpty().WithMessage("Favor Inserir a data de validade.");
            RuleFor(x => x).Must(ExistFornecedorId).WithMessage(x => $"Não há fornecedor com o ID : {x.FornecedorId }");

            RuleFor(x => x).Must(ExistId).WithMessage(x => $"Não há produto com o ID : {x.Id }");
        }

        private bool ExistId(AlterarProdutoDto arg)
        {
            var produto = _produtoRepository.Query().FirstOrDefault(p => p.Id == arg.Id);

            if (produto == null) { return false; }

            return true;
        }

        private bool ExistFornecedorId(AlterarProdutoDto arg)
        {
            var fornecedor = _fornecedorRepository.Query().FirstOrDefault(p => p.Id == arg.FornecedorId);

            if (fornecedor == null) { return false; }

            return true;
        }
    }


}

