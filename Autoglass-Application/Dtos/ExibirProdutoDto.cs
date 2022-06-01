using System;

namespace Autoglass_Application.Dtos
{
    public class ExibirProdutoDto
    {
        public int  Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int FornecedorId { get; set; }

        public bool Situacao;
    }
}
