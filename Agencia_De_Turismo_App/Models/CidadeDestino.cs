using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurismoApp.Domain.models
{
    public  class CidadeDestino
    {

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        public string Nome { get; set; } = null!;

        [Required]
        public int PaisDestinoId { get; set; }
        public PaisDestino PaisDestino { get; set; } = null!;

        public ICollection<PontoTuristico> PontosTuristicos { get; set; } = new List<PontoTuristico>();

        public ICollection<PacoteTuristico> Pacotes { get; set; } = new List<PacoteTuristico>();
    }
}
