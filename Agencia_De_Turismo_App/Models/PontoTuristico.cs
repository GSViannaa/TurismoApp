using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoApp.Domain.models
{
   public class PontoTuristico
    {
        public int Id { get; set; }
        public string Nome { get; set; } = null!;
        public int CidadeDestinoId { get; set; }
  
    }
}
