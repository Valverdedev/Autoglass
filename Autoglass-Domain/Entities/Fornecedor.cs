using Autoglass_Domain_Core.Model;
using System.Collections.Generic;

namespace Autoglass_Domain.Entities
{
    public class Fornecedor : Entity
    {
        public string DescricaoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }
       
    }
}
