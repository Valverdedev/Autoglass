using Autoglass_Domain_Core.Model;
using System;

namespace Autoglass_Domain.Entities
{
    public class Produto : Entity
    {
      

        public string Descricao { get; set; }
        public bool Situacao { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor Fornecedor { get; set; }
       
        public void SetSituacaoFalse()
        {
            Situacao = false;
        }

    }
}
