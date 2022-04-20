using Autoglass_Application.Dtos;
using FluentValidation;
using System;

namespace Autoglass_Application.Validators
{
    public class ProdutoValidator : AbstractValidator<CriarProdutoDto>
    {
        public ProdutoValidator()
        {
            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("Favor Inserir uma Descrição do produto.");
            RuleFor(c => c.DescricaoFornecedor)
                .NotEmpty().WithMessage("Favor Inserir uma Descrição do fornecedor.");
            RuleFor(c => c.CodigoFornecedor)
                .NotEmpty().WithMessage("Favor Inserir o código do fornecedor.");
            RuleFor(c => c.CnpjFornecedor)
                .NotEmpty().WithMessage("Favor Inserir CNPJ do fornecedor.")
                .Must(ValidarCnpj).WithMessage("Favor Inserir um CNPJ do válido.");
            RuleFor(c => c.DataFabricacao)
                .NotEqual(p => p.DataValidade).WithMessage("A data de Fabricação não pode ser igual a data de validade")
                .LessThan(p => p.DataFabricacao).WithMessage("A data de Fabricação não pode ser maior que a data de validade")
                .NotEmpty().WithMessage("Favor Inserir a data de fabricação.");
            RuleFor(c => c.DataValidade)
                .NotEmpty().WithMessage("Favor Inserir a data de validade.");
           
        }

        private bool ValidarCnpj(string arg)
        {
            return ValidaCnpj.IsCnpj(arg);            
        }
      
    }
}
