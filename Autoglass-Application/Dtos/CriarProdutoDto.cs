using System;

namespace Autoglass_Application.Dtos
{
    public class CriarProdutoDto
    {
        public CriarProdutoDto()
        {
            Situacao = true;
        }

        public string Descricao { get; set; }     
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int FornecedorId { get; set; }
        public bool Situacao;

       
    }
}
